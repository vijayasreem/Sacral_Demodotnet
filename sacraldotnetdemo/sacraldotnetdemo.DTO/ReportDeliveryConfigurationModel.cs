
using System;
using System.Collections.Generic;

namespace sacraldotnetdemo
{
    public class ReportDeliveryConfigurationModel
    {
        public DestinationTypeModel DestinationType { get; set; }
        public string DestinationAddress { get; set; }
    }

    public enum DestinationTypeModel
    {
        Email,
        CloudStorage,
        InternalServer
    }

    public class DeliveryScheduleModel
    {
        public DeliveryFrequencyModel Frequency { get; set; }
        public List<DayOfWeekModel> DeliveryDays { get; set; }
        public DateTime DeliveryTime { get; set; }
    }

    public enum DeliveryFrequencyModel
    {
        Daily,
        Weekly,
        BiWeekly,
        Monthly
    }

    public class DayOfWeekModel
    {
        public DayOfWeek Day { get; set; }
        public bool IsSelected { get; set; }
    }

    public class FileTypeModel
    {
        public string FileType { get; set; }
        public string Description { get; set; }
    }

    public class NotificationConfigurationModel
    {
        public List<string> EmailAddresses { get; set; }
        public string Subject { get; set; }
        public string BodyText { get; set; }
    }

    public class ReportGeneratorModel
    {
        public void GenerateReport(FileTypeModel fileType)
        {
            // Logic for generating reports based on the selected file type
        }
    }

    public class DeliverySchedulerModel
    {
        public void ConfigureDeliverySchedule(NotificationConfigurationModel notificationConfig, DeliveryScheduleModel deliverySchedule)
        {
            // Logic for configuring the delivery schedule
        }

        public DeliveryScheduleModel GetDeliverySchedule()
        {
            // Logic for retrieving the delivery schedule
            return new DeliveryScheduleModel();
        }
    }

    public class FileTypeController
    {
        public List<FileTypeModel> GetFileTypes()
        {
            // Logic for retrieving file types
            return new List<FileTypeModel>();
        }
    }
}
