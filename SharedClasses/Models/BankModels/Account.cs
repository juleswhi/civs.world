using SharedClasses.Helpers;
namespace SharedClasses.Models.BankModels;

public class Account
{
    public Account(Guid PlayerId, Guid BankId, decimal Balance = 0)
    {
        this.Balance = Balance;
        this.AccountId = Guid.NewGuid();
        this.PlayerId = PlayerId;
        this.BankId = BankId;
    }



    [BsonElement]
    public Guid AccountId { get; set; }
    [BsonElement]
    public Guid PlayerId { get; set; }
    [BsonElement]
    private Guid BankId { get; set; }
    [BsonElement]
    public decimal Balance { get; set; }



    #region Account Management
    public static async Task<Code> Withdrawl(Guid accountGuid, decimal amount)
    {
        var filter = Builders<Account>.Filter.Eq(x => x.AccountId, accountGuid);
        var foundAccount = DataBaseClient.AccountCollection.Find(filter).ToEnumerable<Account>().FirstOrDefault();

        var update = Builders<Account>.Update.Set(x => x.Balance, foundAccount.Balance -= amount);

        await DataBaseClient.AccountCollection.UpdateOneAsync(filter, update);

        return Code.Ok;
    }


    public static async Task<Code> Transfer(Guid WithdrawingAccount, Guid IntendedRecipientAccount, decimal TransferAmount)
    {
        var WithdrawingAccountFilter = Builders<Account>.Filter.Eq(x => x.AccountId, WithdrawingAccount);
        var IntendedRecipientFiter = Builders<Account>.Filter.Eq(x => x.AccountId, IntendedRecipientAccount);

        var WithdrawAccount = DataBaseClient.AccountCollection.Find(WithdrawingAccountFilter).FirstOrDefault();
        var RecipientAccount = DataBaseClient.AccountCollection.Find(IntendedRecipientFiter).FirstOrDefault();

        if(WithdrawAccount is null) return Code.AccountNotFound;
        if(RecipientAccount is null) return Code.AccountNotFound;

        if (WithdrawAccount.Balance >= TransferAmount)
        {
            var result = await Account.Withdrawl(WithdrawAccount.AccountId, TransferAmount);

            if (result != Code.Ok) return result;
        }
        else return Code.InsufficientFunds;

        return await Account.Deposit(RecipientAccount.AccountId, TransferAmount);
    }

    public static async Task<Code> Deposit(Guid accountGuid, decimal amount)
    {

        var filter = Builders<Account>.Filter.Eq(x => x.AccountId, accountGuid);
    
        var DespositAccount = DataBaseClient.AccountCollection.Find(filter).FirstOrDefault();

        var update = Builders<Account>.Update.Set(x => x.Balance, DespositAccount.Balance += amount);

        await DataBaseClient.AccountCollection.UpdateOneAsync(filter, update);

        return Code.Ok;
    }

    #endregion

}