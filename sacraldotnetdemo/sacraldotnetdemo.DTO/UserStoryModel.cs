
namespace sacraldotnetdemo
{
    public class UserStoryModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AcceptanceCriteria { get; set; }
    }
    
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal AnnualIncome { get; set; }
    }
    
    public class InsuranceCoverModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool IsEligible { get; set; }
    }
}
