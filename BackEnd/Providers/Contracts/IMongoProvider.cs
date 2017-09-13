using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using System;

namespace BackEnd.Providers.Contracts
{
    public interface IMongoProvider
    {
        Task<bool> Delete<T>(string collectionName, object id);
        Task<T> Find<T>(string collectionName, object id);
        Task<IEnumerable<T>> GetAll<T>(string collectionName);
        IMongoCollection<T> GetCollection<T>(string collectionName);
        Task Upsert<T>(string collectionName, T payload, object id = null);
    }
}
