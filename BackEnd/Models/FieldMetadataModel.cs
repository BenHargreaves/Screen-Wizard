using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class FieldMetadata
    {
        public static string CollectionName = "FieldMetadata";

        [BsonId]
        public ObjectId FieldMetadataID { get; set; }

        public string Table { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DisplayType { get; set; }
        public bool IsRequired { get; set; }

        [BsonIgnoreIfNull]
        public string Caption { get; set; }
        
        public string Value { get; set; }

    }
}
