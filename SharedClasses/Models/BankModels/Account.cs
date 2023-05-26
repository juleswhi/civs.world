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


    [BsonId]
    public Guid AccountId { get; set; }
    [BsonElement]
    public Guid PlayerId { get; set; }
    [BsonElement]
    public Guid BankId { get; set; }
    [BsonElement]
    public decimal Balance { get; set; }


    public static async Task<Code> CreateAccount(Guid? playerGuid, Guid? bankGuid)
    {

        if (playerGuid is null) return Code.AccountNotFound;
        if (bankGuid is null) return Code.AccountNotFound;

        Guid PlayerGuid = (Guid)playerGuid;
        Guid BankGuid = (Guid)bankGuid;

        /* This code is creating a new account for a player in a bank. It first checks if the player
        and bank exist in the database, and if not, it returns an error code. If they do exist, it
        adds the new account to the bank's list of accounts and the player's list of accounts,
        updates those lists in the database, and inserts the new account into the account collection
        in the database. Finally, it returns a success code. */

        var account = new Account(PlayerGuid, BankGuid);


        var player = DataBaseClient.PlayerCollection.Find(Builders<Player>.Filter.Eq(x => x.Id, PlayerGuid)).FirstOrDefault();
        var bank = DataBaseClient.BankCollection.Find(Builders<Bank>.Filter.Eq(x => x.Id, BankGuid)).FirstOrDefault();

        if (player is null) return Code.AccountNotFound;
        if (bank is null) return Code.AccountNotFound;

        bank.Accounts.Add(account.AccountId);
        player.Accounts.Add(account.AccountId);

        await DataBaseClient.BankCollection.UpdateOneAsync(
            Builders<Bank>.Filter.Eq(x => x.Id, bank.Id),
            Builders<Bank>.Update.Set(x => x.Accounts, bank.Accounts)
        );

        await DataBaseClient.PlayerCollection.UpdateOneAsync(
            Builders<Player>.Filter.Eq(x => x.Id, PlayerGuid),
            Builders<Player>.Update.Set(x => x.Accounts, player.Accounts)
        );

        await DataBaseClient.AccountCollection.InsertOneAsync(account);


        return Code.Ok;
    }


    #region Account Management
    public static async Task<Code> Withdrawl(Account account, decimal amount)
    {

        if (account is null) return Code.AccountNotFound;

        var update = Builders<Account>.Update.Set(x => x.Balance, account.Balance -= amount);

        await DataBaseClient.AccountCollection.UpdateOneAsync(
            Builders<Account>.Filter.Eq(x => x.AccountId, account.AccountId),
            update);

        return Code.Ok;
    }

    public static async Task<Code> Transfer(Account WithdrawAccount, Account RecipientAccount, decimal TransferAmount)
    {
        if(WithdrawAccount is null) return Code.AccountNotFound;
        if(RecipientAccount is null) return Code.AccountNotFound;



        if (WithdrawAccount.Balance >= TransferAmount)
            await Account.Withdrawl(WithdrawAccount, TransferAmount);
        else return Code.InsufficientFunds;

        await Account.Deposit(RecipientAccount, TransferAmount);

        return Code.Ok;
    }

    public static async Task<Code> Deposit(Account account, decimal amount)
    {
        account.Balance += amount;

        var update = Builders<Account>.Update.Set(x => x.Balance, account.Balance);

        await DataBaseClient.AccountCollection.UpdateOneAsync(
            Builders<Account>.Filter.Eq(x => x.AccountId, account.AccountId),
            update
        );

        Console.WriteLine($"Updated Account: {account.PlayerId} Balance To {account.Balance}");

        return Code.Ok;
    }

    #endregion

}