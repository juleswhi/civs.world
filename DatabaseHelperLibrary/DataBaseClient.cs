using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Models.HelperModels;


namespace DatabaseHelperLibrary
{
    public static class DataBaseClient
    {

        public static MongoClient? dbClient = null;

        public static void InitialiseDatabase()
        {
            DotEnv.SetEnvironmentVariables();
            dbClient = new MongoClient(Environment.GetEnvironmentVariable("MongoDBConnectionString"));
        }


        public static async void ShowTables()
        {

            var dbs = await dbClient.ListDatabaseNamesAsync();

            var collections = await dbClient.GetDatabase("local").ListCollectionsAsync();

            Console.WriteLine(collections);

        } 

        public static async void CreateDatabase()
        {
            var db = dbClient.GetDatabase("local");
            await db.CreateCollectionAsync("CountryData");
            System.Console.WriteLine("Created Database");
        }

        public static void FindDocuments()
        {
            
        }

    }

    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}