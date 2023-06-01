namespace SharedClasses.Models.CountryModels;
using MongoDB.Bson.Serialization.Attributes;

public class Country
{
    public Country(string name, int Population, string CountryCode)
    {
        var rng = new Random();
        this.Name = name;
        this.Id = Guid.NewGuid();
        this.EconomicEvaluation = rng.Next(5, 10);
        // Fetch Real population 
        this.Population = Population;
        this.GlobalPopularity = 25;
        this.LocalPopularity = 35;
        this.CountryCode = CountryCode;
    }


    [BsonId]
    public Guid Id { get; set; }
    [BsonElement]
    public string Name { get; set; }
    [BsonElement]
    public string CountryCode { get; set; }
    [BsonElement]
    public int EconomicEvaluation { get; set; }
    [BsonElement]
    public int Population { get; set; }
    [BsonElement]
    public int GlobalPopularity { get; set; }
    [BsonElement]
    public int LocalPopularity { get; set; }
    [BsonElement]
    public double Longitude { get; set; }
    [BsonElement]
    public double Latitude { get; set; }
    [BsonElement]
    public SkillTree? SkillTree { get; set; }
    [BsonElement]
    public string Colour { get; set; }







    public static List<Country?> GetAllAvailableCountries()
    {
        // Query databas
        // Filter countries occupied by players
        // return all non occupied

        var CountryFilter = Builders<Country>.Filter.Exists(x => x.Id);
        var Countries = DataBaseClient.CountryCollection.Find(CountryFilter).ToList();

        var PlayerFilter = Builders<Player>.Filter.Exists(x => x.CountryId);
        var Players = DataBaseClient.PlayerCollection.Find(PlayerFilter).ToList();

        var UnoccupiedCountries = Enumerable.Range(0, Countries.Count())
                .Select(x => {

                    foreach(var player in Players)
                    {
                        if(player.CountryId == Countries[x].Id)
                            return null; 
                    }

                    return Countries[x];
                }).ToList();

        return UnoccupiedCountries.Where( x => x != null).ToList();
    }



    public static List<CountryWithColor> GetCountryColour()
    {
        List<CountryWithColor> rCountries = new();

        var players = DataBaseClient.PlayerCollection.Find(_ => true).ToList();

        var countries = DataBaseClient.CountryCollection.Find(_ => true).ToList();

        foreach(var country in countries)
        {
            string Colour = "#eeeeee";
            string Username = "Not Occupied";
            foreach(var player in players)
            {
                foreach(var playerCountry in player.CountryIds)
                {
                    if(playerCountry == country.Id)
                    {
                        Colour = player.Colour;
                        Username = player.Username;
                    }
                }
            }

            country.Colour = Colour;

            rCountries.Add(
                new CountryWithColor{
                    Country = country.Name,
                    Color = country.Colour,
                    Code = country.CountryCode,
                    Username = Username
                }
            );

        }



        return rCountries;
    }


}