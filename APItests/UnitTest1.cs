using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Bson;
using BackEnd.Models;
using BackEnd.Services;
using System.Threading.Tasks;
using System.Linq;

namespace APItests
{
    [TestClass]
    public class CustomerTests
    {
        //[TestCleanup]
        //public void TearDown()
        //{
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    client.DropDatabase("ScreenWizard");
        //}

        [TestMethod]
        public async Task CreateCustomer()
        {
            
            var objId = ObjectId.GenerateNewId();
            var customer = new Customer
            {
                CustomerId = objId,
                 Name = "Test Guy",
                 Email = "Testguy@gmail.com",
                 ContactNumber = "647 647 6647",
                 Website = "www.website.com",
                 Notes = "Brah"
            };

            var objId2 = ObjectId.GenerateNewId();
            var customer2 = new Customer
            {
                CustomerId = objId2,
                Name = "Test Guy2",
                Email = "Testguy2@gmail.com",
                ContactNumber = "2222222222",
                Website = "www.website222.com",
                Notes = "Brah222"
            };

            var  service = new CustomerService();
            await service.Create(customer);
            await service.Create(customer2);

            var result = await service.All();

            Assert.IsNotNull(result);
            var list = result.ToList();
            Assert.AreEqual(list[0].Name, "Test Guy");
            Assert.AreEqual(list[1].Name, "Test Guy2");
        }


}
}
