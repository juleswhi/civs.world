namespace SharedClasses.Helpers.CountryMapSerialisation;
public static class GetData
{

    public static (List<Player>, List<Country>) GetPlayersAndCountries()
    {
        
        var players = DataBaseClient.PlayerCollection.Find(
            Builders<Player>.Filter.Exists(x => x.Id)
        ).ToList();

        var countries = DataBaseClient.CountryCollection.Find(
            Builders<Country>.Filter.Exists(x => x.Id)
        ).ToList();

        return new (players, countries);
    }
}