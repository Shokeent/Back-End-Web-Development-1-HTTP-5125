using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// This calculates the total Scoville Heat Units based on the peppers used.
        /// Accepts only pepper names .
        /// </summary>
        /// 
        /// <param name="ingredients">A comma-separated list of pepper names.</param>
        /// 
        /// <returns>
        /// The total Heat Units of the chili.
        /// </returns>
        /// 
        /// <example>
        /// GET: api/ChiliPeppers?ingredients=Poblano,Cayenne,Thai,Poblano  
        /// Response: 118000
        /// </example>
        /// 
        [HttpGet("ChilliPeppers")]
        public int GetTotalHeatUnits([FromQuery] string ingredients)
        {
            var pepperHeatUnits = new Dictionary<string, int>(System.StringComparer.OrdinalIgnoreCase)
            {
                { "POBLANO", 1500 },
                { "MIRASOL", 6000 },
                { "SERRANO", 15500 },
                { "CAYENNE", 40000 },
                { "THAI", 75000 },
                { "HABANERO", 125000 }
            };

            int totalHeatUnits = 0;
            if (string.IsNullOrWhiteSpace(ingredients))
            {
                Debug.WriteLine("No peppers provided. Returning 0.");
                return totalHeatUnits;
            }
            string[] selectedPeppers = ingredients.Split(',');
            foreach (string pepper in selectedPeppers)
            {
                string trimmedPepper = pepper.Trim();
                if (pepperHeatUnits.ContainsKey(trimmedPepper))
                {
                    totalHeatUnits += pepperHeatUnits[trimmedPepper];
                }
                else
                {
                    Debug.WriteLine($"Unknown Pepper: '{trimmedPepper}'. Ignoring...");
                }
            }

            Debug.WriteLine($"Peppers: {ingredients}, Total Scoville Heat Units: {totalHeatUnits}");
            return totalHeatUnits;
        }

    }
}
