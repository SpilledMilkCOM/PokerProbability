using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PokerProbability.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        [HttpGet("[action]")]
        public double WinPercent()
        {
            return 33.33;
        }
    }
}
