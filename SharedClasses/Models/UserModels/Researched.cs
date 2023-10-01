namespace SharedClasses.Models.UserModels;

public class Researched {

    public Researched() {
        SoldierTypes = new();
        SoldierTypes.Add(SoldierType.FootSoldier);
    }


    [BsonElement]
    public List<SoldierType> SoldierTypes { get; set; }
}
