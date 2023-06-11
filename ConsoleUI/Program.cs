var countries = DataBaseClient.Countries.Find(_ => true).ToList();

DataBaseClient.CountryCollection.DeleteMany(_ => true);

List<Country> newCountries = new();

foreach(var country in countries) {
    newCountries.Add( new Country(country.Name, country.Population, country.CountryCode));
}

await DataBaseClient.CountryCollection.InsertManyAsync(newCountries);
Console.WriteLine("Added Coutnries");
