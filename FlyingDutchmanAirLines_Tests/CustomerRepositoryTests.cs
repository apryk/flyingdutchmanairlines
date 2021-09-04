using System.Threading.Tasks;
using FlyingDutchmanAirlines.RepositoryLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlyingDutchmanAirLines_Tests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        [TestMethod]
        public async Task CreateCustomer_Success()
        {
            CustomerRepository repository = new CustomerRepository();
            Assert.IsNotNull(repository);

            bool result = await repository.CreateCustomer("Donald Knuth");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CreateCustomer_Failure_NameIsNull()
        {
            CustomerRepository repository = new CustomerRepository();
            Assert.IsNotNull(repository);

            bool result = await repository.CreateCustomer(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CreateCustomer_Failure_NameIsEmptyString()
        {
            CustomerRepository repository = new CustomerRepository();
            Assert.IsNotNull(repository);

            bool result = await repository.CreateCustomer("");
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow('#')]
        [DataRow('$')]
        [DataRow('%')]
        [DataRow('&')]
        [DataRow('*')]
        public async Task CreateCustomer_Failure_NameContainsInvalidCharacters(char invalidCharacter)
        {
            CustomerRepository repository = new CustomerRepository();
            Assert.IsNotNull(repository);

            bool result = await repository.CreateCustomer("Donald Knuth" + invalidCharacter);
            Assert.IsFalse(result);
        }

    }
}
