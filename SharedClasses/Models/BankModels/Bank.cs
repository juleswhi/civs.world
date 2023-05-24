using SharedClasses.Helpers;

namespace SharedClasses.Models.BankModels;

public class Bank
{
    public Bank(Guid CountryOfOrigin)
    {
        this.CountryOfOrigin = CountryOfOrigin;
        this.Id = Guid.NewGuid();
        this.Accounts = new List<Guid>();
    }


    [BsonElement]
    public Guid Id { get; set; }
    [BsonElement]
    public List<Guid> Accounts { get; set; }
    [BsonElement]
    public Guid CountryOfOrigin { get; set; }


    public async Task CreateAccount(Guid PlayerId)
    {
        var account = new Account(PlayerId, Id);

        await DataBaseClient.AccountCollection.InsertOneAsync(account);
    }
}