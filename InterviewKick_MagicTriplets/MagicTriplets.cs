﻿using System;
using System.Collections.Generic; 

namespace InterviewKick_MagicTriplets
{
    /****
     * 
     *
     *3 Sum

        Problem Statement:

        Given an integer array arr of size n, find all magic triplets in it.

        Magic triplet is a group of three numbers whose sum is zero.

        Note that magic triplets may or may not be made of consecutive numbers in arr.

        Input Format:

        Function has one argument: array of integers arr.

        Output Format:

        Function must return an array of strings. Each string (if any) in the array must represent a unique magic triplet and strictly follow this format: “1,2,-3” (no whitespace, one comma between numbers).

        Order of the strings in the array as well as order of the integers in any string is insignificant. For example, if [“1,2,-3”, “1,-1,0”] is a correct answer, then [“0,1,-1”, “1,-3,2”] is also a correct answer.

        However any two triplets that only differ by order of the numbers are considered duplicates, and duplicates must not be returned. In other words, if triplet “1,2,-3” is a part of an answer, then none of “1,-3,2”, “-3,2,1”, etc may appear in the same answer (though any one of them may appear instead of “1,2,-3”). 

        Constraints:

        1 <= n <= 2000
        -1000 <= any element of arr <= 1000
        arr may contain duplicate numbers.
        arr is not necessarily sorted.

        Sample Input 1:
        arr = [10, 3, -4, 1, -6, 9]
 
        Sample Output 1:
        [“10,-4,-6”, “3,-4,1”]

        Sample Input 2:
        arr = [12, 34, -46]

        Sample Output 2:
        [“12,-46,34”]

        Sample Input 3:
        arr = [0, 0, 0];

        Sample Output 3:
        [“0,0,0”]

        Sample Input 4:
        arr = [-2, 2, 0 -2, 2];

        Sample Output 4:
        [“2,-2,0”]

     * ****/

    public class MagicTriplets
    {

        public static FindMagicTriplets(int[] par_arrayOfNums)
        {
            //
            //   Find all of the triplets (sets of 3) of numbers (from the input array) that sum to 0.   
            //  ----Thomas Downes, 3/11/2020 
            //
            //   Return the unique sets (as sets, not as arrays; order of numbers is irrelevant). 
            //  ----Thomas Downes, 3/11/2020 
            //

            //
            //  What would be a brute-force algorithm?
            //     ---List all 3-item subsets of the input array.
            //           If the array contained only unique numbers, then here following would be the count.  
            //           Count: N x (N - 1) x (N - 2) / (3 x 2)   (Divide to eliminate order-of-element considerations.)
            //     ---Associate each triple with the sum of the three numbers.
            //     ---Pick out the triples associated with the number ---0---. 
            //  ----Thomas Downes, 3/11/2020 
            //
            //   How can we create an elegant solution which utilizes a combination of pointers
            //     which converge on qualifying triplets?
            //  ----Thomas Downes, 3/11/2020 
            //
            //   How can we create an elegant solution which takes advantage of the CountSort algorithm?  
            //
            //   Let's decrease and conquer!!   Solve the problem as follows: 
            //      ---Sort the sequence  (??? using distinct numbers?? no, { 0, 0, 0} is a valid triplet.
            //      ---Catalogue all of the subsets { , } containing two(2) numbers,
            //           and tracking the subsets by their sum.
            //      ---Iterate through the array, finding all pairs which sum to the negative of the 
            //          current value.  
            //      ---Create a subfunction which looks for all pairs which sum to the (negative of) any
            //           requested number.  Call that function for each & every unique 
            //           value in the array.  
            //  ----Thomas Downes, 3/11/2020 
            //
            //

            //
            //Sort the array!!
            //
            const bool c_bSortInputArray = true;
            int intLargestNumber = 0;
            int intGreatestNegative = -1;

            if (c_bSortInputArray)
            {
                //
                //Sort the array in place.
                //
                System.Array.Sort(par_arrayOfNums);
                int intArrayItem_First = par_arrayOfNums[0];
                int intArrayItem_Last = par_arrayOfNums[-1 + par_arrayOfNums.Length];
                intGreatestNegative = intArrayItem_First;
                intLargestNumber = intArrayItem_Last;
            }
            else
            {
                //
                //We are leaving the array alone.  Do a O(n) search for the largest 
                //     & left-most negative numbers.
                //
                intLargestNumber = LargestNum(par_arrayOfNums);
                intGreatestNegative = MostNegativeNumber(par_arrayOfNums);   //This is the 
                //     number which is furthest to the left on the negative-postive real-number line.
            }

            //
            // The tuple-sums must counter-balance the values of the 
            //    individual numbers (which are candidates to complete
            //    the Magic Triplets).  
            //
            int intTupleSum_BoundLower = (0 - intGreatestNegative);
            int intTupleSum_BoundUpper = (0 - intLargestNumber);



            //System.Collections.Generic.Dictionary<int, List<Tuple<int, int>>>

            //
            // Build a helpful dictionary of paired integer values.  
            //
            var dictionaryOfTuples = GetSummedDictionaryOfPairs(par_arrayOfNums, 
                   intTupleSum_BoundLower, 
                   intTupleSum_BoundUpper);






        }

        private static System.Collections.Generic.Dictionary<int, List<Tuple<int, int>>> 
            GetSummedDictionaryOfPairs(int[] par_array, int par_boundOfSumLower, int par_boundOfSumUpper)
        {
            //
            // Added 3/11/2020 thomas downes
            //
            var output_dictionary = new System.Collections.Generic.Dictionary<int, List<Tuple<int, int>>>();

            for (int intEachSum = par_boundOfSumLower; intEachSum <= par_boundOfSumUpper; intEachSum++)
            {
                //
                // Create a list of paired numbers, which sum to a specific value.
                //
                var each_listOfPairs = GetListOfPairsBySum(par_array, intEachSum);

                output_dictionary.Add(intEachSum, each_listOfPairs);

            }
            return output_dictionary;

        }

        private static List<Tuple<int, int>> 
            GetListOfPairsBySum(int[] par_array, int par_sumOfPair)
        {
            //
            // Added 3/11/2020 thomas downes  
            //
            //  Would the Two-Pointer Approach help? 
            //
            var output_list = new List<Tuple<int, int>>();
            int intPointerForLoopOuter = -1;
            //int intPointerForLoopInner = -1;
            bool boolKeepLooping = true;
            int intBalanceOfSum;
            int intIndexOfFound = 0;
            int intPairItemFirst = 0; ;
            int intPairItemSecond = 0;

            do
            {
                intPointerForLoopOuter++;
                intPairItemFirst = par_array[intPointerForLoopOuter];
                intBalanceOfSum = (par_sumOfPair - intPairItemFirst);
                intIndexOfFound = Array.BinarySearch(par_array, intBalanceOfSum);
                intPairItemSecond = par_array[intIndexOfFound];

                if (0 <= intIndexOfFound) 
                { 
                    output_list.Add(Tuple.Create<int, int>(intPairItemFirst, intPairItemSecond));
                } 

            } while (boolKeepLooping);





        }


        private static int LargestNum(int[] par_arrayOfNums)
        {
            //
            //Added 3/11/20020 thomas downes 
            //
            int intProvisionalMax = 0;   // Literally, the initialization value is only to 
            // satisfy the compiler &/or Visual Studio.  It won't be utilized below. 
            bool bInitialized = false;

            foreach (int intEach in par_arrayOfNums)
            {
                if (bInitialized)
                {
                    if (intEach > intProvisionalMax) intProvisionalMax = intEach;
                }
                else
                {
                    intProvisionalMax = intEach;
                    bInitialized = true;
                }
            }
            return intProvisionalMax;
        }

        private static int MostNegativeNumber(int[] par_arrayOfNums)
        {
            //
            // We will use the comparison operater < to determine the smallest number,
            //    which is probably a multi-digit negative number, 
            //    but not necessarily.  
            //
            // Added 3/11/20020 thomas downes 
            //
            int intProvisionalMin = 0;   // Literally, the initialization value is only to 
            // satisfy the compiler &/or Visual Studio.  It won't be utilized below. 
            bool bInitialized = false;

            foreach (int intEach in par_arrayOfNums)
            {
                if (bInitialized)
                {
                    //----if (intEach > intProvisionalMax) intProvisionalMax = intEach;
                    if (intEach < intProvisionalMin) intProvisionalMin = intEach;
                }
                else
                {
                    intProvisionalMin = intEach;
                    bInitialized = true;
                }
            }
            return intProvisionalMin;
        }



    }
}
