using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerScience_Sorting_Lib
{
    class SortingByInsertionSort : ParentAbstractClass
    {
        //
        //   This is a Decrease-and-Conquer algorithm, so it is 
        //   considered better than the Brute-Force algorithms 
        //   of Selection Sort and Bubble Sort.
        //
        //   The Big-O Notation Time Complexity is more complicated
        //   than the Complexity of the Selection & Bubble Sorts, 
        //   because it takes advantage of good-case situations
        //   (i.e. when the array of numbers is nearly sorted, or 
        //   simply not reverse-sorted or nearly reverse-sorted 
        //   (worst-case scenarios).
        //
        //   The Big-O Complexity is O(n^2) in the worst-case 
        //   scenarios, and O(n) in the preferable (average) case.  
        //
        //
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

            //
            //Recursive call. 
            //
            Sort_InsertionSort(array_working, -1 + array_working.Length);

            timeFinish = DateTime.Now;
            double millisecondsTime = (timeFinish - timeStart).TotalMilliseconds;
            return millisecondsTime;

        }

        private void Sort_InsertionSort(int[] param_array, int par_IndexToShiftToTheLeft)
        {
            //
            // Added 3/7/2020 thomas downes
            //

            if (par_IndexToShiftToTheLeft == 0) return; 

            //
            //Recursive call. 
            //
            Sort_InsertionSort(param_array, -1 + par_IndexToShiftToTheLeft);

            //
            // To do.......
            //
            //Shift the array item of index par_IndexToShiftToTheLeft
            //    as far left as necessary to place it in the right 
            //    position within the sorted array.  
            //




        }




    }
}
