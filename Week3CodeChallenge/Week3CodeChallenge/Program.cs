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
            Console.WriteLine(FindNPrimes(6));
            EvenFibonacciSequencer(50);
            // Keep the console open
            Console.ReadKey();
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
