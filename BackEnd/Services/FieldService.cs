using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Services.Contracts;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Reflection;
using BackEnd.Providers;

namespace BackEnd.Services
{
    public class FieldService : IFieldService
    {

        private readonly MongoProvider _mongoProvider;

        public FieldService()
        {
            _mongoProvider = new MongoProvider("ScreenWizard");
        }
        public async Task<IEnumerable<FieldMetadata>> All(string collectionName)
        {
            try
            {
                return await _mongoProvider.GetFields<FieldMetadata>(collectionName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
