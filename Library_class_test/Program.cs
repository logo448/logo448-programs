using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using Prime_Generator_Beta_V1;

namespace Library_class_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stp = new Stopwatch();
            stp.Start();
            Console.WriteLine(generate_primes.start_generate(20000).Capacity);
            stp.Stop();
            Console.WriteLine(stp.ElapsedMilliseconds);
        }
    }
}
