using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherAPI.Model
{
    public class Author
    {
        [BsonId]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> AddressesID { get; set; }
        public List<string> Books { get; set; }
        public List<BlogPost> Entries { get; set; }
        
    }
}
