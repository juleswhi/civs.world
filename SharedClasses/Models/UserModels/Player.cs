using MongoDB.Driver;
using SharedClasses.Models.BankModels;
using SharedClasses.Helpers;

namespace SharedClasses.Models.UserModels;

public class Player
{
    public Player(Name name, string Password)
    {
        this.Id = Guid.NewGuid();
        this.Name = Name;
        // Encrypt Password Somehow
        this.Password = Password;
        this.Accounts = new List<Guid>();
    }


    [BsonElement]
    public Guid Id { get; set; }
    [BsonElement]
    public Name Name { get; set; }
    [BsonElement]
    public string Password { get; set; }
    [BsonElement]
    public List<Guid> Accounts { get; set; }



    public async Task<IEnumerable<Account>> GetPlayerAccounts()
    {
        var AccountCollection = DataBaseClient.Database.GetCollection<Account>("BankAccountData");

        var filter = Builders<Account>.Filter.Eq(x => x.PlayerId, Id);

        var query = await AccountCollection.FindAsync(filter);

        if (query.ToEnumerable() == Enumerable.Empty<Account>()) return Enumerable.Empty<Account>();

        List<Account> accounts = new List<Account>();


        foreach (var result in query.ToList<Account>())
        {
            accounts.Add(result);
        }

        return accounts;
    }
}