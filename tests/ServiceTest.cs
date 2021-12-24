using Xunit;
using hotelexercise.model;
using hotelexercise.service;
using System;

namespace hotelexercise.tests.ServiceTest
{
    public class ServiceTest//: IDisposable
    {
        Service service;
        string input;
        Hotel hotel;

        public ServiceTest(){
            //given
            this.service = new Service();
            this.input = "Regular: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            this.hotel = new Hotel(nome: "Parque das flores", classificacao: 3, valorDiaDeSemanaRegular: 110,
                                valorFimDeSemanaRegular: 90, valorDiaDeSemanaFidelidade: 80, valorFimDeSemanaFidelidade: 80);
        }

        [Fact]
        public void shouldReturnABookingWhenTheUserSentValidParamenters() {
            //when 
            Booking booking = service.getBookingByUserInput(input);

            //then 
            Assert.True(booking is Booking);
            Assert.Equal(booking.TypeClient, "Regular");
            Assert.Equal(booking.Dates, new List<DateTime>{new DateTime(2020,03,16), new DateTime(2020,03,17), new DateTime(2020,03,18)});
        }


       [Fact]
        public void shouldReturnBookingValueHotel() {
            //when 
            Booking booking = service.getBookingByUserInput(input);
            double bookingValue = service.calculateBookingHotel(booking, hotel);

            //then 
            Assert.Equal(bookingValue, 330);
        }
    }
}