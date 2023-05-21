using DatabaseHelperLibrary;
using Models.HelperModels;
using Models.BankModels;
using MongoDB.Driver;

IMongoCollection<Account>? AccountCollection = DataBaseClient.Database.GetCollection<Account>("BankAccountData");
IMongoCollection<Bank>? BankCollection = DataBaseClient.Database.GetCollection<Bank>("BankData");


var rng = new Random();



// await collection.DeleteManyAsync(Builders<Bank>.Filter.Exists(x => x.Id));

