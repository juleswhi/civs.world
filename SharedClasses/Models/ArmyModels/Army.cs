
namespace SharedClasses.Models.ArmyModels;

public class Army
{
    public Army()
    {
        this.Id = Guid.NewGuid();
        Forces = new List<Legion>();
    }

    [BsonElement]
    public Guid Id { get; set; }

    [BsonElement]
    public Guid PlayerId { get; set; }

    [BsonElement]
    public List<Legion> Forces { get; set; }


}
