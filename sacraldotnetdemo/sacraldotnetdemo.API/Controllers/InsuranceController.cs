
using Microsoft.AspNetCore.Mvc;
using sacraldotnetdemo.DTO;
using sacraldotnetdemo.Service;
using System.Threading.Tasks;

namespace sacraldotnetdemo.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet("CheckEligibility/{annualIncome}")]
        public async Task<IActionResult> CheckEligibility(decimal annualIncome)
        {
            bool isEligible = await _insuranceService.IsEligibleForInsuranceCover(annualIncome);

            if (isEligible)
            {
                return Ok("Customer is eligible for insurance cover.");
            }
            else
            {
                return Ok("Customer is ineligible for insurance cover.");
            }
        }
    }
}
