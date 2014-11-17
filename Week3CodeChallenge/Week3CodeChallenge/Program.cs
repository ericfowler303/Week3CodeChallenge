using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindNPrimes(10001));
            EvenFibonacciSequencer(50);
            LongestCollatzSequence();
            // Keep the console open
            Console.ReadKey();
        }
        public static void LongestCollatzSequence()
        {
            Dictionary<long,long> seqStorage = new Dictionary<long, long>();
            long longestValue=0;
            long longestSeqCount=0;
            // Check all numbers under one million
            for (long i = 1; i < 1000000; i++)
            {
                // Keep track of stats for the current number
                long currentCount = 0;
                long n = i;
                // Loop until the chain has finished
                while (n != 1)
                {
                    long cachedCount = 0;
                    // Check to see if the sequence from this point is already stored
                    // Doing this will save steps instead off trying to find a sequence that has already been computed
                    if (seqStorage.TryGetValue(i, out cachedCount)) 
                    {
                        // If a sequence was found in storage, get it's count and just added it to the current count
                        // instead of recomputing the entire sequence
                        currentCount += cachedCount;
                        break;
                    }
                    // Since the current value isn't stored we need to compute the next number in the sequence
                    if ((n & 1) == 0)
                    {
                        n = n / 2;
                    }
                    else
                    {
                        n = (3 * n) + 1;
                    }
                    currentCount++;
                }
                // Now that the sequence was solved for this number, store it in case it can be used again
                seqStorage.Add(i, currentCount);

                // Check to see if this sequence is the highest so far
                if (currentCount > longestSeqCount)
                {
                    // Since this count was the longest, update the values to reflect that
                    longestValue = i;
                    longestSeqCount = currentCount;
                }
            }

            // Print out the number that produces the longest chain
            Console.WriteLine(longestValue);
        }

        /// <summary>
        /// A Function that adds up each even number in a Fibonacci Sequence until the maxValue
        /// then prints the sum of those numbers to the console
        /// </summary>
        /// <param name="maxValue"></param>
        public static void EvenFibonacciSequencer(long maxValue)
        {
            List<long> fibNums = new List<long>();
            // first two numbers in the sequence
            long a = 1;
            long b = 1;
            // Loop while the next value is less than the maxValue
            while (b < maxValue)
            {
                long tempVal = a;
                a = b;
                b += tempVal;
                // Bitwise AND to check for even
                if ((b & 1) == 0) { fibNums.Add(b); } // Add the even numbers to the list
            }
            // Now that the maxValue has been reached, print out the sum of the even values found
            Console.WriteLine(fibNums.Sum());
        }

        /// <summary>
        /// Function that finds the n'th prime indicated by the parameter
        /// </summary>
        /// <param name="maxPrime"></param>
        public static int FindNPrimes(int maxPrime)
        {
            List<int> primeHolder = new List<int>();
            int primeCounter = 2; // Start with the first prime number
            while(primeHolder.Count() <= maxPrime)
            {
                // If the number is prime add it to the list
                if (IsPrime(primeCounter)) { primeHolder.Add(primeCounter); }
                primeCounter++;
            }
            // Get the last element in the list as it's the highest prime that was found
            return primeHolder.Last();
        }
        /// <summary>
        /// A method to quickly find if a number is prime or not
        /// </summary>
        /// <param name="numberToTest">the number to test</param>
        /// <returns>returns true if the number is prime</returns>
        private static bool IsPrime(int numberToTest)
        {
            // Get a few simple tests out of the way
            if (numberToTest < 2) { return false; }

            // Use a bitwise AND statement to evaulate the first bit of the integer
            // This statement will filter out any even number very quickly, except for 2 which is prime
            if((numberToTest & 1) == 0 ){
                if(numberToTest == 2){
                    return true;
                } else {
                    return false;
                }
            }
            // Now everything that is tested will be an odd number because all even's won't be prime at this point
            // Also skip the squares of the number
            for (int i = 3; (i*i) < numberToTest; i+=2)
            {
                if((numberToTest % i) == 0) { return false;}
            }

            // Must be true if it hasn't been divisable yet
            return true;
        }
    }
}
