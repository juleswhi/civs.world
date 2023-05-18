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

        public SoldierRating Rating { get; set; }

        public void ListArmy()
        {

        }

        public async Task Train(Func<ITrainable, SoldierRating> rating, TimeSpan length)
        {
            foreach(var soldier in Soldiers)
            {
                await soldier.Train(x => x.Rating, length);
            }
        }


        


    }
}