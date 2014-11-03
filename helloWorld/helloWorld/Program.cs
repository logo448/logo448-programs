using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// this is the namespace
namespace helloWorld
{
    // this is a class
    class Program
    {
        // this is the main function
        static void Main(string[] args)
        {
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
    }
}
