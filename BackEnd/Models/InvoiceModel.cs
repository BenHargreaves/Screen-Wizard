using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Invoice
    {
        public static string CollectionName = "Invoice";

        [BsonId]
        public ObjectId _id { get; set; }
        public string InvoiceId { get; set; }
        [BsonRequired]
        public string CustomerName { get; set; }
        
        public ObjectId CustomerId { get; set; }
        public int InvoiceNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public decimal Balance { get; set; }
        public List<InvoiceItemModel> InvoiceItems { get; set; }
        public decimal Total { get; set; }
        

    }
}
