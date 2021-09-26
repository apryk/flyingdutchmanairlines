using System;
using System.Threading.Tasks;
using FlyingDutchmanAirlines.DatabaseLayer;
using FlyingDutchmanAirlines.DatabaseLayer.Models;
using FlyingDutchmanAirlines.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FlyingDutchmanAirlines.RepositoryLayer
{
    public class AirportRepository
    {
        private readonly FlyingDutchmanAirlinesContext _context;

        public AirportRepository(FlyingDutchmanAirlinesContext context)
        {
            _context = context;
        }

        public async Task<Airport> GetAirportByID(int airportID)
        {
            if (airportID < 0)
            {
                Console.WriteLine($"Argument Exception in GetAirportByIDL AirportID = {airportID}");
                throw new ArgumentException("invalid argument provided");
            }

            //return new Airport();
            return await _context.Airports.FirstOrDefaultAsync(a => a.AirportId == airportID)
                ?? throw new AirportNotFoundException();
        }
    }
}
