
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

    #region Deposit
    public static Code Deposit(Guid accountGuid, decimal amount)
    {
        var BankDataCollection = DataBaseClient.Database.GetCollection<Bank>("BankData");

        Account? foundAccount = null;

        foreach (var bank in BankDataCollection.Find(Builders<Bank>.Filter.Exists(x => x.Id)).ToList())
            foreach (var account in bank.Accounts)
            {
                if (account.AccountId == accountGuid)
                {
                    foundAccount = account;
                }
            }

        if (foundAccount is null) return Code.AccountNotFound;

        foundAccount.Balance += amount;

        return Code.Ok;
    }

    #endregion
*/

}