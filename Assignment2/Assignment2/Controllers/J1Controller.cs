using Microsoft.AspNetCore.Mvc;

namespace CCC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// We are calculating the final score for Deliv-e-droid game.
        /// </summary>
        /// 
        /// <param name="collisions">no. of the collisions with obstacles</param>
        /// <param name="deliveries">no. of packages delivered</param>
        /// 
        /// <returns
        /// >The final score based on the rule.
        /// </returns>
        /// 
        /// <example>
        /// POST api/J1/Delivedroid with body Collisions=2&Deliveries=5 returns 730
        /// 
        /// POST api/J1/Delivedroid with body Collisions=10&Deliveries=0 returns -100
        /// 
        /// POST api/J1/Delivedroid with body Collisions=3&Deliveries=2 returns 70
        /// </example>
        /// 
        [HttpPost("Delivedroid")]
        public IActionResult CalculateScore([FromForm] int collisions, [FromForm] int deliveries)
        {
            int score = (deliveries * 50) - (collisions * 10);

            if (deliveries > collisions)
            {
                score += 500;
            }

            return Ok(score);
        }
    }
}
