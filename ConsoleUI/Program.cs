Console.WriteLine("Hello World");

var country = DataBaseClient.CountryCollection.Find(
    Builders<Country>.Filter.Eq(x => x.Name, "Ireland")
).FirstOrDefault();

if (country is null) return;

Console.WriteLine("Country is found");




await Player.CreatePlayer(
new Name("Jules", "White"),
    "Pass6969",
    "JulesWhi",
    country.Id
);