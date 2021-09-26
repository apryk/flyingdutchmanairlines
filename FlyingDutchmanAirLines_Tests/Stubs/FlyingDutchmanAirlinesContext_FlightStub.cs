using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FlyingDutchmanAirlines.DatabaseLayer;
using FlyingDutchmanAirlines.DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlyingDutchmanAirLines_Tests.Stubs
{
    public class FlyingDutchmanAirlinesContext_FlightStub : FlyingDutchmanAirlinesContext
    {
        public FlyingDutchmanAirlinesContext_FlightStub(DbContextOptions<FlyingDutchmanAirlinesContext> options)
            : base(options)
        {
            base.Database.EnsureDeleted();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //IEnumerable<EntityEntry> pendingChanges = ChangeTracker.Entries()
            //    .Where(e => e.State == EntityState.Added);

            //IEnumerable<Airport> airports = pendingChanges.Select(e => e.Entity).OfType<Airport>();

            //if (airports.Any(a => a.AirportId == 10))
            //    throw new Exception("Database Error");


            await base.SaveChangesAsync(cancellationToken);
            return 1;

        }
    }
}
