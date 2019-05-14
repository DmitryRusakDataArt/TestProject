﻿using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using Common;
using Models;

namespace Infrastructure.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ILoanCalculations _loanCalculations;

        public CalculationService(ILoanCalculations loanCalculations)
        {
            _loanCalculations = loanCalculations;
        }

        /// <summary>
        /// Serice method for calculating of repayment scheduler
        /// </summary>
        /// <param name="amount">Loan amount</param>
        /// <param name="apr">Annual Percentage Rate</param>
        /// <returns>List of RepaymentScheduleItem</returns>
        public IEnumerable<RepaymentScheduleItem> GetRepaymentScheduleInfo(decimal amount, decimal apr)
        {
            return _loanCalculations.GetRepaymentScheduleInfo(amount, Constants.PAYMENT_PERIOD, apr);
        }

        /// <summary>
        /// Service methood for calculations of the Loan
        /// </summary>
        /// <param name="amount">Loan amount</param>
        /// <param name="apr">Annual Percentage Rate</param>
        /// <returns>LoanSummaryItem</returns>
        public LoanSummaryItem GetSummaryInfo(decimal amount, decimal apr)
        {
            return _loanCalculations.GetSummaryInfo(amount, Constants.PAYMENT_PERIOD, apr);
        }
    }
}
