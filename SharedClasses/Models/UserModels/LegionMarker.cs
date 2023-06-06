namespace SharedClasses.Models.UserModels;

public class LegionMarker {
    public LegionMarker(Guid ArmyGuid, string Color) {
        ArmyGuid = ArmyId;
        this.Color = Color;
    } 

    public Guid ArmyId { get; set; }
    public string Name { get; set; } = String.Empty;
    public int[] latLng { get; set; } = new int[2];
    public SoldierType LegionType { get; set; }
    public string Color { get; set; }
}
