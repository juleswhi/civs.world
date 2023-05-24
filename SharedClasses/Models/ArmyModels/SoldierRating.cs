namespace SharedClasses.Models.ArmyModels;

    public struct SoldierRating
    {
        public SoldierRating(Random seed)
        {

        }
        public int Strength { get; set; } = 5;
        public int Speed { get; set; } = 5;
        public int Intelligence { get; set; } = 5;
        public int Intuition { get; set; } = 5;
        public int Strategy { get; set; } = 5;
        public int Overrall { get; set; } = 5;
    }
