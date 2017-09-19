using BackEnd.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Services.Contracts
{
    public interface IScreenService 
    {
        Task<ScreenMetadata> Create(ScreenMetadata screenMetadata);
        Task<IEnumerable<ScreenMetadata>> All();
        Task<ScreenMetadata> Find(ObjectId id);


    }
}
