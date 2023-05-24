using MongoDB.Driver;
using SharedClasses.Models.BankModels;
using SharedClasses.Helpers;

namespace SharedClasses.Models.UserModels;
    public class Player
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public string Password { get; set; }
        public List<Guid> Accounts { get; set; }


        public async Task<IEnumerable<Account>> GetPlayerAccounts()
        {

            var AccountCollection = DataBaseClient.Database.GetCollection<Account>("BankAccountData");

            var filter = Builders<Account>.Filter.Eq(x => x.OwnerId, Id); 

            var query = await AccountCollection.FindAsync(filter);

            if(query.ToEnumerable() == Enumerable.Empty<Account>()) return Enumerable.Empty<Account>();

            List<Account> accounts = new List<Account>();


            foreach(var result in query.ToList<Account>())
            {
                accounts.Add(result);
            }

            return accounts;


        }
    }