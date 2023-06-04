using SharedClasses.Models.ArmyModels.SoldierTypes;


namespace SharedClasses.Models.ArmyModels;

public class Army
{
    public Army()
    {
        this.Id = Guid.NewGuid();
        Forces = new List<Legion<ISoldier>>();
    }

    [BsonElement]
    public Guid Id { get; set; }

    [BsonElement]
    public Guid PlayerId { get; set; }

    [BsonElement]
    public List<Legion<ISoldier>> Forces { get; set; }


    public static void CreateArmy(Player player) {
        var army = new Army {
           PlayerId = player.Id 
        };
    }

    public void CreateLegion(SoldierType soldierType) {

        switch(soldierType) {

            case SoldierType.Basic:
                




                break;

            default:
                break;
        }
    }
}
