using System;

namespace ImplementationAndTesting {
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
        /// Prints an array on the console
        /// </summary>
        /// <param name="A">The array to be printed</param>
        static void printArray(int[] A) {
            Console.Write("[");
            for (int i = 0; i < A.Length; i++) {
                if (i == 0) {
                    Console.Write(A[i]);
                } else {
                    Console.Write(", " + A[i]);
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }
        static void Main(string[] args) {
            //CASE 1: sort array[-5, -10, -12, -3, 7, 4, 8, 2, 15]
            int[] A = { -5, -10, -12, -3, 7, 4, 8, 2, 15 };

            //Output this array to the console.
            Console.Write("The original array: ");
            printArray(A);

            //sort the array according to the NegBeforePos algorithm
            NegBeforePos(A);

            //Output the array to the screen
            Console.Write("The sorted array: ");
            printArray(A);
            Console.WriteLine();
        }
    }
}
