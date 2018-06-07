using PublisherAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublisherAPI.Repository
{
    public interface IAuthorRepository: IBaseRepository<Author>
    {
        Task<IEnumerable<BlogPost>> GetEntries(string authorId);
    }
}