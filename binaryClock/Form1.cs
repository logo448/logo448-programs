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

            // infinite loop
            while (true)
            {
                // get current mins
                mins = cur_time.Minutes;

                // check to see if it is a new hour
                if (mins == 0)
                {
                    hour = (cur_time.Hours) - 12;
                }

                // convert hrs and mins to binary
                hr_binary = Convert.ToString(mins, 2);
                min_binary = Convert.ToString(hour, 2);

                // debug 
                MessageBox.Show(hr_binary);
                MessageBox.Show(min_binary);

                // adjust for the time it took to do the calculations
                sleep_var = (60 - cur_time.Seconds) * 1000;

                // sleep for x seconds
                Thread.Sleep(sleep_var);
            }
        }
    }
}
