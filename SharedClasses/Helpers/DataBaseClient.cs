
namespace SharedClasses.Helpers;

public static class DataBaseClient
{
    static DataBaseClient()
    {
        MongoClient dbClient;
        DotNetEnv.Env.Load();
        dbClient = new MongoClient(Environment.GetEnvironmentVariable("MongoDBConnectionString"));
        Database = dbClient.GetDatabase("UserDatabase");
        AccountCollection = Database.GetCollection<Account>("BankAccountData");
        BankCollection = Database.GetCollection<Bank>("BankData");
        ArmyCollection = Database.GetCollection<Army>("ArmyData");
        CountryCollection = Database.GetCollection<Country>("CountryData");
        PlayerCollection = Database.GetCollection<Player>("PlayerData");
    }

    public static IMongoDatabase Database { get; set; }
    public static IMongoCollection<Account> AccountCollection { get; set; }
    public static IMongoCollection<Bank> BankCollection { get; set; }
    public static IMongoCollection<Army> ArmyCollection { get; set; }
    public static IMongoCollection<Country> CountryCollection { get; set; }
    public static IMongoCollection<Player> PlayerCollection { get; set; }


    public static async Task<List<T>> FindDocuments<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter)
    {
        var results = await collection.FindAsync(filter);
        return results.ToList<T>();
    }
}
