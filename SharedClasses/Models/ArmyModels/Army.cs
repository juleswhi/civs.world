namespace SharedClasses.Models.ArmyModels;

public class Army
{
    public Army(Guid PlayerId)
    {
        this.PlayerId = PlayerId;
        this.Id = Guid.NewGuid();
        Forces = new List<Soldier>();
    }


    [BsonElement]
    public Guid Id { get; set; }

    [BsonElement]
    public Guid PlayerId { get; set; }

    [BsonElement]
    public IEnumerable<Soldier> Forces { get; set; }

}