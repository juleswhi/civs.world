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


    public static async Task<Code> CreateAccount(Guid PlayerGuid, Guid BankGuid)
    {


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


        /* This code is performing a withdrawal from an account. It first checks if the account exists by
        checking if the `account` parameter is null. If the account is not found, it returns an error code.
        If the account has sufficient funds, it creates an update object using the
        `Builders<Account>.Update.Set` method to subtract the `amount` parameter from the account's balance.
        It then calls the `UpdateOneAsync` method on the `AccountCollection` of the database to update the
        account with the new balance. Finally, it returns a success code. */


        if (account is null) return Code.AccountNotFound;

        var update = Builders<Account>.Update.Set(x => x.Balance, account.Balance -= amount);

        await DataBaseClient.AccountCollection.UpdateOneAsync(
            Builders<Account>.Filter.Eq(x => x.AccountId, account.AccountId),
            update);

        return Code.Ok;
    }


    public static async Task<Code> Transfer(Guid WithdrawingAccount, Guid IntendedRecipientAccount, decimal TransferAmount)
    {


        /* This code is performing a transfer of funds between two accounts. It first retrieves the
        account from which the funds are being withdrawn using the `WithdrawingAccount` parameter.
        If the account is not found, it returns an error code. If the account has sufficient funds,
        it calls the `Withdrawl` method to deduct the transfer amount from the account's balance. If
        the withdrawal is successful, it calls the `Deposit` method to add the transfer amount to
        the intended recipient account. If the withdrawal is not successful, it returns an error
        code. */


        var WithdrawingAccountFilter = Builders<Account>.Filter.Eq(x => x.AccountId, WithdrawingAccount);
        var WithdrawAccount = DataBaseClient.AccountCollection.Find(WithdrawingAccountFilter).FirstOrDefault();

        if (WithdrawAccount is null) return Code.AccountNotFound;

        if (WithdrawAccount.Balance >= TransferAmount)
        {
            var result = await Account.Withdrawl(WithdrawAccount, TransferAmount);

            if (result != Code.Ok) return result;
        }
        else return Code.InsufficientFunds;
        await Account.Deposit(IntendedRecipientAccount, TransferAmount);

        return Code.Ok;
    }

    public static async Task<Code> Deposit(Guid accountGuid, decimal amount)
    {


        /* This code is finding an account in the `AccountCollection` of the database using the
        `accountGuid` parameter as the filter. It then updates the balance of the account by adding
        the `amount` parameter to the current balance. Finally, it updates the account in the
        `AccountCollection` with the new balance using the `UpdateOneAsync` method. This code is
        used to deposit funds into an account. */



        var DespositAccount = DataBaseClient.AccountCollection.Find(
            Builders<Account>.Filter.Eq(x => x.AccountId, accountGuid)
        ).FirstOrDefault();

        if(DespositAccount is null) return Code.AccountNotFound;

        var update = Builders<Account>.Update.Set(x => x.Balance, DespositAccount.Balance += amount);

        await DataBaseClient.AccountCollection.UpdateOneAsync(
            Builders<Account>.Filter.Eq(x => x.AccountId, accountGuid),
            update);
        
        return Code.Ok;
    }

    #endregion

}