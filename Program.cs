using System;
using System.Threading;
using System.Text;

namespace AES
{

    public class state
    {
        public static byte[,] contents = new byte[4, 4];
        public static string name = "";

        //call this function and pass a list of 16 bytes to set the initial contents of the state
        static void init(List<string> block)
        {

        }
        
        //visualises the state's contents in console
        static void visualize()
        {
            Console.WriteLine("Visualizing state " + name + ":");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
                for (int a = 0; a<4; a++)
                {
                    Console.Write(contents[i,a]);
                }
            }
        }
    }


    class Program
    {

        //takes a list of 16 bytes (a block) and converts it into a 4x4 column-major-order array of bytes
        static string[,] generateState(List<string> block)
        {
            string[,] state = new string[4, 4];
            int count = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 4; a++)
                {
                    state[a, i] = block[count];
                    count += 1;
                }
            }
            return state;
        }

        //Takes a state's 4x4 array of strings and visualises it in the console (for debugging)
        static void displayArray(string[,] array1)
        {
            Console.WriteLine("State Visualisation:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
                for (int a = 0; a < 4; a++)
                {
                    //int intOut = Convert.ToInt32(array1[i,a], 2);
                    Console.Write(array1[i,a].ToString() + "  ");
                    //string hexOut = Convert.ToInt32(array1[i,a], 2).ToString("X");
                    //Console.Write(hexOut + "  ");

                    //Console.Write((intOut/16).ToString() + (intOut%16).ToString() + "  ");
                }
            }
            Console.WriteLine();
        }


        //Map 4x4 byte array to 4x4 byte output array with Rijndael substitution box
        static string[,] sBox(string[,] state)
        {
            byte[] sBoxForward = new byte[256] {
            0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
            0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
            0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
            0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
            0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
            0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
            0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
            0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
            0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
            0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
            0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
            0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
            0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
            0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
            0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
            0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16 };

            Console.WriteLine("Applying S-box to state.");
            //set up 4x4 output array of bytes
            string[,] outputState = new string[4, 4];

            //visualise state
            displayArray(state);

            Console.WriteLine("\n The following substitutions were performed: \n");

            //perform substitution on each byte in the state array
            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 4; a++)
                {
                    //get value of byte as an integer so it can be used in formula to find index of substition in S-box
                    int intOut = Convert.ToInt32(state[a,i], 2);
                    //Console.WriteLine("Int out: " + intOut);

                    int myInt = sBoxForward[intOut];



                    string myHex = myInt.ToString("X");

                    Console.WriteLine("Binary: " + Convert.ToString(Convert.ToInt64(myHex, 16), 2));

                    //Console.WriteLine("Int: " + myInt);
                    Console.WriteLine("Hex: " + myHex);

                    outputState[a, i] = Convert.ToString(Convert.ToInt64(myHex, 16), 2);

                }
            }

            Console.WriteLine("Substituted state.");
            return outputState;
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


                List<string[,]> updatedStates = new List<string[,]>();
                foreach (string[,] state in states)
                {
                    string[,] updatedState = new string[4, 4];
                    updatedState = sBox(state);
                    updatedStates.Add(updatedState);
                    Console.WriteLine(updatedState.Length.ToString());
                    displayArray(updatedState);
                }
                states = updatedStates;

            }
        }
    }
}