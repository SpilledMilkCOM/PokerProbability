using Microsoft.AspNetCore.Mvc;

namespace PokerProbability.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult WinPercent()
        {
            return new ObjectResult(33.33);
        }
    }
}