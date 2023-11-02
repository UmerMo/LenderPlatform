using LenderPlatform;
using LenderPlatform.API;
using Newtonsoft.Json;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Blackfinch Lending Platform");

        decimal loanAmount = GetDecimalInput("Please enter the loan amount: ");
        decimal assetValue = GetDecimalInput("Please enter the value of the asset: ");
        int creditScore = GetCreditScoreInput("Please enter your credit score, it should be between 1 and 999: ");

        var isLoanAmountInRange = LoanCalculator.IsLoanAmountInRange(loanAmount);

        if (!isLoanAmountInRange)
        {
            Console.WriteLine("Sorry, your application is declined");
            return;
        }

        var isSuccess = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

        if (!isSuccess)
        {
            Console.WriteLine("Sorry, your application is declined");
            return;
        }
        else
        {
            Console.WriteLine("Congratulations, your application is successful");
        }

        // Metrics : TODO: Refactor out
        List<Applicant> applicants = LoadApplicantsFromJson();

        CalculateAndDisplayMetrics(applicants);
    }

    //TODO: Move this into separate file and write unit tests
    private static decimal GetDecimalInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string inputValue = Console.ReadLine();
            if (decimal.TryParse(inputValue, out decimal parsedInput))
            {
                return parsedInput;
            }
            Console.WriteLine("Invalid input. Please enter a valid amount.");
        }
    }

    private static int GetCreditScoreInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string inputValue = Console.ReadLine();
            if (int.TryParse(inputValue, out int parsedInput) && parsedInput >= 1 && parsedInput <= 999)
            {
                return parsedInput;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer between 1 and 999.");
        }
    }
    static List<Applicant> LoadApplicantsFromJson()
    {
        string jsonFilePath = Path.Combine("API", "data.json");
        List<Applicant> applicants = new List<Applicant>();

        try
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            applicants = JsonConvert.DeserializeObject<List<Applicant>>(jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading JSON data: {ex.Message}");
        }

        return applicants;
    }

    static void CalculateAndDisplayMetrics(List<Applicant> applicants)
    {
        int totalApplicants = applicants.Count;
        int approvedCount = applicants.Count(applicant => applicant.LoanStatus == "Approved");
        int deniedCount = applicants.Count(applicant => applicant.LoanStatus == "Declined");

        decimal totalLoanValue = applicants.Sum(applicant => applicant.LoanAmount);
        decimal totalLTV = applicants.Sum(applicant => (applicant.LoanAmount / applicant.AssetValue) * 100);

        decimal meanAverageLTV = totalLTV / totalApplicants;

        Console.WriteLine($"Number of Approved Applicants: {approvedCount}");
        Console.WriteLine($"Number of Denied Applicants: {deniedCount}");

        Console.WriteLine($"Total Value of Loans Written to Date: £{totalLoanValue:N2}");
        Console.WriteLine($"Mean Average Loan-to-Value (LTV): {meanAverageLTV:N2}%");
    }

}