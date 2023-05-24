namespace SharedClasses.Models.CountryModels;

public class Country
{
    public Country(string name, int Population)
    {
        var rng = new Random();
        this.Name = name;
        this.Id = Guid.NewGuid();
        this.EconomicEvaluation = rng.Next(5, 10);
        // Fetch Real population 
        this.Population = Population;
        this.GlobalPopularity = 25;
        this.LocalPopularity = 35;
    }


    public Guid Id { get; set; }
    public string Name { get; set; }
    public int EconomicEvaluation { get; set; }
    public int Population { get; set; }
    public int GlobalPopularity { get; set; }
    public int LocalPopularity { get; set; }
}