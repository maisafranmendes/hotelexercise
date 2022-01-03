using Xunit;
using hotelexercise.model;
using hotelexercise.service;
using System;

namespace hotelexercise.tests.ServiceTest
{
    public class ServiceTest
    {
        Service service;
        string inputWeekDays;
        string inputWithWeekendDays;
        string inputFidelidade;
        Hotel hotel;

        public ServiceTest(){
            //given
            this.service = new Service();
            this.inputWeekDays = "Regular: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            this.inputWithWeekendDays = "Regular: 20Mar2020(fri), 21Mar2020(sat), 22Mar2020(sun)";
            this.inputFidelidade = "Fidelidade: 25Mar2020(thur), 27Mar2020(fri), 28Mar2020(sat)";
            this.hotel = new Hotel(nome: "Parque das flores", classificacao: 3, valorDiaDeSemanaRegular: 110,
                                valorFimDeSemanaRegular: 90, valorDiaDeSemanaFidelidade: 80, valorFimDeSemanaFidelidade: 80);
        }

        [Fact]
        public void shouldReturnABookingWhenTheUserSentValidParamenters() {
            //when 
            Booking booking = service.getBookingByUserInput(inputWeekDays);

            //then 
            Assert.True(booking is Booking);
            Assert.Equal(booking.TypeClient, "Regular");
            Assert.Equal(booking.Dates, new List<DateTime>{new DateTime(2020,03,16), new DateTime(2020,03,17), new DateTime(2020,03,18)});
        }


       [Fact]
        public void shouldReturnBookingValueHotelToWeekDays() {
            //when 
            Booking booking = service.getBookingByUserInput(inputWeekDays);
            double bookingValue = service.calculateBookingHotel(booking, hotel);

            //then 
            Assert.Equal(bookingValue, 330);
        }

        [Fact]
        public void shouldReturnBookingValueHotelToWeekendDays() {
            //when 
            Booking booking = service.getBookingByUserInput(inputWithWeekendDays);
            double bookingValue = service.calculateBookingHotel(booking, hotel);

            //then 
            Assert.Equal(bookingValue, 290);
        }

        [Fact]
        public void shouldReturnBookingValueHotelFidelidade() {
            //when 
            Booking booking = service.getBookingByUserInput(inputFidelidade);
            double bookingValue = service.calculateBookingHotel(booking, hotel);

            //then 
            Assert.Equal(bookingValue, 240);
        }

        //retornar mais barato
        //se der empate considerar o q possui maior classificação
    }
}