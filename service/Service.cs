using hotelexercise.model;

namespace hotelexercise.service
{
    public class Service{
        
        private List<Hotel> hoteis;

        //public string RetornaMelhorReserva(listaDias, hotel);//retorna nome do hotel

        public Booking getBookingByUserInput(string input){
            Booking booking = new Booking();

            return booking;
        }

        public List<DateTime> getTypeClientByUserInput(string input){
            List<DateTime> dates = null;
            
            return dates;
        }

        public string getDatesByUserInput(string input){
            string typeClient = "";
            
            return typeClient;
        }
    }
}