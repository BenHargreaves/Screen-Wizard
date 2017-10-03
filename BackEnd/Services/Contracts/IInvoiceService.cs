using BackEnd.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> All();
        Task<bool> Delete(ObjectId id);
        Task<Invoice> Create(Invoice invoice);
        Task<Invoice> Update(Invoice invoice);
        Task<Invoice> Find(ObjectId id);
    }
}
