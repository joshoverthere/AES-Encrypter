using System;
using System.Threading;
using System.Text;

namespace AES
{
    class Program
    {
        
        static List<List<string>> generateState(List<string> block)
        {
            List<List<string>> state = new List<List<string>>();    
            return state;
        }

        //This function breaks a list of bytes into lists (blocks) of 16 bytes each (adding empty bytes so that all blocks are full)
        static List<List<string>> breakBlocks(List<string> bytes)
        {
            List<List<string>> blocks = new List<List<string>>();

            //add empty bytes if the number of bytes is not divisible by 16
            if (bytes.Count % 16 != 0)
            {
                Console.WriteLine("Adding empty bytes...");
                for (int i = 0; i < (bytes.Count%16); i++)
                {
                    bytes.Add("00000000");
                }
            }

            //create blocks of 16 bytes each and add them to the list of blocks
            while (bytes.Count > 0)
            {
                List<string> block = new List<string>();
                for (int i = 0; i < 16; i++)
                {
                    block.Add(bytes[0]);
                    bytes.RemoveAt(0);
                }
                blocks.Add(block);
            }

            Console.WriteLine("Number of blocks : " + blocks.Count.ToString());
            

            return blocks;

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

                List<List<string>> blocks = breakBlocks(bytes);

                

            }
        }
    }
}