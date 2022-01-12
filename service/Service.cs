using hotelexercise.model;
using hotelexercise.utils;

namespace hotelexercise.service
{
    public class Service
    {   
        public double calculateBookingHotel(Booking booking, Hotel hotel){
            double valueBookingWeekendDays = returnValueBookingWeekendDays(booking.Dates, booking.TypeClient == Client.Fidelidade ? 
                                                                                    hotel.ValueWeekendDaysReward : hotel.ValueWeekendDaysRegular);
            double valueBookingWeekDays = returnValueBookingWeekDays(booking.Dates, booking.TypeClient == Client.Fidelidade ? 
                                                                                    hotel.ValueWeekDaysReward : hotel.ValueWeekDaysRegular);

            return valueBookingWeekendDays + valueBookingWeekDays;
        }

        public List<Hotel> loadingHotel(){
            List<Hotel> hoteis = new List<Hotel>();
            hoteis.Add(new Hotel(name: "Parque das flores", rating: 3, valueWeekDaysRegular: 110,
                                valueWeekendDaysRegular: 90, valueWeekDaysReward: 80, valueWeekendDaysReward: 80));
            hoteis.Add(new Hotel(name: "Jardim Botânico", rating: 4, valueWeekDaysRegular: 160,
                                valueWeekendDaysRegular: 60, valueWeekDaysReward: 110, valueWeekendDaysReward: 50));
            hoteis.Add(new Hotel(name: "Mar Atlântico", rating: 5, valueWeekDaysRegular: 220,
                                valueWeekendDaysRegular: 150, valueWeekDaysReward: 100, valueWeekendDaysReward: 40));

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

        public string returnBestHotelBooking(Booking booking){
            List<Hotel> hoteis = loadingHotel();
            Hotel bestBookingHotel = hoteis[0];
            double bestBookingValue = double.MaxValue;
            foreach(Hotel hotel in hoteis){
                double calculateBookingValue = calculateBookingHotel(booking, hotel);
                if(calculateBookingValue < bestBookingValue){
                    bestBookingHotel = hotel;
                    bestBookingValue = calculateBookingValue;
                }else if(calculateBookingValue == bestBookingValue){
                    bestBookingHotel = hotel.Rating > bestBookingHotel.Rating ? hotel : bestBookingHotel;
                }
            }
            return bestBookingHotel.Name;
        }
    }
}