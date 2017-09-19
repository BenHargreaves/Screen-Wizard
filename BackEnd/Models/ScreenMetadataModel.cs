using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class ScreenMetadata
    {
        public static string CollectionName = "ScreenMetadata";

        [BsonId]
        public ObjectId ScreenMetadataID { get; set; }
        public string ScreenType { get; set; }
        public string TableName { get; set; }
        public string ScreenCaption { get; set; }
        public List<FieldMetadata> Fields { get; set; }

    }
}
