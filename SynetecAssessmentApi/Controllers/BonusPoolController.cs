using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Persistence.Dtos;
using SynetecAssessmentApi.Services;
using System;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService BonusPoolService;
        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            BonusPoolService = bonusPoolService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await BonusPoolService.GetEmployeesAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            try
            {
                if (request == null)
                    throw new ArgumentException("Invalid parameters supplied");

                return Ok(await BonusPoolService.CalculateAsync(
                    request.TotalBonusPoolAmount,
                    request.SelectedEmployeeId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
