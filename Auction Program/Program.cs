using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Synthesis;
using System.Threading;

namespace Auction_Program
{
    class Program
    {
        // create a global sythesizer
         static SpeechSynthesizer _synth = new SpeechSynthesizer();

        // create a global random object
        static Random _rand = new Random();

        // global var to hold current bid
        static int _bid = 0;

        // global var to hold previous bid
        static int _prev = 0;

        static void Main(string[] args)
        {
            #region set up
            // Introduce the program
            Console.WriteLine("Auction program: by Logo");

            // call function to convert starting_price to int and assing in to new variable
            int starting_price = get_input("What do you want the starting price to be, Sir?: ", 0);
            #endregion

            // infinite loop
            while (true)
            {
                // set cursor position to the beggining of the 3rd line
                Console.SetCursorPosition(0, 2);

                // clear 3rd line
                Console.Write(new string(' ', Console.BufferWidth));

                // reset cursor position to the beggining of the 3rd line
                Console.SetCursorPosition(0, 2);

                // print current bid to the screen
                Console.WriteLine("Current bid: {0}", _bid);

                // set cursor position to the beginning of the fourth line
                Console.SetCursorPosition(0, 3);

                // clear the 4th line
                Console.Write(new string(' ', Console.BufferWidth));

                // reset console position to the beggining of the fourth line
                Console.SetCursorPosition(0, 3);

                // set variable to hold previous bid
                _prev = _bid;

                // get new bid
                _bid = get_input("New bid: ", 0);

                _bid = bid_over_prev(_bid, _prev, 0);
            }
        }

        /// <summary>
        /// function to get user input and output it as an int
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        static int get_input(string print_msg, int error_count)
        {
            // ask the user for input
            Console.Write(print_msg);

            // get user input
            string msg = Console.ReadLine();

            // bool switch to see if no exception is thrown
            bool bool_switch = true;

            // error handling
            try
            {
                // convert starting price to an integer and return result
                return Convert.ToInt32(msg);
            }
            // if error was thrown
            catch (System.FormatException)
            {
                // tell user to enter a string not a number
                Console.WriteLine("Sir, enter a number not a string!");

                // switch bool switch to reflect error
                bool_switch = false;

                // recall function
                return get_input(print_msg, ++error_count);
            }
            // run no matter what after execution of try and catch
            finally
            {
                // if no error was thrown this time but their was an error in a prior call and this function call was for the 
                // new bid, clear the prompts to enter an integer
                if (bool_switch && error_count >= 1)
                {
                    // get the starting column of the cursor
                    int start = Console.CursorTop - 1;

                    // execute this loop once for every line I want deleted
                    for (int i = 0; i < error_count * 2; i++)
                    {
                        //Console.WriteLine(start + (error_count * 2));
                        // set cursor at the beggining of the extra line nearest the bottom
                        Console.SetCursorPosition(0, (start - i));

                        // clear the line
                        Console.Write(new string(' ', Console.BufferWidth));
                    }                 
                }
            }
        }

        static int bid_over_prev(int bid, int prev, int error_count)
        {
            // check to see if bid is over previous 
            if (bid > prev)
            {
                //Console.WriteLine(error_count);
                int start = Console.CursorTop - 1;

                if (error_count > 0)
                {
                    for (int i = 0; i < error_count * 2; i++)
                    {
                        Console.SetCursorPosition(0, (start - i));
                        Console.Write(new string(' ', Console.BufferWidth));
                    }
                }

                // return the bid
                return bid;
            }
            // else
            else
            {
                // tell the user their bid need to be higher then the previous bid
                Console.WriteLine("Sir, your bid needs to be above the current bid!");

                // get new bid
                bid = get_input("New bid: ", 0);

                // recal function with new bid
                return bid_over_prev(bid, prev, ++error_count);
            }
            
        }
    }
}