namespace SharedClasses.Models.ArmyModels.SoldierTypes;

public interface ISoldierType 
{
    public int TierModifier { get; set; }
    public static int RelativeSoldierRating { get; set; }

    public static int Range { get; set; } 
    public static int Speed { get; set; }
    public static int AttackSpeed { get; set; } 
    public static int Durability { get; set; }

    public static int BaseRange { get; set; }
    public static int BaseSpeed { get; set; }
    public static int BaseAttackSpeed { get; set; }
    public static int BaseDurability { get; set; }
}
