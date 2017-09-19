using BackEnd.Models;
using BackEnd.Providers.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace BackEnd.Providers
{
    public class MongoProvider : IMongoProvider
    {
        private string _database;
        private static MongoClient _client;

        public MongoProvider (string database)
        {
            _database = database;
        }
        public async Task<bool> Delete<T>(string collectionName, object id)
        {
            try
            {
                var collection = GetCollection<T>(collectionName);
                var filterId = Builders<T>.Filter.Eq("_id", id);

                var col = await collection.DeleteOneAsync(filterId).ConfigureAwait(false);
                return col.IsAcknowledged && col.DeletedCount == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Find<T>(string collectionName, object id)
        {
            try
            {
                //var BsonID = id.ToBson();
                var collection = GetCollection<T>(collectionName);
                var filterId = Builders<T>.Filter.Eq("_id", id);

                var col = await collection.FindAsync(filterId).ConfigureAwait(false);
                return await col.FirstOrDefaultAsync().ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAll<T>(string collectionName)
        {
            try
            {
                var collection = GetCollection<T>(collectionName);
                var col = await collection.FindAsync(Builders<T>.Filter.Empty).ConfigureAwait(false);
                return await col.ToListAsync().ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = GetDatabase();
            return database.GetCollection<T>(collectionName);

            
        }

        private IMongoDatabase GetDatabase()
        {

            if (_client == null)
            {
                _client = new MongoClient("mongodb://localhost:27017");
                    
            }

            return _client.GetDatabase(_database);
        }

        public async Task Upsert<T>(string collectionName, T payload, object id = null)
        {
            try
            {
                var collection = GetCollection<T>(collectionName);

                if (id == null)
                {
                    await collection.InsertOneAsync(payload).ConfigureAwait(false);
                }
                else
                {
                    var filterId = Builders<T>.Filter.Eq("_id", id);
                    await collection.ReplaceOneAsync(filterId, payload, new UpdateOptions { IsUpsert = true }).ConfigureAwait(false);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> GetCollections()
        {
            try
            {
                var database = GetDatabase();
                var bArray = new List<string>();
                var result = await database.ListCollectionsAsync().ConfigureAwait(false);
                

                while (await result.MoveNextAsync())
                {
                    foreach (var current in result.Current)
                    {
                       
                        bArray.Add(current.GetValue("name").AsString);
                        
                    }

                    }
                    return bArray;
                    //return await result.ToListAsync().ConfigureAwait(false);
                    //return result.ToListAsync().ConfigureAwait(false);
                }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<T>> GetFields<T>(string collectionName)
        {
            try
            {
                var database = GetDatabase();
                var collection = database.GetCollection<T>("FieldMetadata");
                var filterId = Builders<T>.Filter.Eq("Table", collectionName);
                var result = await collection.FindAsync(filterId).ConfigureAwait(false);

                return await result.ToListAsync().ConfigureAwait(false);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
