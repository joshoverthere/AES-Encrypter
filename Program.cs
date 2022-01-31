using System;
using System.Threading;
using System.Text;

namespace AES
{
    class Program
    {
        
        static string[,] generateState(string message)
        {
            string[,] state = new string[4,4];
            return state;
        }

        static List<string[]> breakBlocks(List<string> bytes)
        {
            List<string[]> blocks = new List<string[]>();

            if (bytes.Count % 16 != 0)
            {
                Console.WriteLine("Adding empty bytes...");
                for (int i = 0; i < (bytes.Count%16); i++)
                {
                    bytes.Add("00000000");
                }
            }

            

            return blocks;
            //This function breaks a 1D array of bytes into blocks of 16 bytes each (adding empty bytes so that all blocks are full)

        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                //allow user to input message and key
                Console.Write("Enter message: ");
                string message = Console.ReadLine();
                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                //format message
                message = message.ToLower();
                message = message.Replace(" ", "");

                //convert message to bytes of ascii
                byte[] asciiBytes = Encoding.ASCII.GetBytes(message);

                //convert ascii bytes to binary bytes and add them to list of bytes
                List<string> bytes = new List<string>();
                foreach (byte element in asciiBytes)
                {
                    bytes.Add(Convert.ToString(element, 2));
                }

                List<string[]> blocks = breakBlocks(bytes);

                

            }
        }
    }
}