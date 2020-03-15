 using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerScience_Sorting_Lib
{
    //
    // Added 2/18/2020 Thomas Downes 
    //
    class SortingByQuickSort : ParentAbstractClass  // : ISortingByTypeOfSort
    {
        public int[] Sort_ReturnArray(List<int> param1)
        {

            return new int[] { 1, 2, 3, 4 };

        }

        public override double Sort_ReturnMilliseconds(int[] param_array)
        {
            //
            // Added 3/1/2020 thomas downes 
            //
            //    https://sorting.at   
            //

            return Sort_ReturnMilliseconds(param_array, true, false);

        }

        public override double Sort_ReturnMilliseconds(int[] param_array, bool pboolSortInput, bool pboolDontSortIt)
        {
            //
            // Added 3/1/2020 thomas downes 
            //
            //    https://sorting.at   
            //







            return 0;


        }

        private void Partituing_by_Hoare(int[] param_array, int par_indexOfPivot)
        {
            //
            // Renamed from "Sort_InPlace_ByPivotIndex".  
            //
            // Added 3/12/2020 thomas downes 
            //
            //      Let's use Lamuto's Partitioning / Two-Pointer Approach   
            //
            if (1 == param_array.Length) return;

            int intPivotValue = param_array[par_indexOfPivot];
            int intCurrentPivotIndex = par_indexOfPivot;
            //int intInnerPointer = 0;
            bool bLeftOfPivot;
            bool bRightOfPivot;

            //
            //  Ironically, we take the pivot __out__ of the bulk of the array. 
            //
            //  Put the Pivot at the leftmost lefthand position of the array. 
            //
            int intTempValue = param_array[0];
            param_array[0] = param_array[intCurrentPivotIndex];
            param_array[intCurrentPivotIndex] = intTempValue;
            intCurrentPivotIndex = 0; 

            //
            //  Let's begin Hoare's Partioning.   
            //
            //  Hoare's Partitioning uses two pointers which begin at opposite sides of the 
            //  array.
            //
            //  The pivot is now at Index 0, so our loop below will skip tha 0t                    
            //
            for (int intPointerIndex = 1; intPointerIndex <= -1 + param_array.Length; intPointerIndex++)
            {
                //
                // Avoid the pivot itself. 
                //
                if (intPointerIndex == intCurrentPivotIndex) continue;

                //
                // Hoare's Partitioning???   
                //
                //  Hoare's Partitioning uses two pointers which begin at opposite sides of the 
                //  array.  
                //
                bLeftOfPivot = (intPointerIndex < intCurrentPivotIndex);
                bRightOfPivot = (intPointerIndex > intCurrentPivotIndex);

                //
                //  
                //






            }

            return;

        }
    }
}
