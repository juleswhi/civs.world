namespace SharedClasses.Helpers.CountryMapSerialisation;
public class PopulateMapDictionary
{

    public Dictionary<string, Dictionary<string, object>> PopulateDictionary()
    {
        var PlayerFilter = Builders<Player>.Filter.Exists(x => x.CountryId);
        var CountryFilter = Builders<Country>.Filter.Exists(x => x.CountryCode);

        var PlayerData = DataBaseClient.PlayerCollection.Find(PlayerFilter).ToList();
        var CountryData = DataBaseClient.CountryCollection.Find(CountryFilter).ToList();

        var valuesDictionary = new Dictionary<string, Dictionary<string, object>>();

        foreach(var mapData in CountryData)
        {
            var innerDictionary = new Dictionary<string,object>();

            innerDictionary.Add("Population", mapData.Population);


            foreach(var playerData in PlayerData)
            {
                if(playerData.CountryId == mapData.Id)
                    innerDictionary.Add("Name", playerData.Username);
            }

            valuesDictionary.Add(mapData.CountryCode, innerDictionary);
        }

        return valuesDictionary;


    }
}