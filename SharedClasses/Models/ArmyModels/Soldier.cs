namespace SharedClasses.Models.ArmyModels;
public struct Soldier
{
    [BsonId]
    public int SoldierRating { get; set; }

    [BsonId]
    public SoldierType SoldierType { get; set; }

}