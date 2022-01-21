using Xunit;
using BookingHotel.utils;
using BookingHotel.model;
using System;
using System.Collections.Generic;

namespace BookingHotel.Tests
{
    public class FormatInputTest
    {
        FormatInput formatInput;
        string input;
        string inputDate;
        string inputDates;

        public FormatInputTest()
        {
            this.formatInput = new FormatInput();
            this.input = "Regular: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            this.inputDate = "16Mar2020(mon)";
            this.inputDates = "16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
        }

        [Fact]
        public void shouldReturnABookingWhenTheUserSentValidParamenters()
        {
            //when 
            Booking booking = formatInput.getBookingByUserInput(input);

            //then 
            Assert.True(booking is Booking);
            Assert.Equal(booking.TypeClient, "Regular");
            Assert.Equal(booking.Dates, new List<DateTime> { new DateTime(2020, 03, 16), new DateTime(2020, 03, 17), new DateTime(2020, 03, 18) });
        }

        [Fact]
        public void shouldReturnNumberOfMonth()
        {
            //when 
            int numberOfMonth = formatInput.returnMonthRef(inputDate);

            //then 
            Assert.Equal(numberOfMonth, 3);
        }

        [Fact]
        public void shouldReturnBookingDates()
        {
            //when 
            List<DateTime> dates = formatInput.getDatesByUserInput(inputDates);

            //then 
            Assert.Equal(dates, new List<DateTime> { new DateTime(2020, 03, 16), new DateTime(2020, 03, 17), new DateTime(2020, 03, 18) });
        }
    }

}
