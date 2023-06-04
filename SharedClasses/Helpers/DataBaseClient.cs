namespace SharedClasses.Helpers;
using SharedClasses.Models.AllianceModels;
public static class DataBaseClient
{
    static DataBaseClient()
    {
        DotNetEnv.Env.Load();
        string? connectionString = Environment.GetEnvironmentVariable("MongoDBConnectionString");
        if(connectionString is null) throw new FileNotFoundException("Cannot Find .env");
        Client = new MongoClient(connectionString);
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


    public static async Task<List<T>> FindDocuments<T>(this IMongoCollection<T> collection, FilterDefinition<T> filter)
    {
        var results = await collection.FindAsync(filter);
        return results.ToList<T>();
    }
}
