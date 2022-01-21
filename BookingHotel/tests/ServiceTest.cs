using Xunit;
using BookingHotel.model;
using BookingHotel.service;
using BookingHotel.utils;
using System;

namespace BookingHotel.Tests
{
    public class ServiceTest
    {
        Service service;
        FormatInput formatInput;
        string inputWeekDays;
        string inputWithWeekendDays;
        string inputReward;
        Hotel hotel;

        public ServiceTest()
        {
            //given
            this.service = new Service();
            this.formatInput = new FormatInput();
            this.inputWeekDays = "Regular: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)";
            this.inputWithWeekendDays = "Regular: 20Mar2020(fri), 21Mar2020(sat), 22Mar2020(sun)";
            this.inputReward = "Reward: 26Mar2020(thur), 27Mar2020(fri), 28Mar2020(sat)";
            this.hotel = new Hotel(name: "Parque das flores", rating: 3, valueWeekDaysRegular: 110,
                                valueWeekendDaysRegular: 90, valueWeekDaysReward: 80, valueWeekendDaysReward: 80);
        }

        [Fact]
        public void shouldReturnBookingValueHotelToWeekDays()
        {
            //when 
            Booking booking = formatInput.getBookingByUserInput(inputWeekDays);
            double bookingValue = service.calculateBookingHotel(booking, hotel);

            //then 
            Assert.Equal(bookingValue, 330);
        }

        [Fact]
        public void shouldReturnBookingValueHotelToWeekendDays()
        {
            //when 
            Booking booking = formatInput.getBookingByUserInput(inputWithWeekendDays);
            double bookingValue = service.calculateBookingHotel(booking, hotel);

            //then 
            Assert.Equal(bookingValue, 290);
        }

        [Fact]
        public void shouldReturnBookingValueHotelReward()
        {
            //when 
            Booking booking = formatInput.getBookingByUserInput(inputReward);
            double bookingValue = service.calculateBookingHotel(booking, hotel);

            //then 
            Assert.Equal(bookingValue, 240);
        }

        [Fact]
        public void shouldReturnNameBestHotelBookingWhenWeekDays()
        {
            //when 
            Booking booking = formatInput.getBookingByUserInput(inputWeekDays);
            string nameBestHotelBooking = service.returnBestHotelBooking(booking);

            //then 
            Assert.Equal(nameBestHotelBooking, "Parque das flores");
        }

        [Fact]
        public void shouldReturnNameBestHotelBookingWhenWeekendDays()
        {
            //when 
            Booking booking = formatInput.getBookingByUserInput(inputWithWeekendDays);
            string nameBestHotelBooking = service.returnBestHotelBooking(booking);

            //then 
            Assert.Equal(nameBestHotelBooking, "Jardim Botânico");
        }

        [Fact]
        public void shouldReturnNameBestHotelBookingWhenClientRewardAndTiebreakerRating()
        {
            //when 
            Booking booking = formatInput.getBookingByUserInput(inputReward);
            string nameBestHotelBooking = service.returnBestHotelBooking(booking);

            //then 
            Assert.Equal(nameBestHotelBooking, "Mar Atlântico");
        }
    }

}