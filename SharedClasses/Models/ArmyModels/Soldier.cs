using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedClasses.Models.ArmyModels;

    public class Soldier : ITrainable
    {

        public Soldier()
        {   
            Id = Guid.NewGuid();
            Rating = new SoldierRating();
        }


        private Guid Id { get; set; }
        public SoldierRating Rating { get; set; }

        public async Task Train(Func<Soldier, SoldierRating> rating, TimeSpan length)
        {
            // Increments soldier's rating based on length 

            await Task.Delay(length);

            var oldRating = Rating;

            Rating = new SoldierRating()
            {
                Intelligence = oldRating.Intelligence += (int) length.TotalSeconds,
                Strength = oldRating.Strength += (int) length.TotalSeconds,
                Speed = oldRating.Speed += (int) length.TotalSeconds,
                Intuition = oldRating.Intuition += (int) length.TotalSeconds,
                Strategy = oldRating.Strategy += (int) length.TotalSeconds,
                Overrall = oldRating.Overrall += (int) length.TotalSeconds
            };
        }
    }