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
            int sleep_var = 1000 - cur_time.Milliseconds;       

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
                #region get current time
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
                #endregion

                // convert hrs, mins, and seconds to binary
                hr_binary = Convert.ToString(hour, 2);
                min_binary = Convert.ToString(mins, 2);
                sec_binary = Convert.ToString(secs, 2);

                #region append zeros to end of binary numbers if numbers aren't large enough
                // call append zeros function for hours
                hr_binary = append_zeros(hr_binary, 5);

                // call append zeros function for minutes 
                min_binary = append_zeros(min_binary, 6);

                // call append zeros function for seconds
                sec_binary = append_zeros(sec_binary, 6);
                #endregion

                #region check and uncheck checkboxes

                #region hours
                // create tmp array to initilize list
                CheckBox[] tmp = {checkBox11,
                    checkBox4,
                    checkBox3,
                    checkBox2,
                    checkBox1};
                // create list with contents of the tmp array
                // the list contains checkboxes
                List<CheckBox> input = new List<CheckBox>(tmp);

                // call checkboxes function on the hr_binary string
                checkboxes(input, hr_binary);
                #endregion

                #region mins
                // create tmp array to initilize a list
                CheckBox[] tmp1 = {checkBox10,
                                 checkBox9,
                                 checkBox8,
                                 checkBox7,
                                 checkBox6,
                                 checkBox5};
                // create list with the contents of the tmp array
                // the list holds checkboxes
                List<CheckBox> input1 = new List<CheckBox>(tmp1);

                // call checkboxes function on min_binary string
                checkboxes(input1, min_binary);
                #endregion

                #region seconds
                // create a tmp array to initilize list with
                CheckBox[] tmp2 = {checkBox17,
                                  checkBox16,
                                  checkBox15,
                                  checkBox14,
                                  checkBox13,
                                  checkBox12};
                // create list wiht contents of the tmp array
                // the list holds checkboxes
                List<CheckBox> input2 = new List<CheckBox>(tmp2);

                // call checkboxes function on sec_binary sting
                checkboxes(input2, sec_binary);
                #endregion
                #endregion

                // adjust for the time it took to do the calculations
                sleep_var = 1000 - cur_time.Milliseconds;

                // sleep for x seconds
                Thread.Sleep(sleep_var);
            }
        }

        // had to create a form closing event for main thread to autoclose
        // so I'm leaving this event empty
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// function to append zeros to binary strings if the sting isn't long enough
        /// two inputs: the binary sting and the desired length
        /// </summary>
        /// <param name="bin"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private string append_zeros(string bin, int len)
        {
            // check to see if bin is long enough
            if (bin.Length < len)
            {
                // find how many more zeros are needed
                int zeros_needed = len - bin.Length;

                // add the appropriate amoun of zeros
                for (int i = 0; i < zeros_needed; i++)
                {
                    bin = "0" + bin;
                }
                
                // return binary string
                return bin;
            }

            // if bin is already long enough return bin
            else
            {
                // return binary string
                return bin;
            }
        }

        /// <summary>
        /// a function to check and uncheck checkboxes
        /// this function is recursive
        /// </summary>
        /// <param name="boxes"></param>
        private Tuple<string, List<CheckBox>> checkboxes(List<CheckBox> boxes, string bin_str)
        {
            // get current binary digit
            string dig = bin_str[0].ToString();

            // base case
            if (bin_str.Length == 1)
            {
                // check/uncheck the proper checkbox
                // check if checkbox should be checked
                if (dig == "1")
                {
                    // create an action for the invoke method
                    Action action = () => boxes[0].Checked = true;
                    // use invoke to access gui element from different thread
                    this.Invoke(action);
                }
                // check if checkbox should be unchecked
                if (dig == "0")
                {
                    // create an action for the invoke method
                    Action action = () => boxes[0].Checked = false;
                    // use invoke to access gui element from different thread
                    this.Invoke(action);
                }

                // return nothing
                return null;
            }

            // case
            else
            {
                // check/uncheck the proper checkbox
                // check if checkbox should be checked
                if (dig == "1")
                {
                    // create an action for the invoke method
                    Action action = () => boxes[0].Checked = true;
                    // use invoke to access gui element from different thread
                    this.Invoke(action);
                }
                // check if checkbox should be unchecked
                if (dig == "0")
                {
                    // create an action for the invoke method
                    Action action = () => boxes[0].Checked = false;
                    // use invoke to access gui element from different thread
                    this.Invoke(action);
                }

                // decrease length of the binary string and checkbox array
                var output = Tuple.Create(bin_str.Substring(1), boxes.GetRange(1,(boxes.Capacity - 1)));

                // call function again with shorter binary string and checkbox array
                return checkboxes(output.Item2, output.Item1);
            }
        }
    }
}
