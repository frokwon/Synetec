using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynetecAssessmentApi.Services;

namespace SynetecAssessmentApi.Tests
{
    [TestClass]
    public class BonusCalculatorTests
    {
        private IBonusCalculator BonusCalculator;
        
        [TestInitialize]
        public void TestInitialize()
        {
            BonusCalculator = new BonusCalculator();
        }
        
        [TestMethod]
        public void CalculateBonus()
        {
            var bonus = BonusCalculator.CalculateBonus(15000, 100000, 123456);
            Assert.AreEqual(18518.4M, bonus);
        }
    }
}
