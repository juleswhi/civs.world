using System.IO;
using Newtonsoft.Json;

List<Country> countries = DataBaseClient.CountryCollection.Find(
    Builders<Country>.Filter.Exists( x => x.Id )
).ToList();

await DataBaseClient.CountryCollection.DeleteManyAsync(
    Builders<Country>.Filter.Exists(x => x.Id)
);

System.Console.WriteLine("Deleted all countries");


foreach(var country in countries)
{
    country.Colour = String.Format("#{0:X6}", new Random((int)DateTime.Now.Ticks).Next(0x1000000));
}

await DataBaseClient.CountryCollection.InsertManyAsync(countries);
System.Console.WriteLine("Created All Countries");
