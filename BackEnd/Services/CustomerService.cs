using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Services.Contracts;
using BackEnd.Models;
using BackEnd.Providers;
using MongoDB.Bson;

namespace BackEnd.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MongoProvider _mongoProvider;

        public CustomerService()
        {
            _mongoProvider = new MongoProvider("ScreenWizard");
        }

        public async Task<IEnumerable<Customer>> All()
        {
            try
            {
                return await _mongoProvider.GetAll<Customer>(Customer.CollectionName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> Create(Customer customer)
        {
            try
            {
                await _mongoProvider.Upsert<Customer>(Customer.CollectionName, customer).ConfigureAwait(false);
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(ObjectId id)
        {
            try
            {
                return await _mongoProvider.Delete<Customer>(Customer.CollectionName, id).ConfigureAwait(false);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> Find(ObjectId id)
        {
            try
            {
                return await _mongoProvider.Find<Customer>(Customer.CollectionName, id).ConfigureAwait(false);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> Update(Customer customer)
        {
            try
            {
                await _mongoProvider.Upsert<Customer>(Customer.CollectionName, customer, customer.CustomerId).ConfigureAwait(false);
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
