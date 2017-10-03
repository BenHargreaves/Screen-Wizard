using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Models;
using MongoDB.Bson;
using System.Reflection;

namespace BackEnd.Services.Contracts
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> All();
        Task<bool> Delete(ObjectId id);
        Task<Activity> Create(Activity activity);
        Task<Activity> Update(Activity activity);
        Task<Activity> Find(ObjectId id);
    }
}
