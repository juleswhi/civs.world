
namespace SharedClasses.Models.BankModels;

public class Bank
{
    public Bank(Guid NationOfOrigin, string BankName, string NationalOrGlobal)
    {
        if(NationalOrGlobal == "National") GlobalOrLocal = false;
        if(NationalOrGlobal == "Global") GlobalOrLocal = true;
        this.BankName = BankName;
        this.NationOfOrigin = NationOfOrigin;
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
    public Guid NationOfOrigin { get; set; }
    // True = Global, False = Local
    [BsonElement]
    public bool GlobalOrLocal { get; set; }
}
