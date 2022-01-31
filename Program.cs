using System;
using System.Threading;
using System.Text;

namespace AES
{
    class Program
    {
        
        static byte[,] generateState(string message)
        {
            byte[,] state = new byte[4,4];
            return state;
        }

        static List<byte[]> breakBlocks(List<byte> bytes)
        {
            List<byte[]> blocks = new List<byte[]>();

            Console.WriteLine(bytes.Count);
            
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


                byte[] asciiBytes = Encoding.ASCII.GetBytes(message);

                // Loop through contents of the array.
                foreach (byte element in asciiBytes)
                {
                    Console.WriteLine(Convert.ToString(element, 2));

                }

                

            }
        }
    }
}