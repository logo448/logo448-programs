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
        #region create global vars/obj's
        // create a global sythesizer
         static SpeechSynthesizer _synth = new SpeechSynthesizer();

        // create a global random object
        static Random _rand = new Random();

        // global var to hold current bid
        static int _bid = 0;

        // global var to hold previous bid
        static int _prev = 0;

        // create a global manual reset event to start and stop threads
        static ManualResetEvent _mre = new ManualResetEvent(true);

        // global bool switch indicating whether it is a new chant cycle
        static bool _new_chant = true;
        #endregion

        static void Main(string[] args)
        {
            #region set up
            // Introduce the program
            Console.WriteLine("Auction program: by Logo");

            // call function to convert starting_price to int and assing in to new variable
            int starting_price = get_input("What do you want the starting price to be, Sir?: ", 0);

            // variable to hold the synth.speak "i got" method call
            string tmp;

            // create thread that starts the auctioners chant
            Thread Chant = new Thread(new ThreadStart(chant));
            // start Chant thread
            Chant.Start();
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

                // check to see if the bid was over the previous bid
                _bid = bid_over_prev(_bid, _prev, 0);

                // pause the chant thread
                _mre.Reset();

                // plays an audio clip saying "I got" and then the bid
                _synth.Rate = 4;
                tmp = string.Format("I got {0}", _bid);
                _synth.Speak(tmp);

                // restart the Chant thread
                _mre.Set();

                // switch _new_chant to true so a new string will be spoken
                _new_chant = true;
            }
        }

        /// <summary>
        /// function to get user input and output it as an int
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>
        /// returns an integer that represents a users bid
        /// </returns>
        static int get_input(string print_msg, int error_count)
        {
            // ask the user for input
            Console.Write(print_msg);

            // get user input
            string msg = Console.ReadLine();

            // bool switch to see if no exception is thrown
            bool no_exception = true;

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
                Console.WriteLine("Sir, enter a integer not a string or decimal!");

                // switch bool switch to reflect error
                no_exception = false;

                // recall function
                return get_input(print_msg, ++error_count);
            }
            // run no matter what after execution of try and catch
            finally
            {
                // if no error was thrown this time but their was an error in a prior call and this function call was for the 
                // new bid, clear the prompts to enter an integer
                if (no_exception && error_count >= 1)
                {
                    // get the starting column of the cursor
                    int start = Console.CursorTop - 1;

                    // execute this loop once for every line I want deleted
                    for (int i = 0; i < error_count * 2; i++)
                    {
                        // set cursor at the beggining of the extra line nearest the bottom
                        Console.SetCursorPosition(0, (start - i));

                        // clear the line
                        Console.Write(new string(' ', Console.BufferWidth));
                    }
                    // set cursor position under last printed line of console
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }
            }
        }

        /// <summary>
        /// function to see if the users bid is over the previous bid
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="prev"></param>
        /// <param name="error_count"></param>
        /// <returns>
        /// returns an integer that represents the bid
        /// </returns>
        static int bid_over_prev(int bid, int prev, int error_count)
        {
            // check to see if bid is over previous 
            if (bid > prev)
            {
                int start = Console.CursorTop - 1;
                
                // check to see if their wer previous errors
                if (error_count > 0)
                {
                    // loop through two times the amount of errors to clear error messages
                    for (int i = 0; i < error_count * 2; i++)
                    {
                        // set cursor position at the end of the line to be cleared
                        Console.SetCursorPosition(0, (start - i));
                        // clear the line of text were the cursor was located
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

        /// <summary>
        /// function that uses global bid variable to call for another bid
        /// </summary>
        static void chant()
        {
            // array of strings with possible chants 
            string[] poss_chants = { "give me ", "able to bid ", "how bout " };

            // local copy of _bid that is one ahead of _bid
            int bid = _bid + 1;

            // initialize variable to hold random digit
            int rand = 0;

            // infinite while loop
            while (true)
            {
                // check to see if it is a new chant
                if (_new_chant)
                {
                    // get a random digit from _rand and assign it to rand
                    rand = _rand.Next(0, 3);

                    // set _new_chant to false
                    _new_chant = false;
                }

                // reset value of bid to _bid + 1
                bid = _bid + 1;

                // set _synth to four times normal
                _synth.Rate = 4;

                // say one of the random phrases twice 
                _synth.Speak(poss_chants[rand] + bid.ToString());

                // check to see if thread should be paused
                _mre.WaitOne();
            }
        }
    }
}