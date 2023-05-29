Console.WriteLine("Hello World");

var country = DataBaseClient.CountryCollection.Find(
    Builders<Country>.Filter.Exists(x => x.Id)
).ToList();


foreach(var i in country)
{
    if(i.Name.Contains("Sudan"))
        Console.WriteLine(i.CountryCode + " " + i.Name);
    if(i.Name.Contains("Serbia"))
        Console.WriteLine(i.CountryCode + " " + i.Name);
    if(i.Name.Contains("Kosovo"))
        Console.WriteLine(i.CountryCode + " " + i.Name);
    if(i.Name.Contains("Montenegro"))
        Console.WriteLine(i.CountryCode + " " + i.Name);
}

var rng = new Random();

var montenegro = new Country("Montenegro", rng.Next(1_000, 1_000_000), "ME");

await DataBaseClient.CountryCollection.InsertOneAsync(montenegro);