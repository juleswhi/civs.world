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
            System.Console.WriteLine($"Soldier: {Id} has been trained and Now has a Rating of {Rating.Overrall}");
        }
    }
}
