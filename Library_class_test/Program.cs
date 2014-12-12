using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prime_Generator_Beta_V1;
using ICFCE;
using ConsoleHotKey;
using System.Windows.Forms;

namespace Library_class_test
{
    class Program
    {
        static void Main(string[] args)
        {
            encrypt tmp = new encrypt("hello world");
            tmp.to_ascii();

            // test console hotkey
            HotKeyManager.RegisterHotKey(Keys.S, KeyModifiers.Alt);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
            Console.ReadLine();
        }

        static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            Console.WriteLine("Hit me!");
        }
    }
}
