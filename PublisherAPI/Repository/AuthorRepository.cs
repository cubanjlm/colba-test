using MongoDB.Driver;
using PublisherAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherAPI.Model
{
    public class AuthorRepository : IAuthorRepository
    {
        public IPublisherDBContext DbContext { get; }
        public AuthorRepository(IPublisherDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> ListAsync() => await DbContext.Authors.Find(e => true).ToListAsync();

        public async Task<Author> FindAsync(string id)
        {
            return await DbContext.Authors.Find(p => p.Id.Equals(id)).SingleAsync();
        }

        public void Save(Author value)
        {
            value.Id = Guid.NewGuid().ToString("N");
            DbContext.Authors.InsertOne(value);
        }

        public async void UpdateAsync(string id, Author value)
        {
            await DbContext.Authors.FindOneAndReplaceAsync(p => p.Id.Equals(id), value);
        }

        public async void RemoveAsync(string id)
        {
            await DbContext.Authors.FindOneAndDeleteAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<BlogPost>> GetEntries(string authorId)
        {
            var author = await FindAsync(authorId);
            return author.Entries;
        }
    }
}
