using System;
using System.Collections.Generic;
using System.Text;

namespace SynetecAssessmentApi.Services
{
    public interface IBonusCalculator
    {
        decimal CalculateBonus(decimal salary, decimal totalSalary, decimal bonusPoolAmount);
    }
    public class BonusCalculator : IBonusCalculator
    {
        public decimal CalculateBonus(decimal salary, decimal totalSalary, decimal bonusPoolAmount)
        {
            decimal bonusPercentage = salary / totalSalary;
            return bonusPercentage * bonusPoolAmount;
        }
    }
}
