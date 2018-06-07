using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using PublisherAPI.Model;

namespace PublisherAPI.Repository
{
    public class AddressRepositry : IAddressRepositry
    {
        public IPublisherDBContext DbContext { get; }

        public AddressRepositry(IPublisherDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Address> FindAsync(string id)
        {
            return await DbContext.Addresses.Find(p => p.Id.Equals(id)).SingleAsync();
        }

        public async Task<IEnumerable<Address>> ListAsync()
        {
            return await DbContext.Addresses.Find(e => true).ToListAsync();
        }

        public async void RemoveAsync(string id)
        {
            await DbContext.Addresses.FindOneAndDeleteAsync(p => p.Id.Equals(id));
        }

        public void Save(Address value)
        {
            value.Id = Guid.NewGuid().ToString("N");
            DbContext.Addresses.InsertOne(value);
        }

        public async void UpdateAsync(string id, Address value)
        {
            await DbContext.Addresses.FindOneAndReplaceAsync(p => p.Id.Equals(id), value);
        }

        public async Task<IEnumerable<Address>> FindByAuthor(string authorID)
        {
            return await DbContext.Addresses.Find(x => x.Authors.Contains(authorID)).ToListAsync();
        }
    }
}
