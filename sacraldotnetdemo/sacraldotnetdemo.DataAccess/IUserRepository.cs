
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sacraldotnetdemo.Service
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<int> CreateAsync(User user);
        Task<int> UpdateAsync(int id, User user);
        Task<int> DeleteAsync(int id);
    }
}
