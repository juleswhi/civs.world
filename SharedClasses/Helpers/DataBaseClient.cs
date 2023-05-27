using SharedClasses.Models.BankModels;
using SharedClasses.Models.CountryModels;
using SharedClasses.Models.ArmyModels;


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

    public static readonly IMongoDatabase Database { get; set; }
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

    public static async Task CreateDocuments<T>(this IMongoCollection<T> collection, params T[] documents)
    {
        await collection.InsertManyAsync(documents);
    }

    public static async Task CreateDocument<T>(this IMongoCollection<T> collection, T document)
    {
        await collection.InsertOneAsync(document);
    }

    public static async Task DeleteAllDocuments<T>(this IMongoCollection<T> collection)
    {
        await collection.DeleteAllDocuments<T>();
    }

}
