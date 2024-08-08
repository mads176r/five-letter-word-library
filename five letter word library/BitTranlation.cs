using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace five_letter_word_library
{
    public class BitTranlation
    {
        public static int StringToBitArray(string input)
        {
            int bitArray = 0;

            foreach (char c in input.ToLower())
            {
                if (c >= 'a' && c <= 'z')
                {
                    int position = c - 'a';
                    bitArray |= (1 << position);
                }
            }

            //Console.WriteLine("{0} - {1}", input, bitArray.ToString("B"));

            return bitArray;
        }
    }
}
