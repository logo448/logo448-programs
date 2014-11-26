using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProb12
{
    class Program
    {
        static void Main(string[] args)
        {
            // variable for bool switch
            bool bool_switch = true;

            // create a count variable
            int count = 2;

            // create a prev triangle number variable
            int prev = 1;

            // create a variable for current triangle number
            int tri = 0;

            // loop till answer is found
            while (bool_switch)
            {
                #region generate triangle number
                // set value for the current tri number
                tri = prev + count;

                // set prev = to current tri number
                prev = tri;

                // increment count by one
                count++;
                #endregion

                #region check tri numbers for eligibility
                // list to store the tri numbers factors
                List<int> factors = new List<int>();

                // add 1 and the tri number to the factors list
                factors.Add(1);
                factors.Add(tri);

                // check to see if tri is divisible by two
                if (tri % 2 == 0)
                {
                    // add two to the factors list
                    factors.Add(2);
                }

                // check to see if solution has been foundd!
                if (factors.Capacity >= 500)
                {
                    // print the tri number
                    Console.WriteLine(tri);

                    // switch the binary switch
                    bool_switch = false;
                }
            }
        }
    }
}
