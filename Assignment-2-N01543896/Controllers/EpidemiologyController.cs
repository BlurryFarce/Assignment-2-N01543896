using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_2_N01543896.Controllers
{
    public class EpidemiologyController : ApiController
    {
        /// <summary>
        /// Simulates a simple disease spread model to determine the day on which the total number of infected people
        /// surpasses a given threshold.
        /// This J2 problem is from the 2020 Canadian Computing Competition (CCC).
        /// </summary>
        /// <param name="p">The threshold number of people who must be infected (P < 10).</param>
        /// <param name="n">The number of people initially infected on Day 0 (N < P & N < R).</param>
        /// <param name="r">The number of people each infected person infects per day (R < 10).</param>
        /// <returns>A string stating the day on which "p" people are infected.</returns>
        /// <example>
        /// GET /api/J2/DiseaseSpreadModel/750/1/5 -> "Threshold reached on day 4"
        /// </example>
        [HttpGet]
        [Route("api/J2/DiseaseSpreadModel/{P}/{N}/{R}")]
        public string DiseaseSpreadModel(int p, int n, int r)
        {
            int currentSpread = n;
            int daysCounter = 0;
            while (currentSpread <= p)
            {
                currentSpread += n * r;
                n = n * r;
                daysCounter++;
                //Debug.WriteLine(currentSpread);
            }

            string response = "Threshold reached on day " + daysCounter;
            return response;
        }
    }
}
