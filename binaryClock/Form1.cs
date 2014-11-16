using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace binaryClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// create and start the main thread on load of the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // create the main thread
            Thread main = new Thread(new ThreadStart(Main));

            // start the main thread
            main.Start();
        }

        /// <summary>
        /// main function
        /// </summary>
        private void Main()
        {
            #region prepare for main loop of function
            // set the current time to a variable
            TimeSpan cur_time = DateTime.Now.TimeOfDay;

            // set a sleep var variable to determine how long to sleep in between each loop
            // initially set to adjust for the current time
            int sleep_var = (60 - cur_time.Seconds) * 1000;       

            // variable to hold current hour and minutes
            int hour = (cur_time.Hours) - 12;
            int mins = cur_time.Minutes;

            // variable to hold current hour and minutes in binary
            string hr_binary;
            string min_binary;
            #endregion

            // infinite loop
            while (true)
            {
                // get current mins
                mins = cur_time.Minutes;

                // check to see if it is a new hour
                if (mins == 0)
                {
                    // set the hour
                    hour = (cur_time.Hours) - 12;
                }

                // convert hrs and mins to binary
                hr_binary = Convert.ToString(hour, 2);
                min_binary = Convert.ToString(mins, 2);

                // reverse the binary digits
                char[] tmp = min_binary.ToCharArray();
                Array.Reverse(tmp);
                min_binary = new string(tmp);
                char[] tmp_1 = hr_binary.ToCharArray();
                Array.Reverse(tmp_1);
                hr_binary = new string(tmp_1);

                #region append zeros to end of binary numbers if numbers aren't large enough
                // check to see if min_binary is long enough
                if (min_binary.Length < 6)
                {
                    // find how many more zeros are needed
                    int zeros_needed = 6 - min_binary.Length;

                    // add the appropriate amoun of zeros
                    for (int i = 0; i < zeros_needed; i++)
                    {
                        min_binary = min_binary + "0";
                    }
                }

                // check to see if hr_binary is long enough
                if (hr_binary.Length < 4)
                {
                    // find how many more zeros are needed
                    int zeros_needed = 4 - hr_binary.Length;

                    // add the appropriate amoun of zeros
                    for (int i = 0; i < zeros_needed; i++)
                    {
                        hr_binary = hr_binary + "0";
                    }
                }
                #endregion

                // check the correct checkboxes
                // hours
                

                // adjust for the time it took to do the calculations
                sleep_var = (60 - cur_time.Seconds) * 1000;

                // sleep for x seconds
                Thread.Sleep(sleep_var);
            }
        }
    }
}
