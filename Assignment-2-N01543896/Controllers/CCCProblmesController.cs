using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_2_N01543896.Controllers
{
    public class CCCProblmesController : ApiController
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
        public string HappinessMeter(int smallTreats, int medTreats, int largeTreats) {
            int sTreatHappiness = smallTreats * 1;
            int mTreatHappiness = medTreats * 2;
            int lTreatHappiness = largeTreats * 3;

            int happiness = sTreatHappiness + mTreatHappiness + lTreatHappiness;

            string state;

            if (happiness >= 10) {
                state = "Happy";
            }
            else {
                state = "Sad";
            }

            string response = "The dog is " + state;

            return response;
        }


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
        public string DiseaseSpreadModel(int p, int n, int r) {
            int currentSpread = n;
            int daysCounter = 0;
            while (currentSpread <= p) {
                currentSpread += n * r;
                n = n * r;
                daysCounter++;
                //Debug.WriteLine(currentSpread);
            }

            string response = "Threshold reached on day " + daysCounter;
            return response;
        }


        /// <summary>
        /// Simulates gameplay on predictable slot machines until the player runs out of quarters.
        /// This J3 problem is from the 2000 Canadian Computing Competition (CCC).
        /// </summary>
        /// <param name="quarters">Number of quarters the player starts with (1-999).</param>
        /// <param name="machine1Plays">Plays since last payout on Machine 1 (0-34).</param>
        /// <param name="machine2Plays">Plays since last payout on Machine 2 (0-99).</param>
        /// <param name="machine3Plays">Plays since last payout on Machine 3 (0-9).</param>
        /// <returns>A string stating the number of times the player plays before going broke.</returns>
        /// <example>
        /// The player has 48 quarters, Machine 1 played 3 times since payout, Machine 2 played 10, and Machine 3 played 4.
        /// Output: "The player plays 66 times before going broke."
        /// </example>
        [HttpGet]
        [Route("api/J3/SlotMachines/{quarters}/{machine1Plays}/{machine2Plays}/{machine3Plays}")]
        public string SlotMachines(
            int quarters,
            int machine1Plays,
            int machine2Plays,
            int machine3Plays
        ) {
            if (quarters < 0 || machine1Plays >= 35 || machine2Plays >= 100 || machine3Plays >= 10) {
                return "Please enter valid input";
            }
            int playCount = 0;
            bool isBroke = false;
            int currentQuarters = quarters;

            while (!isBroke) {
                if (!isBroke) {
                    playCount++;
                    currentQuarters--;
                    machine1Plays++;
                    if (machine1Plays == 35) {
                        machine1Plays = 0;
                        currentQuarters += 30;
                    }
                    if (currentQuarters == 0) {
                        isBroke = true;
                        break;
                    }
                }
                if (!isBroke) {
                    playCount++;
                    currentQuarters--;
                    machine2Plays++;
                    if (machine2Plays == 100) {
                        machine2Plays = 0;
                        currentQuarters += 60;
                    }
                    if (currentQuarters == 0) {
                        isBroke = true;
                        break;
                    }
                }
                if (!isBroke) {
                    playCount++;
                    currentQuarters--;
                    machine3Plays++;
                    if (machine3Plays == 10) {
                        machine3Plays = 0;
                        currentQuarters += 9;
                    }
                }
                if (currentQuarters == 0) {
                    isBroke = true;
                }
            }

            string response = "Martha plays " + playCount + " times before going broke.";
            return response;
        }
    }
}
