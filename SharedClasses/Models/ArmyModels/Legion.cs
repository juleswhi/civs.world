
namespace SharedClasses.Models.ArmyModels;
public class Legion {

    public Legion(Guid ArmyGuid) {
        Marker = new LegionMarker(ArmyGuid);
    }

    [BsonElement]
    public List<Soldier> Troops { get; set; } = new();

    [BsonElement]
    public int Tier { get; set; }

    [BsonElement]
    public LegionMarker Marker { get; set; }

}


