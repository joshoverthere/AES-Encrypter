using System;
using System.Threading;
using System.Text;

namespace AES
{
    class Program
    {
        //Map 4x4 byte array to 4x4 byte output array with Rijndael substitution box
        static string[,] sBox(string[,] state)
        {
            //set up 4x4 output array of bytes
            string[,] outputState = new string[4, 4];

            //set up array for Rijndael s-box
            List<List<string>> sBox = new List<List<string>>();
            sBox.Add(new List<string> { "63","7c","77","7b","f2","6b","6f","c5","30","01","67","2b","fe","d7","ab","76"});
            sBox.Add(new List<string> { "ca","82","c9","7d","fa","59","47","f0","ad","d4","a2","af","9c","a4","72","c0"});
            sBox.Add(new List<string> { "b7","fd","93","26","36","3f","f7","cc","34","a5","e5","f1","71","d8","31","15"});
            sBox.Add(new List<string> { "04", "c7","23","c3","18","96","05","9a","07","12","80","e2","eb","27","b2","75" });

            //perform substitution on each byte in the state array
            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 4; a++)
                {

                }
            }

            return outputState;
        }
        
        //takes a list of 16 bytes (a block) and converts it into a 4x4 column-major-order array of bytes
        static string[,] generateState(List<string> block)
        {
            string[,] state = new string[4, 4];
            int count = 0;


            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 4; a++)
                {
                    state[a,i] = block[count];
                    count += 1;
                }
            }
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

        static string toHex(string byteStr)
        {
            return Convert.ToInt32(byteStr, 2).ToString("X");
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

                //break the list of bytes into 16-byte blocks
                List<List<string>> blocks = breakBlocks(bytes);

                //generate "states" from the 16-byte blocks and store the states in a list
                List<string[,]> states = new List<string[,]>();
                foreach (List<string> block in blocks)
                {
                    states.Add(generateState(block));
                }

                foreach (string[,] state in states)
                {
                    foreach (string charbyte in state){
                        Console.WriteLine(charbyte);
                    }
                }

            }
        }
    }
}