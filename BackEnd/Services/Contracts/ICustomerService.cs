using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Models;
using MongoDB.Bson;

namespace BackEnd.Services.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> All();
        Task<bool> Delete(ObjectId id);
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Find(ObjectId id);
    }
}
