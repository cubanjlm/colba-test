using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherAPI.Model
{
    public class PostComment
    {
        [BsonId]
        //public string Id { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
    }
}
