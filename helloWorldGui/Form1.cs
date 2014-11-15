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
        /// when the mouse enters the button print get off of me and
        /// check a radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            // print text to the rich text box
            richTextBox1.AppendText("Get off of me filty mouse!\n");

            // check radio button
            radioButton1.Checked = true;
        }

        /// <summary>
        /// when the mouse leaves the button print thank you
        /// and uncheck radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Finally you got of of me, Now don't even think about clicking me...\n");

            // uncheck radio button
            radioButton1.Checked = false;
        }

        /// <summary>
        /// exits the program is someone presses the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exit
            this.Close();
        }

        /// <summary>
        /// prints text to the rich text box if about button is clicked
        /// and popup a message box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            // apend text to the text box
            richTextBox1.AppendText("\n\n This is a GUI sandbox created by Logan Stenzel\n\n");

            // popup a message box
            MessageBox.Show("This is a GUI sandbox created by Logan Stenzel", "Hello WORLD", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
