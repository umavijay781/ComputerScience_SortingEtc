using System;

namespace InterviewKickstart_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

        /*
         * 
         * Merge_K_sorted_arrays

        Problem Statement:

        This is a popular facebook problem.

        Given K sorted arrays arr, of size N each, merge them into a new array res, such that res is a sorted array.


        Assume N is very large compared to K. N may not even be known. The arrays could be just sorted streams, for instance, timestamp streams.



        All arrays might be sorted in increasing manner or decreasing manner. Sort all of them in the manner they appear in input.



        Note:

        Repeats are allowed.
        Negative numbers and zeros are allowed.
        Assume all arrays are sorted in the same order. Preserve that sort order in output.
        It is possible to find out the sort order from at least one of the arrays.


        Input/Output Format For The Function:



        Input Format:



        There is only one argument: 2D Integer array arr.

        Here, arr[i][j] denotes value at index j of ith input array, 0-based indexing. So, arr is K * N size array.



        Output Format:



        Return an integer array res, containing all elements from all individual input arrays combined.



        Input/Output Format For The Custom Input:



        Input Format:



        The first line of input should contain an integer K. The second line should contain an integer N, denoting size of each input array.

        In next K lines, ith line should contain N space separated integers, denoting content of ith array of K input arrays, where jth element in this ith line is nothing but arr[i][j], i.e. value at index j of ith array, 0-based indexing.  



        If K = 3, N = 4 and arr = [

        [1, 3, 5, 7],

                    [2, 4, 6, 8],

                    [0, 9, 10, 11]

        ], then input should be:



        3

        4

        1 3 5 7

        2 4 6 8

        0 9 10 11



        Output Format:



        There will be (N*K) lines of output, where ith line contains an integer res[i], denoting value at index i of res.

        Here, res is the result array returned by solution function.



        For input K = 3, N = 4 and arr = [

        [1, 3, 5, 7],

                    [2, 4, 6, 8],

                    [0, 9, 10, 11]

        ], output will be:



        0

        1

        2

        3

        4

        5

        6

        7

        8

        9

        10

        11



        Constraints:

        1 <= N <= 500
        1 <= K <= 500
        -10^6 <= arr[i][j] <= 10^6, for all valid i,j

        Sample Test Case:

        Sample Input:   K = 3, N =  4

        arr[][] = { {1, 3, 5, 7},

                   {2, 4, 6, 8},

                   {0, 9, 10, 11}} ;

        Sample Output:

        [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]

        Note:   A solution which dumps all elements from all arrays into one massive heap, and then extracts the elements one by one into a sorted output may pass, but is not acceptable. These issues should go away when we have a more nuanced backend.

         * 
         * 
         * 
        * Complete the mergeArrays function below.
        * 
         */
        static int[] mergeArrays(int[][] arr)
        {
            /*
             *   Solution by Thomas Downes. 
             */

            short shNumArraysK = (short)arr.GetLength(0);
            short shNumItemsN = (short)arr.GetLength(1);

            bool boolAscendingArrays = false; // (arr[0][0] < arr[0][shNumItemsN]);

            for (int ithArray = 0; ithArray < arr.GetLength(0); ithArray++)
            {
                //Check all of the arrays, as some arrays might have equal values 
                //  for all array items.    If one of the arrays is confirmed 
                //  to be ascending, then (by the stated problem from Interview Kickstart) 
                //  we are safe to conclude that they all are ascending.
                //   -----3/9/2020 thomas downes
                //
                boolAscendingArrays = (boolAscendingArrays ||
                    (arr[ithArray][0] < arr[ithArray][shNumItemsN]));
                if (boolAscendingArrays) break; 
            }

            short[] pointerArrayIndexes = new short[shNumArraysK];
            bool[] bArrayIsExhausted = new bool[shNumArraysK];

            //Output. 
            int[] res = new int[shNumArraysK * shNumItemsN];

            //int intLastOutputMaxOrMin = -1; //  arr[0][0];
            short shCurrentResIndex = 0;
            bool bKeepLooping = true;

            int intProvisionalOutput_value = -1; // arr[0][0];
            short shProvisionalOutput_itemIndex = -1;
            short shProvisionalOutput_arrayIndex = -1;
            short shCurrentArray_Pointer = -1;
            bool bSmallerThanProvisional = false;
            bool bAllArraysHaveBeenExhausted = false; 

            do
            {
                bAllArraysHaveBeenExhausted = true;  //Initialize to True. 
                bool bFirstUnexhaustedArrayBeingChecked = true;   

                for (short shArrayIndexI = 0; shArrayIndexI <= -1 + shNumArraysK; shArrayIndexI++)
                {
                    //
                    // Let's review what we can "pull" from Array #I.  
                    //
                    int intArrayCurrentValue;
                    
                    shCurrentArray_Pointer = pointerArrayIndexes[shArrayIndexI];
                    bArrayIsExhausted[shArrayIndexI] = (shCurrentArray_Pointer > -1 + shNumItemsN);
                    if (bArrayIsExhausted[shArrayIndexI]) continue;

                    bAllArraysHaveBeenExhausted = false;  //The default of True is ___NOT___ the valid truth.  
                    intArrayCurrentValue = arr[shArrayIndexI][shCurrentArray_Pointer];

                    if (bFirstUnexhaustedArrayBeingChecked) //(shArrayIndexI == 0)
                    {
                        //
                        // We have to initialize the "Provisional" variables. 
                        //
                        intProvisionalOutput_value = intArrayCurrentValue;
                        shProvisionalOutput_itemIndex = pointerArrayIndexes[shArrayIndexI];
                        shProvisionalOutput_arrayIndex = shArrayIndexI;
                    }
                    else
                    {
                        //
                        // We have to compare the provisional integer value (vs. short values)
                        //   to the current array value.
                        //
                        // The variable name bSmaller... is for comprehension purposes, the 
                        //    variaable is named as if we know all the arrays are in 
                        //    ascending order (1, 234, 2399, etc.).   Howver, the 
                        //    expression on the right-hand side does not make that
                        //    assumption (see use of var. boolAscendingArrays).
                        //   ----3/9/2020 thomas downes
                        //
                        bSmallerThanProvisional = (boolAscendingArrays ? (intArrayCurrentValue < intProvisionalOutput_value) :
                                                                         (intArrayCurrentValue > intProvisionalOutput_value));
                        if (bSmallerThanProvisional)
                        {
                            intProvisionalOutput_value = intArrayCurrentValue; 
                            shProvisionalOutput_itemIndex = shCurrentArray_Pointer;
                            shProvisionalOutput_arrayIndex = shArrayIndexI;
                        }

                    }

                    //
                    //Prepare for the next iteration of the For-Next loop. 
                    //
                    bFirstUnexhaustedArrayBeingChecked = false; //In the 2nd & subsequent iterations, ... 
                    //  ... this Boolean should be false.  


                }

                //
                //  We have our next output value, and we know where it came from !!
                //
                res[shCurrentResIndex] = intProvisionalOutput_value;
                
                //Indicate that we have made progress in populating the output array.  
                shCurrentResIndex++;
                
                //Indicate that we have pulled a value from one of the arrays. 
                //   (This is the first time I've used the ++ operator on an 
                //   array item.   It should work okay.)
                pointerArrayIndexes[shProvisionalOutput_arrayIndex]++;

                //for (int intArrayIndexKL = 0; intArrayIndexKL < )
                //bKeepLooping = 
                bKeepLooping = (false == bAllArraysHaveBeenExhausted);

            } while (bKeepLooping);

            return res;  

    }



    }
}
