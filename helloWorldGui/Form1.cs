using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helloWorldGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Print hello world when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Hello World\n");
        }
       
        /// <summary>
        /// when the mouse enters the button print get off of me
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Get off of me filty mouse!\n");
        }

        /// <summary>
        /// when the mouse leaves the button print thank you
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Finally you got of of me, Now don't even think about clicking me...\n");
        }
    }
}
