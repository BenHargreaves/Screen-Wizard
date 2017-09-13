using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackEnd
{
    class Connection
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("ScreenWizard");
            var coll = db.GetCollection<Models.Customer>("Customer");



            

            


        }

    }
}

