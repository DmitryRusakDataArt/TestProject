using Calculations;
using Infractructure.Interfaces;
using Infractructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace CalculationsTest
{
    [TestClass]
    public class LoanCalculationsTests
    {
        private ICalculationService _calculationService;

        [TestInitialize]
        public void Intialize()
        {
            _calculationService = new CalculationService(new LoanCalculations());
        }

        [TestMethod]
        public void GetSummaryInfoTest()
        {
            var actualResult = _calculationService.GetSummaryInfo(50000, 19);
            var expectedResult = new LoanSummaryItem
            {
                WeeklyRepayment = 1058,
                TotalRepaid = 55016,
                TotalInterest = 5016
            };
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
