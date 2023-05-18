using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyClassLibrary.Interfaces;

namespace ArmyClassLibrary
{
    public class Soldier : ITrainable
    {
        static Random rng = new Random(420);
        public Soldier()
        {   
            Id = Guid.NewGuid();
            Rating = new SoldierRating();
        }
        private Guid Id { get; set; }
        public SoldierRating Rating { get; set; }

        public async Task Train(Func<ITrainable, SoldierRating> rating, TimeSpan length)
        {
            System.Console.WriteLine($"Training Soldier {Id}");
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
            System.Console.WriteLine($"Soldier: {Id} has been trained\nAnd Now has a Rating of {Rating.Overrall}");
        }
    }
}
