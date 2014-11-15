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

            // infinite loop
            while (true)
            {
                // sleep for x seconds
                Thread.Sleep(sleep_var);
                sleep_var = 60000;
            }
        }
    }
}
