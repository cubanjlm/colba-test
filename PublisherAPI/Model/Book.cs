using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherAPI.Model
{
    public class Book
    {
        [BsonId]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<string> AuthorId { get; set; }
        
    }
}
