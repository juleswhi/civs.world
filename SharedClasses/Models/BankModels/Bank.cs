
namespace SharedClasses.Models.BankModels;

public class Bank
{
    public Bank(Guid CountryOfOrigin, string BankName)
    {
        this.BankName = BankName;
        this.CountryOfOrigin = CountryOfOrigin;
        this.Id = Guid.NewGuid();
        this.Accounts = new List<Guid>();
    }


    [BsonElement]
    public Guid Id { get; set; }
    [BsonElement]
    public string BankName { get; set; }
    [BsonElement]
    public List<Guid> Accounts { get; set; }
    [BsonElement]
    public Guid CountryOfOrigin { get; set; }
    [BsonElement]
    public bool GlobalOrLocal { get; set; }
}
