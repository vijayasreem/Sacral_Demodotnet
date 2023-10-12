public interface IReportDeliveryConfiguration
{
    DestinationType DestinationType { get; set; }
    string DestinationAddress { get; set; }
    void ValidateDestination();
}

public interface IReportGenerator
{
    Task GenerateReport(FileType fileType);
}

public interface IDeliveryScheduler
{
    void ConfigureDeliverySchedule(DeliverySchedule schedule);
    DeliverySchedule GetDeliverySchedule();
}

public interface INotificationConfiguration
{
    List<string> EmailAddresses { get; set; }
    string Subject { get; set; }
    string BodyText { get; set; }
}

public interface ISchedulingConfigurationToolService
{
    Task ConfigureNotificationConfiguration(NotificationConfiguration configuration);
    Task<NotificationConfiguration> GetNotificationConfiguration();
}