using SharedClasses.Helpers;
using MongoDB.Driver;
using SharedClasses.Models.BankModels;
using SharedClasses.Models.CountryModels;
using SharedClasses.Models.UserModels;







var bank = (Bank)DataBaseClient.BankCollection.Find(Builders<Bank>.Filter.Eq(x => x.CountryOfOrigin, 
    ((Country)DataBaseClient.CountryCollection.Find(Builders<Country>.Filter.Eq(x => x.Name, "Russia"))).Id
));

var player = DataBaseClient.PlayerCollection.Find(Builders<Player>.Filter.Eq(x => x.Username, "CUrsache123")).FirstOrDefault();


bank.CreateAccount(
);


