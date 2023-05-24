using SharedClasses.Helpers;
using MongoDB.Driver;
using SharedClasses.Models.ArmyModels;
using SharedClasses.Models.BankModels;
using SharedClasses.Models.CountryModels;
using SharedClasses.Models.UserModels;

var db = DataBaseClient.Database;



await DataBaseClient.AccountCollection.DeleteManyAsync(Builders<Account>.Filter.Exists(x => x.Balance));

await DataBaseClient.ArmyCollection.DeleteManyAsync(Builders<Army>.Filter.Exists(x => x.Id));

await DataBaseClient.CountryCollection.DeleteManyAsync(Builders<Country>.Filter.Exists(x => x.Name));

await DataBaseClient.BankCollection.DeleteManyAsync(Builders<Bank>.Filter.Exists(x => x.Accounts));