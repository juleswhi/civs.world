using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmyClassLibrary.Interfaces;

namespace ArmyClassLibrary 
{
    public class Army : ITrainable
    {
        public List<Soldier> Soldiers { get; set; } = new List<Soldier>();

        public int Rating { get; set; }

        public async Task Train(Func<Soldier, SoldierRating> rating, TimeSpan length)
        {
            foreach(var soldier in Soldiers)
            {
                await soldier.Train(x => x.Rating, length);
            }
        }

        private void EvaluateRating()
        {
            var sum = 0;
            foreach(var soldier in Soldiers)
            {
               sum += soldier.Rating.Overrall; 
            }

            Rating = sum;
        }
        


    }
}