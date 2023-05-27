namespace SharedClasses.Models.AllianceModels;
public class Alliance
{
    public Alliance()
    {
       Id = Guid.NewGuid(); 
    }
    public Guid Id { get; set; }
    public required string Name { get; set; } = String.Empty;

    public List<Guid> AllianceMembers { get; set; } = new();

    public async Task<List<Player>> GetAllianceMembers()
    {
        List<Player> Players = new();

        var results = await DataBaseClient.PlayerCollection.FindAsync(
            Builders<Player>.Filter.Exists(x => x.Id)
        );
        var i = 0;
        await results.ForEachAsync<Player>((x) => {
            if(x.Id == AllianceMembers[i])
                Players.Add(x);
                i++;
        });

        return Players;
    }

    public static async Task<Code> CreateAlliance(string name)
    {
        var alliance = new Alliance()
        {
            Name = name
        };

        var result = await DataBaseClient.AllianceCollection.FindAsync(
            Builders<Alliance>.Filter.Eq(x => x.Name, name)
        );

        if(await result.FirstOrDefaultAsync() is not null)
            return Code.ExistingAccount;

        await DataBaseClient.AllianceCollection.InsertOneAsync(alliance);

        return Code.Ok;
    }

    public async Task<Code> AddAllianceMember(Player player)
    {
        var thisAllianceFilter = Builders<Alliance>.Filter.Eq(x => x.Id, Id);

        var foundPlayer = await DataBaseClient.PlayerCollection.FindAsync(
            Builders<Player>.Filter.Eq(x => x.Id, player.Id)
        );

        if(foundPlayer.FirstOrDefaultAsync() is null) return Code.AccountNotFound;

        Guid playerId = ((Player)foundPlayer).Id;

        this.AllianceMembers.Add(playerId);

        await DataBaseClient.AllianceCollection.UpdateOneAsync(
            thisAllianceFilter,
            Builders<Alliance>.Update.Set(x => x.AllianceMembers, this.AllianceMembers)
        );

        return Code.Ok;

    }


}