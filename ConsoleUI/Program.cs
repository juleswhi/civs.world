



var russia = DataBaseClient.CountryCollection.Find(
    Builders<Country>.Filter.Eq( x=> x.Name, "Russian Federation")
).FirstOrDefault();

if(russia is null) Console.WriteLine("Russia Not Found");

Name name = new Name("Joseph", "McCann");

await Player.CreatePlayer(name, "Password", "JoFo", russia.Id);