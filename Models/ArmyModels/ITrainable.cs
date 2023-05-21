using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.ArmyModels;
    public interface ITrainable
    {

        public abstract Task Train(
        Func<Soldier, SoldierRating> rating,
        TimeSpan length
        );
        

        
    }