using BookingHotel.model;

namespace BookingHotel.model
{
    public class Booking
    {
        private List<DateTime> dates;
        private string? typeClient;

        public string TypeClient { get => typeClient; set => typeClient = value; }
        public List<DateTime> Dates { get => dates; set => dates = value; }
    }
}