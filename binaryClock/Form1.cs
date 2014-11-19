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
        /// start main thread on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // create the main thread
            Thread main = new Thread(new ThreadStart(Main_Loop));
            // set thread as background thread so it close automagically on app close
            main.IsBackground = true;
            // run the main thread
            main.Start();
        }

        /// <summary>
        /// main function
        /// </summary>
        private void Main_Loop()
        {
            #region prepare for main loop of function
            // set the current time to a variable
            TimeSpan cur_time = DateTime.Now.TimeOfDay;

            // set a sleep var variable to determine how long to sleep in between each iteration
            // initially set to adjust for the current time
            int sleep_var = (60 - cur_time.Seconds) * 1000;       

            // variables to hold current hour, minutes, and seconds
            int hour = cur_time.Hours;
            int mins = cur_time.Minutes;
            int secs = cur_time.Seconds;

            // variables to hold current hour, minutes, and seconds in binary
            string hr_binary;
            string min_binary;
            string sec_binary;
            #endregion

            // infinite loop
            while (true)
            {
                // update current time
                cur_time = DateTime.Now.TimeOfDay;
                // get current secs
                secs = cur_time.Seconds;               

                // check to see if it is a new second
                if (secs == 0)
                {
                    // set the minutes
                    mins = cur_time.Minutes;
                }

                // check to see if it is a new hour
                if (mins == 0)
                {
                    // set the hour
                    hour = cur_time.Hours;
                }

                // convert hrs, mins, and seconds to binary
                hr_binary = Convert.ToString(hour, 2);
                min_binary = Convert.ToString(mins, 2);
                sec_binary = Convert.ToString(mins, 2);

                #region append zeros to end of binary numbers if numbers aren't large enough
                // check to see if min_binary is long enough
                if (min_binary.Length < 6)
                {
                    // find how many more zeros are needed
                    int zeros_needed = 6 - min_binary.Length;

                    // add the appropriate amoun of zeros
                    for (int i = 0; i < zeros_needed; i++)
                    {
                        min_binary = "0" + min_binary;
                    }
                }

                // check to see if hr_binary is long enough
                if (hr_binary.Length < 5)
                {
                    // find how many more zeros are needed
                    int zeros_needed = 5 - hr_binary.Length;

                    // add the appropriate amoun of zeros
                    for (int i = 0; i < zeros_needed; i++)
                    {
                        hr_binary = "0" + hr_binary;
                    }
                }
                #endregion

                #region check and uncheck checkboxes
                #region hours

                // loop through hour binary string
                for (int i = 0; i < 5; i++)
                {
                    // get a digit of the hour binary string and store it in dig
                    string dig = hr_binary[i].ToString();

                    #region check to see if each checkbox should be on or off
                    // 16
                    if (i == 0 && dig == "1")
                    {
                        // create an action for the invoke method
                        // the action checks or unchecks a checkbox
                        Action action = () => checkBox11.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 0 && dig == "0")
                    {
                        // create an action for the invoke method
                        // the action checks or unchecks a checkbox
                        Action action = () => checkBox11.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 8
                    if (i == 1 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox4.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 1 && dig == "0")
                    {
                        // create an action for the invoke method
                        // the action checks or unchecks a checkbox
                        Action action = () => checkBox4.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 4
                    if (i == 2 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox3.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 2 && dig == "0")
                    {
                        // create an action for the invoke method
                        // the action checks or unchecks a checkbox
                        Action action = () => checkBox3.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 2
                    if (i == 3 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox2.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 3 && dig == "0")
                    {
                        // create an action for the invoke method
                        // the action checks or unchecks a checkbox
                        Action action = () => checkBox2.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 1
                    if (i == 4 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox1.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 4 && dig == "0")
                    {
                        // create an action for the invoke method
                        // the action checks or unchecks a checkbox
                        Action action = () => checkBox1.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    #endregion
                }
                #endregion

                #region mins

                // loop through mins binary string
                for (int i = 0; i < 6; i++)
                {
                    // get a digit of the hour binary string and store it in dig
                    string dig = min_binary[i].ToString();

                    #region check to see if each checkbox should be on or off
                    // 32
                    if (i == 0 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox10.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 0 && dig == "0")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox10.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 16
                    if (i == 1 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox9.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 1 && dig == "0")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox9.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 8
                    if (i == 2 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox8.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 2 && dig == "0")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox8.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 4
                    if (i == 3 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox7.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 3 && dig == "0")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox7.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 2
                    if (i == 4 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox6.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 4 && dig == "0")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox6.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    // 1
                    if (i == 5 && dig == "1")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox5.Checked = true;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    if (i == 5 && dig == "0")
                    {
                        // create an action for the invoke method
                        Action action = () => checkBox5.Checked = false;
                        // use invoke to access gui element from different thread
                        this.Invoke(action);
                    }
                    #endregion
                }
                #endregion
                #endregion

                // adjust for the time it took to do the calculations
                sleep_var = (60 - cur_time.Seconds) * 1000;

                // sleep for x seconds
                Thread.Sleep(sleep_var);
            }
        }

        // had to create a form closing event for main thread to autoclose
        // so I'm leaving this event empty
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
