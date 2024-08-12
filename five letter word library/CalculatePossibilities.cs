using System.Collections.Concurrent;
using System.Diagnostics;

namespace five_letter_word_library
{
    public class CalculatePossibilities
    {
        public static int CalculateTotalPossibilities(List<int> bitArraysToRead, int endIndex/*, int numberOfWordsToCombine, int amountOfLettersToUse*/)
        {
            var results = new ConcurrentBag<int>();

            Parallel.For(0, endIndex, startWord =>
            {
                int possibilities = GetNumberOfPossibilities(bitArraysToRead, startWord);
                if (possibilities > 0)
                {
                    results.Add(possibilities);
                }
            });

            return results.Sum();
        }

        private static int GetNumberOfPossibilities(List<int> bitArraysToRead, int startWord)
        {
            int wordAmount = bitArraysToRead.Count;
            int result = 0;

            //Console.WriteLine("start index:" + startWord);

            for (int second = startWord + 1; second < wordAmount; second++)
            {
                if ((bitArraysToRead[startWord] & bitArraysToRead[second]) != 0) continue;

                for (int third = second + 1; third < wordAmount; third++)
                {
                    if (((bitArraysToRead[startWord] | bitArraysToRead[second]) & bitArraysToRead[third]) != 0) continue;

                    for (int fourth = third + 1; fourth < wordAmount; fourth++)
                    {
                        if (((bitArraysToRead[startWord] | bitArraysToRead[second] | bitArraysToRead[third]) & bitArraysToRead[fourth]) != 0) continue;

                        for (int fifth = fourth + 1; fifth < wordAmount; fifth++)
                        {
                            if (((bitArraysToRead[startWord] | bitArraysToRead[second] | bitArraysToRead[third] | bitArraysToRead[fourth]) & bitArraysToRead[fifth]) == 0)
                            {
                                result++;
                                //Console.WriteLine(result);
                                Debug.WriteLine(result);
                            }
                        }
                    }
                }
            }

            return result;
        }

        //private static int Test(List<int> bitArraysToRead, int startWord, int numberOfWordsToCombine, int amountOfLettersToUse)
        //{
        //    int wordAmount = bitArraysToRead.Count;
        //    int result = 0;
        //    int bitResult = bitArraysToRead[0];


        //    result = Test(bitArraysToRead, startWord, numberOfWordsToCombine, amountOfLettersToUse, 1, bitResult);


        //    return result;
        //}


        //private static int Test(List<int> bitArraysToRead, int startWord, int numberOfWordsToCombine, int amountOfLettersToUse, int n, int bitResult)
        //{
        //    int wordAmount = bitArraysToRead.Count;
        //    int result = 0;

        //    for (int i = n; i < (n + 1); i++)
        //    {

        //    }



        //    return result;
        //}

    }
}
