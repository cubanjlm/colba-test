using PublisherAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublisherAPI.Repository
{
    public interface IAddressRepositry:IBaseRepository<Address>
    {
        Task<IEnumerable<Address>> FindByAuthor(string authorID);
    }
}