using SharedClasses.Helpers;
using MongoDB.Driver;
using SharedClasses.Models.BankModels;
using SharedClasses.Models.CountryModels;
using SharedClasses.Models.UserModels;




var AyrBank = DataBaseClient.BankCollection.Find(
        Builders<Bank>.Filter.Eq(x => x.BankName, "Royal Bank Of Ayr")
    ).FirstOrDefault();



var Jason = DataBaseClient.PlayerCollection.Find(Builders<Player>.Filter.Eq(x => x.Username, "JChu123")).FirstOrDefault();

var Cosmin = DataBaseClient.PlayerCollection.Find(Builders<Player>.Filter.Eq(x => x.Username, "CUrsache123")).FirstOrDefault();


await Account.Deposit(Jason.Id, 20_000);



