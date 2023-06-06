
namespace SharedClasses.Models.ArmyModels;
public class Legion {

    public Legion(Guid ArmyGuid, string Color) {
        Marker = new LegionMarker(ArmyGuid, Color);
    }

    [BsonElement]
    public List<Soldier> Troops { get; set; } = new();

    [BsonElement]
    public int Tier { get; set; }

    [BsonElement]
    public LegionMarker Marker { get; set; }

}


