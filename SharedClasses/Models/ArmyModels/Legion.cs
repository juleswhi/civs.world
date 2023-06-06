
namespace SharedClasses.Models.ArmyModels;
public class Legion {

    [BsonElement]
    public List<Soldier> Troops { get; set; } = new();

    [BsonElement]
    public int Tier { get; set; }

    [BsonElement]
    public LegionMarker Marker { get; set; }

}


