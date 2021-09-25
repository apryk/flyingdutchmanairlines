using System;
using System.Threading.Tasks;
using FlyingDutchmanAirlines.DatabaseLayer;
using FlyingDutchmanAirlines.DatabaseLayer.Models;
using FlyingDutchmanAirlines.Exceptions;

namespace FlyingDutchmanAirlines.RepositoryLayer
{
    public class BookingRepository
    {
        private readonly FlyingDutchmanAirlinesContext _context;

        public BookingRepository(FlyingDutchmanAirlinesContext context)
        {
            _context = context;
        }

        public async Task CreateBooking(int customerID, int flightNumber)
        {
            if (customerID < 0 || flightNumber < 0)
            {
                Console.WriteLine($"Argument Exception in CreateBooking! " +
                    $"CustomerID = {customerID}, flightNumber = {flightNumber}");
                throw new ArgumentException("Invalid arguments provided");
            }

            var booking = new Booking
            {
                CustomerId = customerID,
                FlightNumber = flightNumber
            };

            try
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during database query {ex.Message}");
                throw new CouldNotAddEntityToDatabaseException();
            }
        }
    }
}
