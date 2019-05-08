using Calculations;
using Infractructure.Interfaces;
using Infractructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

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

        [TestMethod]
        public void GetRepaymentScheduleInfoTest()
        {
            var actualResult = _calculationService.GetRepaymentScheduleInfo(50000, 19).ToArray();
            var week1Info = new RepaymentScheduleItem
            {
                InstallmentNumber = 1,
                AmountDue = 50000,
                Principal = 875,
                Interest = 183
            };
            var week2Info = new RepaymentScheduleItem
            {
                InstallmentNumber = 2,
                AmountDue = 49125.17m,
                Principal = 878,
                Interest = 179
            };
            var week10Info = new RepaymentScheduleItem
            {
                InstallmentNumber = 10,
                AmountDue = 42010.44m,
                Principal = 904,
                Interest = 153
            };
            var week26Info = new RepaymentScheduleItem
            {
                InstallmentNumber = 26,
                AmountDue = 27142.8m,
                Principal = 958,
                Interest = 99
            };
            var week52Info = new RepaymentScheduleItem
            {
                InstallmentNumber = 52,
                AmountDue = 1053.68m,
                Principal = 1054,
                Interest = 4
            };
            Assert.AreEqual(week1Info, actualResult[0]);
            Assert.AreEqual(week2Info, actualResult[1]);
            Assert.AreEqual(week10Info, actualResult[9]);
            Assert.AreEqual(week26Info, actualResult[25]);
            Assert.AreEqual(week52Info, actualResult[51]);
        }
    }
}
