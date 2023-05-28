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


}