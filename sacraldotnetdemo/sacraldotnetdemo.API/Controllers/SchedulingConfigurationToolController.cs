using Microsoft.AspNetCore.Mvc;
using sacraldotnetdemo.DTO;
using sacraldotnetdemo.Service;
using System.Threading.Tasks;

namespace sacraldotnetdemo.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulingConfigurationToolController : ControllerBase
    {
        private readonly ISchedulingConfigurationToolService _service;

        public SchedulingConfigurationToolController(ISchedulingConfigurationToolService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<NotificationConfiguration>> GetNotificationConfiguration()
        {
            var notificationConfiguration = await _service.GetNotificationConfiguration();
            return Ok(notificationConfiguration);
        }

        [HttpPost]
        public async Task<IActionResult> ConfigureNotificationConfiguration([FromBody] NotificationConfiguration configuration)
        {
            await _service.ConfigureNotificationConfiguration(configuration);
            return Ok();
        }
    }
}