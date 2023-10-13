using System;
using System.Threading.Tasks;

public interface IInsuranceService
{
    Task<bool> IsEligibleForInsuranceCover(decimal annualIncome);
}

public class InsuranceService : IInsuranceService
{
    public async Task<bool> IsEligibleForInsuranceCover(decimal annualIncome)
    {
        // Assuming annualIncome is already provided
        
        // Check if annual income is less than 40K
        bool isLessThan40K = annualIncome < 40000;

        return isLessThan40K;
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        IInsuranceService insuranceService = new InsuranceService();
        
        // Get customer's annual income from input or database
        decimal annualIncome = 35000; // Example value
        
        // Determine eligibility for insurance cover
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