using Models.HelperModels;
using MongoDB.Driver;
using MongoDB.Bson;
using DatabaseHelperLibrary;
using MongoDB.Bson.Serialization.Attributes;
namespace Models.BankModels;
    public class Account
    {
        public Account(Guid holder, Guid BankGuid, Name? name = null)
        {
            this.OwnerId = holder;
            this.AccountId = Guid.NewGuid();
            this.BankGuid = BankGuid; 
            this.Name = name;
        }
        [BsonElement]
        public Guid AccountId { get; set; }
        [BsonElement]
        public Guid OwnerId { get; set; }
        [BsonElement]
        public Name? Name { get; set; }
        [BsonElement]
        private decimal Balance { get; set; } = 0;
        [BsonElement]
        private Guid BankGuid { get; set; }

        public decimal GetBalance() => Balance;

        /*
        #region Withdrawl

        public static Code Withdrawl(Guid accountGuid, decimal amount)
        {
            Bank.SearchAllBankAccounts(() => accountGuid, out Account? foundAccount);

            if (foundAccount is null) return Code.AccountNotFound;

            if (foundAccount.Balance >= amount) foundAccount.Balance -= amount;

            else return Code.InsufficientFunds;

            return Code.Ok;
        }

        #endregion

        #region Transfer
        public static Code Transfer(Func<Name> WithdrawingAccount, decimal TransferAmount, Func<Name> IntendedRecipient)
        {

            Bank.SearchAllBankAccounts(WithdrawingAccount, out Account? account);
            Bank.SearchAllBankAccounts(IntendedRecipient, out Account? recipientAccount);

            if (account is null) return Code.AccountNotFound;

            if (recipientAccount is null) return Code.AccountNotFound;

            if (TransferAmount > account.Balance) return Code.InsufficientFunds;

            // Deposit(recipientAccount.AccountId, TransferAmount, x => x.Id);

            // account.Withdraw(TransferAmount);

            return Code.Ok; 
        }
        #endregion
        */
        
        #region Deposit
        public static Code Deposit(Guid accountGuid, decimal amount)
        {


            var BankDataCollection = DataBaseClient.dbClient.GetDatabase("UserDatabase").GetCollection<Bank>("BankData");

            Account? foundAccount = null;

            foreach(var bank in BankDataCollection.Find(Builders<Bank>.Filter.Exists(x => x.Id)).ToList())
            {
                foreach(var account in bank.Accounts)
                {
                    if(account.AccountId == accountGuid)
                    {
                        foundAccount = account;
                    }
                }
            }




            if (foundAccount is null) return Code.AccountNotFound;
            

            foundAccount.Balance += amount;



            return Code.Ok;
        }

        #endregion


    }