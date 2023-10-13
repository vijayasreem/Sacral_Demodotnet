interface IOtpService
{
    Task<bool> ValidateOtp();
}

class OtpService : IOtpService
{
    Task<bool> ValidateOtp();
}

class Program
{
    static Task Main(string[] args);
}