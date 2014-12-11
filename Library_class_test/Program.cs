using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prime_Generator_Beta_V1;
using ICFCE;

namespace Library_class_test
{
    class Program
    {
        static void Main(string[] args)
        {
            encrypt tmp = new encrypt("hello world");
            tmp.to_ascii();
        }
    }
}
