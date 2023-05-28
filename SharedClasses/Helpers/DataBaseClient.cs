
namespace SharedClasses.Helpers;
using SharedClasses.Models.AllianceModels;
public class DataBaseClient
{
    static DataBaseClient()
    {
        DotNetEnv.Env.Load();
        Client = new MongoClient(Environment.GetEnvironmentVariable("MongoDBConnectionString"));
        Database = Client.GetDatabase("UserDatabase");
        AccountCollection = Database.GetCollection<Account>("BankAccountData");
        BankCollection = Database.GetCollection<Bank>("BankData");
        ArmyCollection = Database.GetCollection<Army>("ArmyData");
        CountryCollection = Database.GetCollection<Country>("CountryData");
        PlayerCollection = Database.GetCollection<Player>("PlayerData");
        AllianceCollection = Database.GetCollection<Alliance>("AllianceData");
    }
    public static IMongoClient Client { get; set; }
    public static IMongoDatabase Database { get; set; }
    public static IMongoCollection<Account> AccountCollection { get; set; }
    public static IMongoCollection<Bank> BankCollection { get; set; }
    public static IMongoCollection<Army> ArmyCollection { get; set; }
    public static IMongoCollection<Country> CountryCollection { get; set; }
    public static IMongoCollection<Player> PlayerCollection { get; set; }
    public static IMongoCollection<Alliance> AllianceCollection { get; set; }
   
}
