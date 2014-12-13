using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Threading;

// this is the namespace
namespace helloWorld
{
    // this is a class
    class Program
    {
        // this is the main function
        static void Main(string[] args)
        {
            // infinite loop
            while (true)
            {
                // test mouse position
                Console.WriteLine(Cursor.Position);

                // sleep for one second
                Thread.Sleep(1000);
            }           
        }
    }
}
