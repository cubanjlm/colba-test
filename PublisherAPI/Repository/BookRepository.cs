using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using PublisherAPI.Model;

namespace PublisherAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        public IPublisherDBContext DbContext { get; }

        public BookRepository(IPublisherDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Book> FindAsync(string id)
        {
            return await DbContext.Books.Find(p => p.Id.Equals(id)).SingleAsync();
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await DbContext.Books.Find(e => true).ToListAsync();
        }

        public async void RemoveAsync(string id)
        {
            await DbContext.Books.FindOneAndDeleteAsync(p => p.Id.Equals(id));
        }

        public void Save(Book value)
        {
            value.Id = Guid.NewGuid().ToString("N");
            DbContext.Books.InsertOne(value);
        }

        public async void UpdateAsync(string id, Book value)
        {
            await DbContext.Books.FindOneAndReplaceAsync(p => p.Id.Equals(id), value);
        }   
    }
}
