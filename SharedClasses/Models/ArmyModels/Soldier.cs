namespace SharedClasses.Models.ArmyModels;

public class Soldier 
{
    [BsonElement]
    public SoldierType Type { get; set; }
    [BsonElement]
    public int Profeciency { get; set; }
    [BsonElement]
    public int Range { get; set; }
    [BsonElement]
    public int Speed { get; set; }
    [BsonElement]
    public int AttackSpeed { get; set; }
    [BsonElement]
    public int Durability { get; set; }
    [BsonElement]
    public int RelativeSoldierRating { get; set; }
    [BsonElement]
    public int Tier { get; set; }


}
