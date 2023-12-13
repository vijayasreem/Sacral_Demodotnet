
using System.Threading.Tasks;

namespace sacraldotnetdemo.DTO
{
    public interface IRepository
    {
        Task CreateAsync<T>(T entity);
        Task<T> GetAsync<T>(int id);
        Task UpdateAsync<T>(T entity);
        Task DeleteAsync<T>(int id);
    }
}
