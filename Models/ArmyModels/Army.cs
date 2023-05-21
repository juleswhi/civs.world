using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Models.ArmyModels;
    public class Army : ITrainable
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<Soldier> Soldiers { get; set; } = new List<Soldier>();

        public int Rating { get; set; }

        public async Task Train(Func<Soldier, SoldierRating> rating, TimeSpan length)
        {
            foreach(var soldier in Soldiers)
            {
                await soldier.Train(x => x.Rating, length * 1000);
            }
        }

        public void EvaluateRating()
        {
            var sum = 0;
            foreach(var soldier in Soldiers)
            {
               sum += soldier.Rating.Overrall; 
            }

            Rating = sum;
        }
        


    }