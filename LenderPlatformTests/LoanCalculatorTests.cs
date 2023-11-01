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
    }
}