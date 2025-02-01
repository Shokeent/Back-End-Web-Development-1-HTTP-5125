using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q8Controller : ControllerBase
    {
        [HttpPost(template:"squashfellows")]
        public string Post([FromForm] int Small, int Large)
        {
            double smallPrice = 25.50;
            double LargePrice = 25.50;
            double tax = 0.13;
            double smallTotal = Small * smallPrice;
            double largeTotal = Large * LargePrice;
            double total = smallTotal + largeTotal;
            double finalTotal = Math.Round(total * tax, 2);

            return "${ Small}
            Small @ $${ smallPrice.toFixed(2)} = $${ smallTotal.toFixed(2)};
            ${ Large}
            Large @ $${ largePrice.toFixed(2)} = $${ largeTotal.toFixed(2)};
            Subtotal = $${ subtotal.toFixed(2)};
            Tax = $${ tax.toFixed(2)}
            HST;
            Total = $${ total.toFixed(2)";
;


            


        }
    }
}
