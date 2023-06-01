namespace SharedClasses.Models.CountryModels;

public class CountryPosition
{
    public string Country { get; set; }
    public string alpha2 { get; set; }
    public string alpha3 { get; set; }
    public int numeric { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
}