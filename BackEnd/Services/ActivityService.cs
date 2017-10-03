using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Services.Contracts;
using BackEnd.Models;
using BackEnd.Providers;
using MongoDB.Bson;
using System.Reflection;

namespace BackEnd.Services
{
    public class ActivityService : IActivityService
    {
        private readonly MongoProvider _mongoProvider;

        public ActivityService()
        {
            _mongoProvider = new MongoProvider("ScreenWizard");
        }

       public async Task<IEnumerable<Activity>> All()
        {
            try
            {
                return await _mongoProvider.GetAll<Activity>(Activity.CollectionName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Activity> Create(Activity activity)
        {
            try
            {
                await _mongoProvider.Upsert<Activity>(Activity.CollectionName, activity).ConfigureAwait(false);
                return activity;
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
                return await _mongoProvider.Delete<Activity>(Activity.CollectionName, id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Activity> Find(ObjectId id)
        {
            try
            {
                return await _mongoProvider.Find<Activity>(Activity.CollectionName, id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Activity> Update(Activity activity)
        {
            try
            {
                await _mongoProvider.Upsert<Activity>(Activity.CollectionName, activity, activity.ActivityId).ConfigureAwait(false);
                return activity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
