using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Generator_Beta_V1
{
<<<<<<< HEAD
    public static class generate_primes
    {
        /// <summary>
        /// Main function. The function searches for prime numbers
        /// under the end parameter
        /// </summary>
        /// <param name="end"></param>
        /// <returns>
        /// returns an int list containing prime number
        /// </returns>
        public static List<int> start_generate(int end)
        {
            // create variable for potential primes
            int pp = 2; 

            // variable to hold prime that isn't necessary for testing other pps
            int no_test_primes = pp;

            // advance pp by one
            pp++;

            // create variable to hold primes needed for testing
            List<int> tp = new List<int>();
            // add 3 to test primes
            tp.Add(pp);

            // create variable to hold square root of pp
            double pp_sqrt;
            
            // boolean switch to see if pp should be added to tp
            bool bool_switch = true;

            // infinite loop
            while (true)
            {
                // increment pp by 2
                pp = pp + 2;

                // check if pp is greater then end
                if (pp > end)
                {
                    // break if pp is bigger then end
                    break;
                }

                // set pp_sqrt to the square root of pp
                pp_sqrt = Math.Sqrt(System.Convert.ToDouble(pp));

                // loop through every value in test primes and assign them to i
                foreach (int i in tp)
                {
                    // test if i is greater then pp_sqrt. Break if true
                    if (i > pp_sqrt) { break; }

                    // check to see if pp is evenly divisible by each tp
                    // if true then set bool_switch to false and break loop
                    if (pp % i == 0) { bool_switch = false; break; }
                }

                // if the pp passes the tests in the foreach loop add it to the tp list
                if (bool_switch) { tp.Add(pp); }

                bool_switch = true;
            }

            // insert no test prime to the front of the tp list
            tp.Insert(0, no_test_primes);

            // return a list of all the primes
            return tp;
        }
=======
    public class generate
    {

>>>>>>> fa4e697e8112f118e4a1a4a2ee90e8c80ba7f485
    }
}
