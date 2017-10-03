using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackEnd.Models
{
    public class Customer
    {
        public static string CollectionName = "Customer";

        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        public string Name { get; set; }
        public string CustomerId { get; set; }
        public string Email{ get; set; }
        
        public string ContactNumber { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public string Website { get; set; }
        public string Notes { get; set; }
        

    }
}

