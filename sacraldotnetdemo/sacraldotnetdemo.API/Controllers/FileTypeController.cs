
using Microsoft.AspNetCore.Mvc;
using sacraldotnetdemo.DTO;
using sacraldotnetdemo.Service;

namespace sacraldotnetdemo.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileTypeController : ControllerBase, IFileTypeController
    {
        private readonly IReportGenerator _reportGenerator;

        public FileTypeController(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }

        [HttpGet]
        public ActionResult<List<FileType>> GetFileTypes(string keyword)
        {
            // Your logic to retrieve file types based on the keyword
            List<FileType> fileTypes = new List<FileType>();

            // Return the file types as JSON array
            return fileTypes;
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationConfigurationController : ControllerBase, INotificationConfigurationController
    {
        private readonly INotificationConfigurationService _notificationConfigurationService;

        public NotificationConfigurationController(INotificationConfigurationService notificationConfigurationService)
        {
            _notificationConfigurationService = notificationConfigurationService;
        }

        [HttpGet]
        public ActionResult<NotificationConfiguration> GetNotificationConfiguration()
        {
            // Your logic to retrieve notification configuration
            NotificationConfiguration configuration = new NotificationConfiguration();

            // Return the notification configuration
            return configuration;
        }

        [HttpPost]
        public IActionResult UpdateNotificationConfiguration([FromBody] NotificationConfiguration configuration)
        {
            // Your logic to update notification configuration
            _notificationConfigurationService.UpdateConfiguration(configuration);

            // Return OK status
            return Ok();
        }
    }
}
