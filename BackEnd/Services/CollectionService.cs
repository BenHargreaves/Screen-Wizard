using BackEnd.Providers;
using BackEnd.Services.Contracts;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly MongoProvider _mongoProvider;

        public CollectionService()
        {
            _mongoProvider = new MongoProvider("ScreenWizard");
        }

        public async Task<List<string>> GetCollections()
        {
            try
            {
                return await _mongoProvider.GetCollections();
                //var test = result.ToBsonDocument<BsonArray>();
                //return test;
            }
            catch (Exception ex)
            {
                throw;
            }
        
        }
    }
}
