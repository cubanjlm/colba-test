using PublisherAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublisherAPI.Repository
{
    public interface IBaseRepository<T>
    {
        IPublisherDBContext DbContext { get; }

        Task<T> FindAsync(string id);
        Task<IEnumerable<T>> ListAsync();
        void RemoveAsync(string id);
        void Save(T value);
        void UpdateAsync(string id, T value);
    }
}