
using System.Collections.Generic;
using System.Threading.Tasks;
using sacraldotnetdemo.DTO;

namespace sacraldotnetdemo.Service
{
    public interface IOtpValidationModelRepository
    {
        Task<IEnumerable<OtpValidationModel>> GetAllAsync();
        Task<OtpValidationModel> GetByIdAsync(int id);
        Task<int> AddAsync(OtpValidationModel otpValidationModel);
        Task<bool> UpdateAsync(OtpValidationModel otpValidationModel);
        Task<bool> DeleteAsync(int id);
    }
}
