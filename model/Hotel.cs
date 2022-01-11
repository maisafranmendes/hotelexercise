namespace hotelexercise.model
{
    public class Hotel
    {
        private string? name;
        private int rating;
        private double valueWeekDaysRegular;
        private double valueWeekendDaysRegular;
        private double valueWeekDaysReward;
        private double valueWeekendDaysReward;

        public Hotel(string name, int rating, double valueWeekDaysRegular, 
                double valueWeekendDaysRegular, double valueWeekDaysReward, double valueWeekendDaysReward ){
            this.name = name;
            this.rating = rating;
            this.valueWeekDaysRegular = valueWeekDaysRegular;
            this.valueWeekendDaysRegular = valueWeekendDaysRegular;
            this.valueWeekDaysReward = valueWeekDaysReward;
            this.valueWeekendDaysReward = valueWeekendDaysReward;
        }

        public string Name { get => name; set => name = value; }
        public int Rating { get => rating; set => rating = value; }
        public double ValueWeekDaysRegular { get => valueWeekDaysRegular; set => valueWeekDaysRegular = value; }
        public double ValueWeekendDaysRegular { get => valueWeekendDaysRegular; set => valueWeekendDaysRegular = value; }
        public double ValueWeekendDaysReward { get => valueWeekendDaysReward; set => valueWeekendDaysReward = value; }
        public double ValueWeekDaysReward { get => valueWeekDaysReward; set => valueWeekDaysReward = value; }

    }
}