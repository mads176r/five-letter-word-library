using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace five_letter_word_library
{
    public class GetProduct
    {
        public (List<int>, int) GetString(string fileLocatione)
        {
            var file = fileLocatione;
            List<string> validLines = new List<string>();
            List<int> bitArrays = new List<int>();
            Dictionary<char, int> charFrequency = new Dictionary<char, int>();

            var logFile = File.ReadAllLines(fileLocatione);
            List<string> validWords = new List<string>();
            List<int> validBits = new List<int>();



            foreach (var word in logFile)
            {
                if (word.Length != 5) continue;
                if (word.Distinct().Count() != 5) continue;
                foreach (var c in word)
                {
                    if (!validBits.Contains(BitTranlation.StringToBitArray(word)))
                    {
                        validBits.Add(BitTranlation.StringToBitArray(word));
                        validWords.Add(word);
                    }

                    if (charFrequency.ContainsKey(c))
                    {
                        charFrequency[c]++;
                    }
                    else
                    {
                        charFrequency[c] = 1;
                    }
                }
            }

            validLines = validWords.OrderBy(word => word.Sum(c => charFrequency[c])).ToList();

            int indexNoLongerInUse = LeastUsedLetter(charFrequency);

            foreach (var word in validLines)
            {
                bitArrays.Add(BitTranlation.StringToBitArray(word));
            }


            //Console.WriteLine("Amount of valid words: " + bitArrays.Count());

            return (bitArrays, indexNoLongerInUse);

        }

        private int LeastUsedLetter(Dictionary<char, int> charFrequency)
        {
            var sortedCharFrequency = charFrequency.OrderBy(kv => kv.Value);

            // Step 3: Get the two least used letters and their counts
            var leastUsedLetters = sortedCharFrequency.Take(2).ToArray();
            var firstLeastUsedLetter = leastUsedLetters[0];
            var secondLeastUsedLetter = leastUsedLetters[1];

            // Step 4: Calculate the index at which the two least used letters are no longer used
            int indexNoLongerInUse = firstLeastUsedLetter.Value + secondLeastUsedLetter.Value + 1;


            return indexNoLongerInUse;
        }
    }
}
