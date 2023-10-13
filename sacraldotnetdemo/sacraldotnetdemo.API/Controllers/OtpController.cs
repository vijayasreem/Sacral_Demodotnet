
using Microsoft.AspNetCore.Mvc;
using sacraldotnetdemo.DTO;
using sacraldotnetdemo.Service;
using System.Threading.Tasks;

namespace sacraldotnetdemo.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;

        public OtpController(IOtpService otpService)
        {
            _otpService = otpService;
        }

        [HttpGet("validate")]
        public async Task<IActionResult> ValidateOtp(string otp)
        {
            if (string.IsNullOrEmpty(otp))
            {
                return BadRequest("OTP is required.");
            }

            bool isValid = await _otpService.ValidateOtp(otp);

            if (isValid)
            {
                return Ok("OTP validated successfully.");
            }
            else
            {
                return StatusCode(403, "OTP validation failed. User not allowed to proceed with insurance cover.");
            }
        }
    }
}
