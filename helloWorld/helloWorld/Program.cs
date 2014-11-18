using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

// this is the namespace
namespace helloWorld
{
    // this is a class
    class Program
    {
        // this is the main function
        static void Main(string[] args)
        {
            // loop through string test
            string test = "hello";
            char[] tmp_array = test.ToCharArray();
            Array.Reverse(tmp_array);
            test = new string(tmp_array);
            Console.WriteLine(test);
            foreach (char chr in test)
            {
                Console.WriteLine(chr);
            }

            //changes console colors
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            // writes hello world to console
            Console.WriteLine("Hello world");
            //ask for input
            Console.Write("Type in whatever madness you want: ");
            // gets user input
            string input = Console.ReadLine();
            // writes users input to screen
            Console.WriteLine("You typed in: {0}", input);
            // call foobar
            foobar();      
            // call loop
            loop();

            // random var
            string str = "hello";
            // example switch
            switch (str)
            {
                case "hello":
                    Console.WriteLine("hello");
                    break;
                case "apples":
                    Console.WriteLine("apples");
                    break;
                default:
                    Console.WriteLine("loser");
                    break;
            }
            // playing around with text to speech
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("hello world");
        }
        // a function to do math!
        static void foobar()
        {
            // ask for a number
            Console.Write("Enter a NUMBER: ");
            // get input
            string input = Console.ReadLine();
            // ask for a number
            Console.Write("Enter a NUMBER: ");
            // get input
            string input2 = Console.ReadLine();
            // print the conversion
            Console.WriteLine("Your numbers is: {0}", Convert.ToInt16(input) + Convert.ToInt16(input2));
        }
        static void loop()
        {
            // this is a four loop
            for (int counter = 0; counter <= 100; counter++)
            {
                Console.WriteLine("I've done this {0} times alreeady!", counter);
            }
        }
    }
}
