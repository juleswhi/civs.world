namespace SharedClasses.Models.ArmyModels.SoldierTypes;

public class FootSoldier
{
    public FootSoldier(int tier) {
        Range = Range + (tier * TierModifier);
    }

    public int TierModifier { get; set; } = 2;
    public int RelativeSoldierRating { get; set; }

    public static int Range { get; set; } = BaseRange;
    public static int Speed { get; set; } = BaseSpeed;
    public static int AttackSpeed { get; set; } = BaseAttackSpeed;
    public static int Durability { get; set; } = BaseDurability;

    public static int BaseRange { get; set; } = 10;
    public static int BaseSpeed { get; set; } = 10;
    public static int BaseAttackSpeed { get; set; } = 10;
    public static int BaseDurability { get; set; } = 10;

}
