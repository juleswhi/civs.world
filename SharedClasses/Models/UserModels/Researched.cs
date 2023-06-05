namespace SharedClasses.Models.UserModels;

public class Researched {
    [BsonElement]
    public List<SoldierType> SoldierTypes { get; set; }
}
