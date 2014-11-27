using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prime_Generator_Beta_V1;

namespace Library_class_test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(generate_primes.start_generate(1000).Capacity);
        }
    }
}
