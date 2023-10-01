namespace SharedClasses.Models.ArmyModels;

public interface ISoldier {

    public int Profeciency { get; set; }
    public SoldierType Type { get; set; }

    public int Range { get; set; }
    public int Speed { get; set; }
    public int AttackSpeed { get; set; }
    public int Durability { get; set; }
    public int RelativeSoldierRating { get; set; }
    public int Tier { get; set; }
}
