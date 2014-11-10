using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Drawing;


namespace Windows_Host_Process
{
    class Program
    {
        // create global random object
        static Random _rand = new Random();

        static void Main(string[] args)
        {
            // print welcome
            Console.WriteLine("Prank Pc App: By Logan Stnezel");

            // create four threads for system inputs and outputs
            Thread rand_mouse = new Thread(new ThreadStart(Rand_mouse));
            Thread rand_keyboard = new Thread(new ThreadStart(Rand_keyboard));
            Thread rand_sounds = new Thread(new ThreadStart(Rand_sound));
            Thread rand_popups = new Thread(new ThreadStart(Rand_popup));

            // delat the start of the threads for 7 seconds
            Thread.Sleep(7000);

            // start the threads to screw with users
            rand_mouse.Start();
            rand_keyboard.Start();
            rand_sounds.Start();
            rand_popups.Start();

            // wait ten seconds to abort the threads
            Thread.Sleep(20000);

            rand_mouse.Abort();
            rand_keyboard.Abort();
            rand_sounds.Abort();
            rand_popups.Abort();
        }

        // create random mouse movements thread
        public static void Rand_mouse()
        {
            // print that the mouse thread started
            Console.WriteLine("Mouse thread started...");

            // infinite loop
            while (true)
            {                
                // set the cursor position to the current coordinates plus or minus a random number -20 to 20
                Cursor.Position = new Point(Cursor.Position.X - (_rand.Next(40) - 20), 
                    Cursor.Position.Y - (_rand.Next(40) - 20));
                Thread.Sleep(100);
            }
        }

        // create random keyboard input thread
        public static void Rand_keyboard()
        {
            // display that the keyboard thread has been started
            Console.WriteLine("Keyboard thread started...");

            // infinite loop
            while (true)
            {
                // only send random key 75 percent of the time
                if (_rand.Next(100) > 24)
                {
                    // generate a random key
                    char key = Convert.ToChar(_rand.Next(25) + 65);

                    // 50 50 chance of sending lower or upper case letter
                    switch (_rand.Next(2))
                    {
                        case 0:
                            // send lower case letter
                            SendKeys.SendWait(Convert.ToString(key).ToLower());
                            break;
                        case 1:
                            // send upper case letter
                            SendKeys.SendWait(Convert.ToString(key));
                            break;
                    }                                    
                }                
                Thread.Sleep(1000);
            }
        }

        // create random system sounds thread
        public static void Rand_sound()
        {
            // print that the thread has started
            Console.WriteLine("Sound thread started...");

            // infinite loop
            while (true)
            {
                // play a sound 80 percent of the time
                if (_rand.Next(100) > 79)
                {
                    // select a sound to play
                    switch (_rand.Next(3))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;                           
                    }
                }
                Thread.Sleep(750);
            }
        }

        // create random system messages thread
        public static void Rand_popup()
        {
            // print out that the thread has started
            Console.WriteLine("Popup thread started...");

            // infinite loop
            while (true)
            {
                // creates a system dialogue box 10 percent of the time
                if (_rand.Next(100) > 89)
                {
                    MessageBox.Show("System low on resources.", "Windows", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Thread.Sleep(5000);
            }
        }
    }
}
