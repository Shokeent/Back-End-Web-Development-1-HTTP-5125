using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2BController : ControllerBase
    {
        /// <summary>
        /// This calculates final position from a list of "up" and "down" commands.
        /// </summary>
        /// 
        /// <param name="commands">Comma-separated list like "up,down,up"</param>
        /// 
        /// <returns>
        /// Final position as an integer
        /// </returns>
        /// 
        /// <example>
        /// POST /api/J2B/UpDown with commands="up,up,down,up" returns 2
        /// POST /api/J2B/UpDown with commands="down,down,down" returns -3
        /// POST /api/J2B/UpDown with commands="up,down,up,up,down" returns 1
        /// </example>
        [HttpPost("UpDown")]
        public int GetFinalPosition([FromForm] string commands)
        {
            int position = 0;

            foreach (var cmd in commands.Split(','))
            {
                if (cmd.Trim().ToLower() == "up") position++;
                else if (cmd.Trim().ToLower() == "down") position--;
            }

            return position;
        }
    }
}
