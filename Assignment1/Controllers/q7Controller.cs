using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q7Controller : ControllerBase
    {
        [HttpGet(template:"timemachine")]
        public string Get(int days)
        {
            DateTime todaysDate = DateTime.Today;
            DateTime newDate = todaysDate.AddDays(days);
            return newDate.ToString("yyyy-MM-dd");
        }
    }
}
