using FruityDemo.Models;
using FruityDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruityDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly IFruitService _fruitService;
        private readonly ILogger<FruitController> _logger;

        public FruitController(IFruitService fruitService, ILogger<FruitController> logger)
        {
            _fruitService = fruitService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllFruits")]
        public async Task<IActionResult> GetAllFruits()
        {
            try
            {
                var fruits = await _fruitService.GetAllFruits();
                return Ok(fruits);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all fruits.");
                return StatusCode(500, "An error occurred while fetching the fruits.");
            }
        }

        [HttpPost]
        [Route("GetFruitsByFamily")]
        public async Task<IActionResult> GetFruitsByFamily([FromBody] FruitFamilyRequest fruitFamily)
        {
            try
            {
                var fruits = await _fruitService.GetFruitsByFamily(fruitFamily.FruitFamily);
                return Ok(fruits);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching fruits by family.");
                return StatusCode(500, "An error occurred while fetching the fruits by family.");
            }
        }
    }


}
