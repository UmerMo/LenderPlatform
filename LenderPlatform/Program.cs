public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Blackfinch Lending Platform");

        decimal loanAmount;
        try
        {
            Console.Write("Please enter the loan amount: ");
            loanAmount = decimal.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Loan amount needs to be number.");
            return;
        }

        decimal assetValue;
        try
        {
            Console.Write("Please enter the value of the asset: ");
            assetValue = decimal.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Asset amount needs to be a number.");
            return;
        }

        int creditScore;
        try
        {
            Console.Write("Please enter your credit score, it should be between 1 and 999: ");
            creditScore = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input for credit score.");
            return;
        }
    }
}