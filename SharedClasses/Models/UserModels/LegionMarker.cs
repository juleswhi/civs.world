namespace SharedClasses.Models.UserModels;

public class LegionMarker {
    public LegionMarker(Guid ArmyGuid) {
        ArmyGuid = ArmyId;
    } 

    public Guid ArmyId { get; set; }
    public string Name { get; set; } = String.Empty;
    public int[] latLng { get; set; } = new int[2];
    public SoldierType LegionType { get; set; }
}
