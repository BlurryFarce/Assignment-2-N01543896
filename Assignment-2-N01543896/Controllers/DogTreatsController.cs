using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_2_N01543896.Controllers
{
    public class DogTreatsController : ApiController
    {
        /// <summary>
        /// Determines the dog's happiness level based on the types and quantities of treats given.
        /// This J1 problem is from the 2020 Canadian Computing Competition (CCC).
        /// </summary>
        /// <param name="smallTreats">Number of small treats given.</param>
        /// <param name="medTreats">Number of medium treats given.</param>
        /// <param name="largeTreats">Number of large treats given.</param>
        /// <returns>A string indicating the dog's happiness level ("Happy" or "Sad").</returns>
        /// <example>
        /// GET /api/J1/DogTreats/3/1/0 -> "The dog is Sad"
        /// </example> 
        /// <example>
        /// GET /api/J1/DogTreats/3/2/1 -> "The dog is Happy"
        /// </example>
        [HttpGet]
        [Route("api/J1/DogTreats/{smallTreats}/{medTreats}/{largeTreats}")]
        public string HappinessMeter(int smallTreats, int medTreats, int largeTreats)
        {
            int sTreatHappiness = smallTreats * 1;
            int mTreatHappiness = medTreats * 2;
            int lTreatHappiness = largeTreats * 3;

            int happiness = sTreatHappiness + mTreatHappiness + lTreatHappiness;

            string state;

            if (happiness >= 10)
            {
                state = "Happy";
            }
            else
            {
                state = "Sad";
            }

            string response = "The dog is " + state;

            return response;
        }
    }
}
