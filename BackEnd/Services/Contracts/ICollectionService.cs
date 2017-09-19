using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Models;
using MongoDB.Bson;

namespace BackEnd.Services.Contracts
{
    public interface ICollectionService
    {
        Task<List<string>> GetCollections();

    }
}
