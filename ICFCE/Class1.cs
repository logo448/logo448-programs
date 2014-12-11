using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICFCE
{
    /// <summary>
    /// main class that encrypts data
    /// </summary>
    public class encrypt
    {
        // create a variable to hold the msg to be encrypted
        private string msg;

        // create a byte list withe the ascii values of each char is the msg 
        private List<byte> msg_ascii_list;

        /// <summary>
        /// constructor method will get the msg to be encrypted
        /// TODO get a file location
        /// </summary>
        public encrypt(string msg)
        {
            // assign the encrypt.msg private variable to the msg the user specifies
            this.msg = msg;
        }

        /// <summary>
        /// method to convert this.msg to a list of bytes
        /// </summary>
        public void to_ascii()
        {
            // create a byte array for the byte values each char in the string
            byte[] msg_ascii_array = Encoding.ASCII.GetBytes(this.msg);

            // convert the byte array to a list
            this.msg_ascii_list = msg_ascii_array.ToList();
        }

        public void add_cipher()
        {
            
        }
    }
}
