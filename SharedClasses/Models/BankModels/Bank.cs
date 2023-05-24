using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SharedClasses.Helpers;


namespace SharedClasses.Models.BankModels;

    public class Bank
    {
       

        public Bank()
        {
            this.Id = Guid.NewGuid();
            this.Accounts = new List<Account>();
            // Bank.Banks.Add(this);
        }
        [BsonElement]
        public Guid Id { get; set; }

        [BsonElement]
        public List<Account> Accounts { get; set; }

        public Guid CreateAccount(Name name)
        {
            Guid id = Guid.NewGuid();

            Accounts.Add(new Account(id, this.Id, name));

            return id;
        }


       
        

        




    }