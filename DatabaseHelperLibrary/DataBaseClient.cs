using MongoDB.Driver;

namespace DatabaseHelperLibrary;
    public static class DataBaseClient
    {
        static DataBaseClient()
        {
            DotNetEnv.Env.Load();
            dbClient = new MongoClient(Environment.GetEnvironmentVariable("MongoDBConnectionString"));
            Console.WriteLine("Successfully connected to mongo client");
            Database = dbClient.GetDatabase("UserDatabase");
            Console.WriteLine("Connected to mongo database");
        }


        public static MongoClient? dbClient = null;
        public static IMongoDatabase? Database = null;




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