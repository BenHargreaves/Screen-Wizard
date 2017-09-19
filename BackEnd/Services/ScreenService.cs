using BackEnd.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Providers;
using MongoDB.Bson;

namespace BackEnd.Services
{
    public class ScreenService : IScreenService
    {
        private readonly MongoProvider _mongoProvider;

        public ScreenService()
        {
            _mongoProvider = new MongoProvider("ScreenWizard");
        }

        public async Task<IEnumerable<ScreenMetadata>> All()
        {
            try
            {
                return await _mongoProvider.GetAll<ScreenMetadata>(ScreenMetadata.CollectionName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ScreenMetadata> Create(ScreenMetadata screenMetadata)
        {
            try
            {
                await _mongoProvider.Upsert<ScreenMetadata>(ScreenMetadata.CollectionName, screenMetadata).ConfigureAwait(false);
                return screenMetadata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ScreenMetadata> Find(ObjectId id)
        {
            try
            {
                return await _mongoProvider.Find<ScreenMetadata>(ScreenMetadata.CollectionName, id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
