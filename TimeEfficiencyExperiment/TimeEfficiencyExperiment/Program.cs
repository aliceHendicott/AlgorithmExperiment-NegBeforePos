using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TimeEfficiencyExperiment {
    class Program {
        /// <summary>
        /// Sorts the an array to have all negative numbers preceeding the positive numbers
        /// </summary>
        /// <param name="Array">The inputted array to be sorted</param>
        static void NegBeforePos(int[] Array) {
            //Set both counters - i to the first value of the array and j to
            //the final value
            int i = 0;
            int j = Array.Length - 1;

            //begin the while loop which will end once i is less than or equal to j
            while (i <= j) {
                //check if the value in the array at index of i is less than 
                //0
                if (Array[i] < 0) {
                    //increment i because the value at i is in the correct
                    //position
                    i++;
                } else {
                    //otherwise, swap the values at index of i and j
                    int firstValue = Array[i];
                    Array[i] = Array[j];
                    Array[j] = firstValue;

                    //decrease the value of j as the value at this index is 
                    //now in the correct position
                    j--;
                }
            }
        }
        /// <summary>
        /// Generate a random array of length n
        /// </summary>
        /// <returns>The array</returns>
        /// <param name="n">Integer which represents the length of the array to be generated</param>
        static int[] GenerateArray(int n) {
            Random rnd = new Random();
            int[] A = new int[n];
            for (int i = 0; i < n; i++) {
                A[i] = rnd.Next(100) - 50;
            }
            return A;
        }
        static void Main(string[] args) {
            //create a variable to represent the number of tests to average for each size n
            int numTestsPerSize = 20;

            //set up a Stopwatch variable
            Stopwatch sw = new Stopwatch();

            //Step through each size n
            for (int n = 1000; n <= 20000; n = n + 1000) {
                double averageMilliSecs = 0;
                long totalMilliSecs = 0;

                //Step through each test for the current size n
                for (int i = 0; i < numTestsPerSize; i++) {
                    long milliSecs = 0;

                    //Generate a random array of size n
                    int[] A = GenerateArray(n);

                    //Start the stopwatch
                    sw.Start();

                    //sort the array using the NegBeforePos algorithm
                    NegBeforePos(A);

                    //Stop the stopwatch
                    sw.Stop();

                    milliSecs = sw.ElapsedMilliseconds;
                    totalMilliSecs = totalMilliSecs + milliSecs;
                }

                //find the average time in milliseconds and output the results
                averageMilliSecs = totalMilliSecs * 1.0 / numTestsPerSize;
                Console.WriteLine("The average running time for arrays of size " + n + " is: " + averageMilliSecs);
            }
        }

    }
}
