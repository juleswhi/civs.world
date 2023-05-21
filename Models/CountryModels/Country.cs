using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Models.CountryModels;
public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int EconomicEvaluation { get; set; }
    public int Population { get; set; }
}