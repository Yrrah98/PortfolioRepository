using System;
using System.Diagnostics;

namespace FirstBinarySearchImplementation
{
    class Program
    {

        private static int[] sortedData;

        /// <summary>
        /// Main args will be the value being searched for in the array of sorted data
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Greetings
            Console.WriteLine("Hello, this is my first implementation of a binary search.");
            // INITIALISE the array 
            Initialise();
            // DECLARE and make a variable called watch, which will be a stop watch
            var watch = new System.Diagnostics.Stopwatch();
            // START the stopwatch
            watch.Start();
            // SET the value of a locally declared int, called int
            // to the return value of the FindData method
            int val = FindData(999, 0, sortedData.Length - 1);

            
            // IF the variable "val"'s value is -1, then the value was not found
            if (val == -1)
            {
                // TELL the user as such
                Console.WriteLine("Value not found");
            }
            else 
            {
                // ELSE Stop the stopwatch 
                watch.Stop();
                // TELL the user what value was found and how long it took, using the total milliseconds elapsed
                // from the stop watch
                Console.WriteLine($"Value: 999 found in {watch.Elapsed.TotalMilliseconds} ms");
            }
        }

        public static void Initialise() 
        {
            sortedData = new int[1000000];

            for (int i = 0; i < 1000000; i++)
            {
                sortedData[i] = i;
            }
        }

        /// <summary>
        /// Recursive binary search
        /// </summary>
        /// <param name="value"> value to find </param>
        /// <param name="min"> starting point of the range to search </param>
        /// <param name="max"> end point of the range to search </param>
        /// <returns></returns>
        public static int FindData(int value, int min, int max) 
        {
            // IF the maximum value is greater than or equal to the minimum
            if (max >= min)
            {
                // DECLARE an int called middle
                // set its value to the half the value of the range of values
                // e.g. min = 0, max = 100000 then middle = 0 + (100000 - 0) / 2 = 50000
                int middle = min + (max - min) / 2;

                // IF the value at the middle of the range 
                if (sortedData[middle] == value)
                {
                    // THEN return the value 
                    return sortedData[middle];
                }

                // IF the value at the middle of the range is greater than the value 
                // being searched for
                if (sortedData[middle] > value)
                {
                    // THEN the value lays somewhere to the left of the middle
                    // RETURN CALL to this method, passing in the value, the minimum value of the range 
                    // and the new maximum which is equal to the middle - 1
                    return FindData(value, min, middle - 1);
                }
                // IF we've reached this point, the value lays to the right 
                // of the middle 
                // RETURN CALL to this method, passing in the value to find, the (middle + 1) as 
                // the new minimum value and the maximum value of the range
                return FindData(value, middle + 1, max);
            }

            // IF we've reached this point, the value is not contained in the array of data
            return -1;
        }
    }
}
