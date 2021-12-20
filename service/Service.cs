using hotelexercise.model;

namespace hotelexercise.service
{
    public enum Months{
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 8,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12
    }

    public class Service{
        
        private List<Hotel> hoteis;

        //public string RetornaMelhorReserva(listaDias, hotel);//retorna nome do hotel
        public int returnMonthRef(string date){
            string month = date.Substring(2,3);
            for(int i = ((int)Months.Jan); i < ((int)Months.Dec); i++){
                if(month == Enum.GetName(typeof(Months), i)){
                    return i;
                }
            }
            return 0;
        }

        public List<DateTime> getDatesByUserInput(string datesInput){
            List<DateTime> dates = new List<DateTime>();
            string[] separetedDatesInput = datesInput.Split(',');
            for(int i = 0; i < separetedDatesInput.Length; i++){
                separetedDatesInput[i] = separetedDatesInput[i].Trim();
                dates.Add(new DateTime(Convert.ToInt16(separetedDatesInput[i].Substring(5,4)),
                                        returnMonthRef(separetedDatesInput[i]),
                                        Convert.ToInt16(separetedDatesInput[i].Substring(0,2))));
            }
            return dates;
        }

        public Booking getBookingByUserInput(string input){
            Booking booking = new Booking();
            string[] separetedInput = input.Split(':');
            string typeClientInput = separetedInput[0];
            string datesInput = separetedInput[1];
            booking.TypeClient = typeClientInput.Trim();
            booking.Dates = getDatesByUserInput(datesInput);
            return booking;
        }
    }
}