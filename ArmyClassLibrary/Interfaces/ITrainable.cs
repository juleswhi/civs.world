using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyClassLibrary.Interfaces
{
    public interface ITrainable
    {
        public SoldierRating Rating { get; set; }

        public abstract Task Train(
        Func<ITrainable, SoldierRating> rating,
        TimeSpan length
        );
        

        
    }
}