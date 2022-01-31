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

        static breakBlocks(string bytes)
        {
            //This function breaks a 1D array of bytes into 
        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter message: ");
                string message = Console.ReadLine();
                Console.Write("Enter key: ");
                string key = Console.ReadLine();


                byte[] array = Encoding.ASCII.GetBytes(message);

                // Loop through contents of the array.
                foreach (byte element in array)
                {
                    Console.WriteLine(element);
                }

                Console.WriteLine(Convert.ToString(155, 2));

            }
        }
    }
}