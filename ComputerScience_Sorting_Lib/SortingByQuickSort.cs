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

        public void Partitioning_by_Hoare(int[] param_array, int par_indexOfPivot)
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
            //      (Swap the Pivot Value at the position 0.) 
            //
            int intTempValue = param_array[0];
            param_array[0] = param_array[intCurrentPivotIndex];
            param_array[intCurrentPivotIndex] = intTempValue;

            //intCurrentPivotIndex = 0;
            bool bKeepLooping = true;

            //
            //  Let's begin Hoare's Partioning.   
            //
            //  Hoare's Partitioning uses two pointers which begin at opposite sides of the 
            //  array.
            //
            //  The pivot is now at Index 0, so our loop below will skip tha 0t                    
            //
            // for (int intPointerIndex = 1; intPointerIndex <= -1 + param_array.Length; intPointerIndex++)

            int intPointerIndex_I = 1;
            int intPointerIndex_K = -1 + param_array.Length;
            bool bNeedToThrow_LeftToRight = false;
            bool bNeedToThrow_RightToLeft = false; 

            do
            {
                //
                //  ---*---This was taken care of, by swapping with item #0.---
                //  ---*--Skip/avoid the pivot itself. 
                //
                // if (intPointerIndex == intCurrentPivotIndex) continue;

                //
                // Hoare's Partitioning???   
                //
                //  Hoare's Partitioning uses two pointers which begin at opposite sides of the 
                //  array.  
                //
                // bLeftOfPivot = (intPointerIndex < intCurrentPivotIndex);
                // bRightOfPivot = (intPointerIndex > intCurrentPivotIndex);

                //
                //Find the first lefthand item which should be "thrown" to the right,
                //   i.e. from left side to the right side). 
                //
                do
                {
                    intPointerIndex_I++;

                    //Unlikely to occur....
                    if (intPointerIndex_I > -1 + param_array.Length) break;

                    bNeedToThrow_LeftToRight = (param_array[intPointerIndex_I] > intPivotValue);

                    if (intPointerIndex_I > intPointerIndex_K) break;

                } while (false == bNeedToThrow_LeftToRight);


                //Have the two pointers croseed each other? 
                bKeepLooping = (intPointerIndex_I < intPointerIndex_K);
                if (false == bKeepLooping) break;


                //
                //Find the first righthand item which should be "thrown" to the left (i.e. right-to-left). 
                //
                do
                {
                    intPointerIndex_K--;
                    
                    //Unlikely to occur....
                    if (intPointerIndex_K < 1) break;

                    bNeedToThrow_RightToLeft = (param_array[intPointerIndex_K] < intPivotValue);

                    //if (intPointerIndex_K < intPointerIndex_I) break;
                    bKeepLooping = (intPointerIndex_I < intPointerIndex_K);
                    if (bKeepLooping) break;

                } while (false == bNeedToThrow_LeftToRight);

                //Unlikely to occur....
                bKeepLooping = (intPointerIndex_I <= -1 + param_array.Length);
                if (false == bKeepLooping) break;
                //Unlikely to occur....
                bKeepLooping = (intPointerIndex_K >= 1);
                if (false == bKeepLooping) break;

                //Have the two pointers croseed each other? 
                bKeepLooping = (intPointerIndex_I < intPointerIndex_K);
                if (false == bKeepLooping) break;

                //
                //  Swap / Throw
                //
                int intThrow_LeftToRight = param_array[intPointerIndex_I];
                int intThrow_RightToLeft = param_array[intPointerIndex_K];
                
                param_array[intPointerIndex_I] = intThrow_RightToLeft;
                param_array[intPointerIndex_K] = intThrow_LeftToRight;

            } while (bKeepLooping);

            //
            //Place the Pivot Value where it should go, i.e. somewhere
            //   in the midst of the array (vs. in the 0th position). 
            //
            int intLessThanPivot = param_array[intPointerIndex_K];
            param_array[intPointerIndex_K] = intPivotValue;
            param_array[0] = intLessThanPivot;

            //
            //We have completed our work.  
            //
            return;

        }
    }
}
