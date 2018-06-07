using MongoDB.Driver;

namespace PublisherAPI.Model
{
    public interface IPublisherDBContext
    {
        IMongoCollection<Address> Addresses { get; }
        IMongoCollection<Author> Authors { get; }
        IMongoCollection<Book> Books { get; }
        //IMongoCollection<BlogPost> Posts { get; }
    }
}