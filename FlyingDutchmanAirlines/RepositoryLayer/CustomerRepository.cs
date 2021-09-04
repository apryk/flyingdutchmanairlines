using System;
using System.Linq;
using System.Threading.Tasks;
using FlyingDutchmanAirlines.DatabaseLayer;
using FlyingDutchmanAirlines.DatabaseLayer.Models;

namespace FlyingDutchmanAirlines.RepositoryLayer
{
    public class CustomerRepository
    {
        private bool IsInvalidCustomerName(string name)
        {
            char[] forbiddenCharacters = { '!', '@', '#', '$', '%', '&', '*' };
            return string.IsNullOrEmpty(name) || name.Any(x => forbiddenCharacters.Contains(x));
        }

        public async Task<bool> CreateCustomer(string name)
        {
            if (IsInvalidCustomerName(name))
                return false;
            var customer = new Customer(name);
            using(FlyingDutchmanAirlinesContext ctx = new FlyingDutchmanAirlinesContext())
            {
                if (await ctx.Database.CanConnectAsync() == false)
                    throw new Exception("Cant connect to database");
                await ctx.Database.EnsureCreatedAsync();
                ctx.Customers.Add(customer);
                await ctx.SaveChangesAsync();
            }

            return true;
        }
    }
}
