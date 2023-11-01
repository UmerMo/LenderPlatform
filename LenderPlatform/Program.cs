using LenderPlatform;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Blackfinch Lending Platform");

        decimal loanAmount = GetDecimalInput("Please enter the loan amount: ");

        var isLoanAmountInRange = LoanCalculator.IsLoanAmountInRange(loanAmount);

        if (!isLoanAmountInRange)
        {
            Console.WriteLine("Sorry, your application is rejected");
            return;
        }

        decimal assetValue = GetDecimalInput("Please enter the value of the asset: ");
        int creditScore = GetCreditScoreInput("Please enter your credit score, it should be between 1 and 999: ");
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
}