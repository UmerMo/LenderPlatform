using LenderPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LenderPlatformTests
{
    [TestClass]
    public class LoanCalculatorTests
    {
        [TestMethod]
        public void IsLoanAmountInRange_ValidAmountInRange_ReturnsTrue()
        {
            // Arrange
            decimal loanAmount = 100000m;

            // Act
            bool result = LoanCalculator.IsLoanAmountInRange(loanAmount);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLoanAmountInRange_LowerThanMinimumAmount_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 90000m; 

            // Act
            bool result = LoanCalculator.IsLoanAmountInRange(loanAmount);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLoanAmountInRange_HigherThanMaximumAmount_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 1600000m;

            // Act
            bool result = LoanCalculator.IsLoanAmountInRange(loanAmount);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoanToValue_LoanAmountLessThan100K_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 90000m;
            decimal assetValue = 150000m;
            int creditScore = 950;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoanToValue_LoanAmountMoreThan15Million_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 150000m;
            decimal assetValue = 150000m;
            int creditScore = 950;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoanToValue_Loan1MillionOrMore_LTV60OrLessAndCreditScore950_ReturnsTrue()
        {
            // Arrange
            decimal loanAmount = 1000000m;
            decimal assetValue = 1500000m;
            int creditScore = 950;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoanToValue_Loan1MillionOrMore_LTV60OrLessAndCreditScore949_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 1000000m;
            decimal assetValue = 1500000m;
            int creditScore = 949;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoanToValue_LoanLessThan1Million_LTV59AndCreditScore750_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 900000m;
            decimal assetValue = 1500000m;
            int creditScore = 750;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoanToValue_LoanLessThan1Million_LTV59AndCreditScore751_ReturnsTrue()
        {
            // Arrange
            decimal loanAmount = 900000m;
            decimal assetValue = 1500000m;
            int creditScore = 751;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoanToValue_LoanLessThan1Million_LTVLessThan80AndCreditScoreLessThan800_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 700000m;
            decimal assetValue = 1000000m;
            int creditScore = 780;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoanToValue_LoanLessThan1Million_LTVLessThan80AndCreditScore800_ReturnsTrue()
        {
            // Arrange
            decimal loanAmount = 700000m;
            decimal assetValue = 1000000m;
            int creditScore = 800;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoanToValue_LoanLessThan1Million_LTVLessThan90AndCreditScoreLessThan900_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 800000m;
            decimal assetValue = 900000m;
            int creditScore = 850;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoanToValue_LoanLessThan1Million_LTVLessThan90AndCreditScore900_ReturnsTrue()
        {
            // Arrange
            decimal loanAmount = 800000m;
            decimal assetValue = 900000m;
            int creditScore = 900;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoanToValue_LoanAmount900K_LTV90_ReturnsFalse()
        {
            // Arrange
            decimal loanAmount = 900000m;
            decimal assetValue = 1000000m;
            int creditScore = 950;

            // Act
            bool result = LoanCalculator.LoanToValue(loanAmount, assetValue, creditScore);

            // Assert
            Assert.IsFalse(result);
        }
    }
}