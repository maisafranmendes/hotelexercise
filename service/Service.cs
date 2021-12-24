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
                                        returnMonthRef(separetedDatesInput[i]),//fazer classe utils p formataçao
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

        public double calculateBookingHotel(Booking booking, Hotel hotel){
            double valueBookingWeekendDays = returnValueBookingWeekendDays(booking.Dates, booking.TypeClient == Client.Fidelidade ? 
                                                                                    hotel.ValorFimDeSemanaFidelidade : hotel.ValorFimDeSemanaRegular);
            double valueBookingWeekDays = returnValueBookingWeekDays(booking.Dates, booking.TypeClient == Client.Fidelidade ? 
                                                                                    hotel.ValorDiaDeSemanaFidelidade : hotel.ValorDiaDeSemanaRegular);

            return valueBookingWeekendDays + valueBookingWeekDays;
        }

        public List<Hotel> loadingHotel(){
            List<Hotel> hoteis = new List<Hotel>();
            hoteis.Add(new Hotel(nome: "Parque das flores", classificacao: 3, valorDiaDeSemanaRegular: 110,
                                valorFimDeSemanaRegular: 90, valorDiaDeSemanaFidelidade: 80, valorFimDeSemanaFidelidade: 80));
            hoteis.Add(new Hotel(nome: "Jardim Botânico", classificacao: 4, valorDiaDeSemanaRegular: 160,
                                valorFimDeSemanaRegular: 60, valorDiaDeSemanaFidelidade: 110, valorFimDeSemanaFidelidade: 50));
            hoteis.Add(new Hotel(nome: "Mar Atlântico", classificacao: 5, valorDiaDeSemanaRegular: 220,
                                valorFimDeSemanaRegular: 150, valorDiaDeSemanaFidelidade: 100, valorFimDeSemanaFidelidade: 40));

            return hoteis;
        }

        public double returnValueBookingWeekendDays(List<DateTime> bookingDays, double priceBookingHotel){
            int countWeekendDays = 0;
            foreach(DateTime day in bookingDays){
                if(day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday){
                    countWeekendDays++;
                }
            }
            return countWeekendDays * priceBookingHotel;
        }

        public double returnValueBookingWeekDays(List<DateTime> bookingDays, double priceBookingHotel){
            int countWeekDays = 0;
            foreach(DateTime day in bookingDays){
                if(day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday){
                    countWeekDays++;
                }
            }
            return countWeekDays * priceBookingHotel;
        }
    }
}