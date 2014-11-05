using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProb1
{
    class Program
    {
        /// <summary>
        /// the chalange is to find the sum of all the multiples of 3 and 5
        /// up to 1000
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // create a list to hold nums
            //List<int> nums = new List<int>();

            // create sum variable
            int sum = 0;

            // create an array to hold 3's and 5's
            int[] three = new int[333];
            int [three] = new int[66];

            // secondary counter
            int counter2 = 0;

            // loop that executes twice
            for (int foobar = 3; foobar < 6; foobar = foobar + 2)
            {
                // get list of multiples of 3 and 5
                for (int counter = 0; counter <= 1000; counter = counter + foobar)
                {
                    //check if were finder three's or fives
                    switch(foobar)
                    //if (!nums.Contains(counter))
                    //{
                    //    // add value to nums
                    //    nums.Add(counter);
                    //}  

                    // check to see if the pot num is already in nums
                    if (! nums.Contains(counter))
                    {
                        nums[counter2++] = counter;
                    }
                    // sums the multiplies of 3 then combines with 5's
                    sum = sum + nums.Sum();
                }
            }
            // print results
            Console.WriteLine(sum - 1000);
        }
    }
}
