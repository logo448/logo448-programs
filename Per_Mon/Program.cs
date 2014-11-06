using System;
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
        static void Main(string[] args)
        {           
            #region initalize_objects
            // create performence monitor objects
            PerformanceCounter cpu_perc = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            PerformanceCounter mem_open = new PerformanceCounter("Memory", "Available MBytes");
            PerformanceCounter uptime = new PerformanceCounter("System", "System Up Time");

            // initailize uptime
            uptime.NextValue();

            // initailize speech object
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // create random object
            Random rand = new Random();
            #endregion

            // welcome user via print and audio
            string welcome = "Welcome to System Monitor! By: Logan Stenzel";
            Console.WriteLine(welcome);
            synth.Speak(welcome);
            Console.WriteLine(uptime_to_string(uptime));

            // variable to keep track of elapsed time
            int elapsed_time = 0;

            //infinite while loop
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

                // increment time variable by 5
                elapsed_time = elapsed_time + 5;

                // check to see if program has been on for an interval of an hour
                if (elapsed_time % 3600 == 0)
                {
                    // tell user that one hour has elapsed
                    Console.WriteLine(uptime_to_string(uptime));
                    Console.WriteLine();
                    synth.Speak("one hour has elapsed");
                }

                // pause 5 seconds
                Thread.Sleep(5000);
            }
        }
        /// <summary>
        /// convert the system uptime in seconds to d/h/m/s
        /// </summary>
        /// <returns></returns>
        static string uptime_to_string(PerformanceCounter uptime)
        {
            TimeSpan uptime_val = TimeSpan.FromSeconds(uptime.NextValue());
            string uptime_string = string.Format("Current system up time: {0}D/{1}H/{2}M/{3}S",
                uptime_val.Days,
                uptime_val.Hours,
                uptime_val.Minutes,
                uptime_val.Seconds);
            return uptime_string;
        }
    }
}
