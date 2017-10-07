using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackEnd.Models
{
    public class InvoiceItemModel
    {
        public static string CollectionName = "InvoiceItem";

        [BsonId]
        public ObjectId InvoiceLineId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal Subtotal { get; set; }
        
    }
}
