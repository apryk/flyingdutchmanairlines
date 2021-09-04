using System;
using System.Linq;
using System.Threading.Tasks;
using FlyingDutchmanAirlines.DatabaseLayer;
using FlyingDutchmanAirlines.DatabaseLayer.Models;

namespace FlyingDutchmanAirlines.RepositoryLayer
{
    public class CustomerRepository
    {
        private readonly FlyingDutchmanAirlinesContext _ctx;

        public CustomerRepository(FlyingDutchmanAirlinesContext ctx)
        {
            _ctx = ctx;
        }
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
            try
            {
                using (_ctx)
                {
                    if (await _ctx.Database.CanConnectAsync() == false)
                        throw new Exception("Cant connect to database");
                    await _ctx.Database.EnsureCreatedAsync();
                    _ctx.Customers.Add(customer);
                    await _ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            

            return true;
        }
    }
}
