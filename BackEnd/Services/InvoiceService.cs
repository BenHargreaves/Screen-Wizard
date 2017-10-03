using BackEnd.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Models;
using MongoDB.Bson;
using BackEnd.Providers;

namespace BackEnd.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly MongoProvider _mongoProvider;

        public InvoiceService()
        {
            _mongoProvider = new MongoProvider("ScreenWizard");
        }
        public async Task<IEnumerable<Invoice>> All()
        {
            try
            {
                return await _mongoProvider.GetAll<Invoice>(Invoice.CollectionName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Invoice> Create(Invoice invoice)
        {
            try
            {
                await _mongoProvider.Upsert<Invoice>(Invoice.CollectionName, invoice).ConfigureAwait(false);
                return invoice;
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
                return await _mongoProvider.Delete<Invoice>(Invoice.CollectionName, id).ConfigureAwait(false);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Invoice> Find(ObjectId id)
        {
           try
            {
                return await _mongoProvider.Find<Invoice>(Invoice.CollectionName, id).ConfigureAwait(false);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Invoice> Update(Invoice invoice)
        {
            try
            {
                await _mongoProvider.Upsert<Invoice>(Invoice.CollectionName, invoice, invoice._id).ConfigureAwait(false);
                return invoice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
