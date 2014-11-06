﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Threading;


namespace Per_Mon
{
    class Program
    {
        #region initalize_objects
        // create performence monitor objects
        public static PerformanceCounter cpu_perc = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        public static PerformanceCounter mem_open = new PerformanceCounter("Memory", "Available MBytes");
        public static PerformanceCounter uptime = new PerformanceCounter("System", "System Up Time");        

        // initailize speech object
        public static SpeechSynthesizer synth = new SpeechSynthesizer();

        // create random object
        public static Random rand = new Random();

        #endregion

        static void Main(string[] args)
        {
            // initailize uptime
            uptime.NextValue();

            // assign system uptime to a temp variable
            string uptime_string = uptime_to_string();

            // welcome user via print and audio
            string welcome = "Welcome to System Monitor! By: Logan Stenzel";
            Console.WriteLine(welcome);
            synth.Speak(welcome);
            Console.WriteLine(uptime_string);
            synth.Speak(uptime_string);

            // variable to keep track of elapsed time
            int elapsed_time = 0;

            //variables to see how many times cpu percent has gone above certain thresholds
            int eighty_percent_tracker = 0;
            int hundred_percent_tracker = 0;

            // infinite while loop
            while (true) 
            {
                // get current stats
                float cpu_val = cpu_perc.NextValue(); 
                float mem_val = mem_open.NextValue();

                // formate the current stats into strings
                string cpu_string = string.Format("The current CPU percentage used is: {0}%", cpu_val);
                string mem_string = string.Format("The current memory available in MB is: {0}MB", mem_val);

                // display current stats
                Console.WriteLine(cpu_string);
                Console.WriteLine(mem_string);
                Console.WriteLine();

                #region time_logic
                // increment time variable by 5
                elapsed_time = elapsed_time + 5;

                // check to see if program has been on for an interval of an hour
                if (elapsed_time % 3600 == 0)
                {
                    // tell user that one hour has elapsed
                    Console.WriteLine(uptime_to_string());
                    Console.WriteLine();
                    synth.Speak("one hour has elapsed");
                }

                // check to see if program has been running for about 15 minutes
                if (elapsed_time % 900 == 0)
                {
                    // speak current stats
                    synth.Speak(cpu_string);
                    synth.Speak(mem_string);

                    // reset eighty and hundred percent trackers every 15 minutes
                    eighty_percent_tracker = 0;
                    hundred_percent_tracker = 0;
                }
                #endregion

                #region cpu_logic
                // check to see if cpu usage is over 80 percent and has been repeated less then 5 times
                if (cpu_val > 80 && eighty_percent_tracker < 5)
                {
                    synth.Speak(cpu_string);
                    eighty_percent_tracker++;
                }

                // check to see if cpu usage is 100 percent and has been repeated less then 7 times
                if (cpu_val == 100 && hundred_percent_tracker < 7)
                {
                    synth.Speak("Holy Balls");
                    hundred_percent_tracker++;
                }
                #endregion

                // pause 5 seconds
                Thread.Sleep(2500);
            }
        }
        /// <summary>
        /// convert the system uptime in seconds to d/h/m/s
        /// </summary>
        /// <returns></returns>
        static string uptime_to_string()
        {
            TimeSpan uptime_val = TimeSpan.FromSeconds(uptime.NextValue());
            string uptime_string = string.Format("Current system up time: {0} Days {1} Hours {2} Minutes {3} Seconds",
                uptime_val.Days,
                uptime_val.Hours,
                uptime_val.Minutes,
                uptime_val.Seconds);
            return uptime_string;
        }
    }
}
