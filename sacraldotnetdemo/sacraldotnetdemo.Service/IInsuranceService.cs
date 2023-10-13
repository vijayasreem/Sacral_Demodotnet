public interface IInsuranceService
{
    Task<bool> IsEligibleForInsuranceCover(decimal annualIncome);
}

public class InsuranceService : IInsuranceService
{
    public async Task<bool> IsEligibleForInsuranceCover(decimal annualIncome)
    {
        bool isLessThan40K = annualIncome < 40000;

        return isLessThan40K;
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        IInsuranceService insuranceService = new InsuranceService();
        
        decimal annualIncome = 35000;
        
        bool isEligible = await insuranceService.IsEligibleForInsuranceCover(annualIncome);
        
        if (isEligible)
        {
            Console.WriteLine("Customer is eligible for insurance cover.");
        }
        else
        {
            Console.WriteLine("Customer is ineligible for insurance cover.");
        }
    }
}