using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewKickstart_Sorting
{
    class EvenAndOddNums
    {

        /*
         * Complete the function below.
         * 
         * Group the numbers



Problem Statement:



You are given an integer array arr, of size n. Group and rearrange them (in-place) into evens and odds in such a way that group of all even integers appears on the left side and group of all odd integers appears on the right side.



Input/Output Format For The Function:



Input Format:



There is only one argument: Integer array arr.



Output Format:



Return the same integer array, with evens on left side and odds on the right side.

There is no need to preserve order within odds or within evens.



Input/Output Format For The Custom Input:



Input Format:



The first line of input should contain an integer n, denoting size of input array arr. In next n lines, ith line should contain an integer arr[i], denoting a value at index i of arr.



If n = 4 and arr = [1, 2, 3, 4], then input should be:



4

1

2

3

4



Output Format:



There will be n lines of output, where ith line contains an integer res[i], denoting value at index i of res.

Here, res is the result array returned by solution function.



For input n = 4 and arr = [1, 2, 3, 4], output will be:



4

2

1

3



Constraints:

1 <= n <= 10^5
arr contains only positive integers.
arr may contains duplicate numbers.
Solution with linear time complexity and constant auxiliary space is expected.


Sample Test Case:



Sample Input:



[1, 2, 3, 4]



Sample Output:



[4, 2, 1, 3]



Explanation:



Order does not matter. Other valid solution are

[2, 4, 1, 3]

[2, 4, 3, 1]

[4, 2, 3, 1]
         * 
         * 
         */


        /*
         * Complete the function below.
         */
        public static int[] solve(int[] arr)
        {

            int intArrayLength = arr.Length;
            int intPointerLeft = -1; // 0;
            int intPointerRight = arr.Length; //  -1 + arr.Length; 
            bool bKeepLooping = true;
            bool boolIsEvenSoOkay = false;
            bool boolIsEvenSoMoveLeft = false;
            bool boolIsOddSoMoveRight = false;
            bool boolIsOddSoOkay = false;
            int intTempForSwap_Even = 0;
            int intTempForSwap_Odd = 0;

            do
            {
                //
                // Process left-hand side. 
                //
                do
                {
                    intPointerLeft++;
                    // We might exhaust the array (if all items are odd (none are even)). 
                    if (intPointerLeft > -1 + arr.Length) return arr;
                    if (intPointerLeft >= intPointerRight) return arr;
                    boolIsEvenSoOkay = (0 == arr[intPointerLeft] % 2);
                    boolIsOddSoMoveRight = (false == boolIsEvenSoOkay);
                } while (false == boolIsOddSoMoveRight);

                //
                // We have found an odd number on the left-hand side!!
                //
                intTempForSwap_Odd = arr[intPointerLeft];

                //
                // Process right-hand side.
                //
                //boolIsEvenSoMoveLeft = (0 == arr[intPointerLeft] / 2);

                do
                {
                    intPointerRight--;
                    // We might exhaust the array (if all items are odd (none are even)). 
                    if (intPointerRight < 0) return arr;
                    if (intPointerRight <= intPointerLeft) return arr;
                    boolIsOddSoOkay = (0 != arr[intPointerRight] % 2);
                    boolIsEvenSoMoveLeft = (false == boolIsOddSoOkay);
                } while (boolIsOddSoOkay);

                //
                // We have found an even number on the right-hand side!!
                //
                intTempForSwap_Even = arr[intPointerRight];

                //
                // Perform a swap !!
                //
                arr[intPointerLeft] = intTempForSwap_Even;
                arr[intPointerRight] = intTempForSwap_Odd;

                //
                // Prepare for next iteration. 
                //
                bKeepLooping = (intPointerLeft < intPointerRight);

            } while (bKeepLooping);

            return arr;

        }




    }
}
