using System;
using System.Collections.Generic;

#nullable disable

namespace FlyingDutchmanAirlines.DatabaseLayer.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public Customer(string name)
        {
            Bookings = new HashSet<Booking>();
            Name = name;
        }
    }
}
