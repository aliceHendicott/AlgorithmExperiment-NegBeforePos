using System;

namespace CounterExperiment {
    class Program {
        /// <summary>
        /// Sorts the an array to have all negative numbers preceeding the positive numbers
        /// </summary>
        /// <returns>An integer value representing number of times the basic operation 
        /// has been carried out</returns>
        /// <param name="Array">The inputted array to be sorted</param>
        static int NegBeforePos(int[] Array) {

            //Set both counters - i to the first value of the array and j to
            //the final value
            int i = 0;
            int j = Array.Length - 1;
            int count = 0;

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

                    //increase basic operation counter by 1
                    count++;

                    //decrease the value of j as the value at this index is 
                    //now in the correct position
                    j--;
                }
            }
            //return the sorted array
            return count;
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

            //create an array to store the average values
            double[] average = new double[20];

            //go through each test
            for (int tests = 1; tests <= 20; tests++) {
                //generate size depending on which test is occuring
                int n = tests * 100;

                //set up an array to store the counter values for each test
                int[] counter = new int[numTestsPerSize];

                //for each test
                for (int i = 0; i < numTestsPerSize; i++) {

                    //generate a random array of size n 
                    int[] A = GenerateArray(n);

                    //sort the array according to the NegBeforePos algorithm
                    counter[i] = NegBeforePos(A);
                }

                //find the sum of all counter values
                int sum = 0;
                for (int i = 0; i < counter.Length; i++) {
                    sum += counter[i];
                }

                //average the counter values and output the results
                average[tests - 1] = sum / numTestsPerSize;
                Console.WriteLine("The average running time for arrays of size " + n + " is: " + average[tests - 1]);
            }
        }

    }
}
