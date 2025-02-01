using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q6Controller : ControllerBase
    {
        [HttpGet(template:"hexagon")]
        public double Get(double side)
        {
            return (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
        }
    }
}
