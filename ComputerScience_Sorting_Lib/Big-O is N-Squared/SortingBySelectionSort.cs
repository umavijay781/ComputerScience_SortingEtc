using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerScience_Sorting_Lib
{
    public class SortingBySelectionSort : ParentAbstractClass // : ISortingByTypeOfSort
    {
        //
        //    https://sorting.at   
        //

        /*  In computer science, selection sort is an in-place comparison sorting algorithm. It has an O(n2) 
         *  time complexity, which makes it inefficient on large lists, and generally performs worse than the 
         *  similar insertion sort. Selection sort is noted for its simplicity and has performance advantages 
         *  over more complicated algorithms in certain situations, particularly where auxiliary memory is limited. 
         *  The algorithm divides the input list into two parts: a sorted sublist of items which is built up from 
         *  left to right at the front (left) of the list and a sublist of the remaining unsorted items that occupy 
         *  the rest of the list. Initially, the sorted sublist is empty and the unsorted sublist is the entire 
         *  input list. The algorithm proceeds by finding the smallest (or largest, depending on sorting order) 
         *  element in the unsorted sublist, exchanging (swapping) it with the leftmost unsorted element (putting 
         *  it in sorted order), and moving the sublist boundaries one element to the right. 
         *  https://en.wikipedia.org/wiki/Selection_sort
         */

        public override double Sort_ReturnMilliseconds(int[] param_array)
        {
            //
            // Added 3/4/2020 thomas downes
            //
            const bool c_boolSortInput = True;
            return Sort_ReturnMilliseconds(param_array, c_boolSortInput, False);
        }

        public override double Sort_ReturnMilliseconds(int[] param_array, bool pbPleaseSortInputArray, bool pbPleaseDontModifyInput)
        {
            //
            // Added 3/1/2020 thomas downes 
            //
            //    https://sorting.at   
            //
            //throw new NotImplementedException();

            DateTime timeStart = DateTime.Now;
            DateTime timeFinish = DateTime.MaxValue;
            int intCountInversions = -1;

            //bool bOutOfOrder = False;
            //int intTemp = 0;

            intCountInversions = 0; //Reinitialize. 

            //
            // Will we work with a copy, or the original input array?  
            //
            int[] array_working;
            if (pbPleaseSortInputArray || (False == pbPleaseDontModifyInput))
            { 
                array_working = param_array; 
            }
            else //----if (True || pbPleaseDontModifyInput)
            {
                array_working = new int[param_array.Length];
                param_array.CopyTo(array_working, 0);
            }

            for (int indexItem1 = 0; indexItem1 < -1 + array_working.Length; indexItem1++)
            {
                //for (int indexItem2 = 0; indexItem2 < -1 + param_array.Length; indexItem2++)

                intCountInversions +=
                    SortSmallestItem_SkipIndicesLT(indexItem1, array_working);  // param_array);
            }

            //} while (intCountInversions != 0);
            //return param_array;

            timeFinish = DateTime.Now;
            double millisecondsTime = (timeFinish - timeStart).TotalMilliseconds;
            return millisecondsTime;

        }

        private int SortSmallestItem_SkipIndicesLT(int param_startIndex, int[] param_array)
        {
            //
            // Added 3/1/2020 thomas downes 
            //
            //    https://sorting.at   
            //
            int intCountInversions = 0;
            //bool bOutOfOrder = False;
            int intTemp = 0;
            int intSmallestValue = int.MaxValue; ;
            int intIndexOfSmallest = -1;

            intCountInversions = 0; //Reinitialize. 

            for (int indexItem1 = param_startIndex; indexItem1 < -1 + param_array.Length; indexItem1++)
            {
                //for (int indexItem2 = 0; indexItem2 < -1 + param_array.Length; indexItem2++)
                //SortSmallestItem_SkipIndicesLT(indexItem1, param_array);

                intSmallestValue = (param_array[indexItem1] < intSmallestValue ? param_array[indexItem1] : intSmallestValue);
                intIndexOfSmallest = (param_array[indexItem1] < intSmallestValue ? indexItem1 : intIndexOfSmallest);
            }

            if (intIndexOfSmallest > param_startIndex)
            {
                intCountInversions = 1;
                intTemp = param_array[param_startIndex];
                param_array[param_startIndex] = intSmallestValue;
                param_array[intIndexOfSmallest] = intTemp;
            }

            return intCountInversions;

        }
    }

}
