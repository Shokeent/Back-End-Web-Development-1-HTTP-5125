using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1BController : ControllerBase
    {
        /// <summary>
        /// it deetermines if a 4-digit phone number is from a telemarketer.
        /// </summary>

        /// <param name="d1">First digit of the number</param>
        /// <param name="d2">Second digit</param>
        /// <param name="d3">Third digit</param>
        /// <param name="d4">Fourth digit</param>
        /// 
        /// <returns>
        /// "telemarketer" if the number matches rules, otherwise "not a telemarketer"
        /// </returns>

        /// <example>
        /// POST api/J1B/TelemarketerCheck with body d1=8&d2=2&d3=2&d4=9 returns "telemarketer"
        /// 
        /// POST api/J1B/TelemarketerCheck with body d1=1&d2=2&d3=2&d4=9 returns "not a telemarketer"
        /// </example>
        [HttpPost("TelemarketerCheck")]
        public IActionResult IsTelemarketer(
            [FromForm] int d1,
            [FromForm] int d2,
            [FromForm] int d3,
            [FromForm] int d4)
        {
            if ((d1 == 8 || d1 == 9) &&
                (d4 == 8 || d4 == 9) &&
                (d2 == d3))
            {
                return Ok("telemarketer");
            }

            return Ok("not a telemarketer");
        }
    }
}
