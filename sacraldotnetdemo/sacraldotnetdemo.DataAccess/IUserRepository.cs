namespace sacraldotnetdemo.Service
{
    using System.Threading.Tasks;
    using sacraldotnetdemo.DTO;

    public interface IUserRepository
    {
        Task<UserModel> GetById(int id);
        Task<int> Create(UserModel user);
        Task Update(UserModel user);
        Task Delete(int id);
        Task<bool> IsAnnualIncomeLessThan40K(int id);
        Task<bool> IsEligibleForInsuranceCover(int id);
    }
}