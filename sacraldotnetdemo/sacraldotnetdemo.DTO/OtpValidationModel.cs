namespace sacraldotnetdemo
{
    public class OtpValidationModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Otp { get; set; }
        
        [Required]
        public bool InsuranceCover { get; set; }
    }
}