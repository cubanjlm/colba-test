using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherAPI.Model
{
    public class PublisherDBContext : DbContext, IPublisherDBContext
    {
        private readonly IMongoDatabase m_database = null;
        public IMongoCollection<Author> Authors
        {
            get
            {
                return m_database.GetCollection<Author>("Author");
            }
        }
        public IMongoCollection<Address> Addresses
        {
            get
            {
                return m_database.GetCollection<Address>("Address");
            }
        }
        //public IMongoCollection<BlogPost> Posts
        //{
        //    get
        //    {
        //        return m_database.GetCollection<BlogPost>("BlogPost");
        //    }
        //}
        public IMongoCollection<Book> Books
        {
            get
            {
                return m_database.GetCollection<Book>("Book");
            }
        }

        
        public PublisherDBContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                m_database = client.GetDatabase(settings.Value.Database);
        }

    }
}
