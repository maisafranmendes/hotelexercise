using Xunit;
using hotelexercise.model;
using hotelexercise.service;

namespace hotelexercise.tests.ServiceTest
{
    public class ServiceTest
    {

        [Fact]
        public void shouldReturnABookingWhenTheUserSentValidParamenters() {
            //given
            Service service = new Service();
            string input = "Regular: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";

            //when 
            Booking booking = service.getBookingByUserInput(input);

            //then 
            Assert.True(booking is Booking);//booking.insteadOf(Booking)
            Assert.Equal(booking.TypeClient, "Regular");
            Assert.Equal(booking.Dates, new List<DateTime>{new DateTime(2020,03,16), new DateTime(2020,03,17), new DateTime(2020,03,18)});
        }
    }
}