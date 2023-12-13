public interface IReportGenerator
{
    Task GenerateReport(FileType fileType, ReportDeliveryConfiguration deliveryConfig);
}

public interface IReportDeliveryConfiguration
{
    DestinationType DestinationType { get; set; }
    string DestinationAddress { get; set; }

    void ValidateDestination();
}

public interface IDeliveryScheduler
{
    void ConfigureDeliverySchedule(DeliverySchedule schedule);
    DeliverySchedule GetDeliverySchedule();
}

public interface IFileTypeController
{
    List<FileType> GetFileTypes(string keyword);
}

public interface INotificationConfigurationController
{
    NotificationConfiguration GetNotificationConfiguration();
    void UpdateNotificationConfiguration(NotificationConfiguration configuration);
}