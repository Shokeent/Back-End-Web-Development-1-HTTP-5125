using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the area of a rectangle.
        /// </summary>
        /// 
        /// <param name="l">Length of the rectangle</param>
        /// <param name="w">Width of the rectangle</param>
        /// 
        /// <returns
        /// >Area of the rectangle
        /// </returns>
        /// <example>
        /// 
        /// </example>
        [HttpPost("RectangleArea")]
        public IActionResult GetRectangleArea([FromForm] int l, [FromForm] int w)
        {
            int area = l * w;
            return Ok(area);
        }
    }
}


