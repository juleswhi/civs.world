namespace SharedClasses.Models.CountryModels;
using MongoDB.Bson.Serialization.Attributes;

public class NewCountry
{
    public NewCountry(string name, int Population, string CountryCode)
    {
        this.Name = name;
        this.Id = Guid.NewGuid();
        this.Population = Population;
        this.CountryCode = CountryCode;
    }


    [BsonId]
    public Guid Id { get; set; }
    [BsonElement]
    public string Name { get; set; }
    [BsonElement]
    public string CountryCode { get; set; }
    [BsonElement]
    public int Population { get; set; }
    [BsonElement]
    public double Longitude { get; set; }
    [BsonElement]
    public double Latitude { get; set; }
    [BsonElement]
    public SkillTree? SkillTree { get; set; }


}
