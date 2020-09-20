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
            bool bTrivialCase = false;  
            bool bErrorOccurred = false;
            string sErrorMessage = "";

            const bool c_boolHoaresPartitioning = true;
            const bool c_bPivotValueCanBeFirstItem = true; 
            
            if (c_boolHoaresPartitioning && pboolSortInput)
            {
                int intIndexOfPivot = -1;
                if (c_boolHoaresPartitioning) intIndexOfPivot = 0;
                else System.Diagnostics.Debugger.Break();

                //
                //----Major call !!  
                //
                Partitioning_by_Hoare(param_array, 0, -1 + param_array.Length, 
                    intIndexOfPivot, ref bTrivialCase, ref bErrorOccurred, ref sErrorMessage);           
            }

            return 0;

        }

        public void Partitioning_by_Hoare(int[] param_array, 
                                          int par_indexStart, 
                                          int par_indexEnd, 
                                          int par_indexOfPivot, 
                                          ref bool par_bTrivialCase, 
                                          ref bool par_bErrorOccurred,
                                          ref string par_sErrorMessage)
        {
            //
            // Renamed from "Sort_InPlace_ByPivotIndex".  
            //
            // Added 3/12/2020 thomas downes 
            //
            // Let's use Hoare's Partitioning / Two-Pointer Approach  
            //
            //      (Lamuto's Partitioning will be a different procedure.)    
            //
            if (1 == param_array.Length) par_bTrivialCase = true;
            if (1 == param_array.Length) return;

            if (par_indexStart == par_indexEnd) par_bTrivialCase = true;
            if (par_indexStart == par_indexEnd) return;

            if (par_indexStart > par_indexEnd) par_bErrorOccurred = true;
            if (par_indexStart > par_indexEnd) par_sErrorMessage = "par_indexStart > par_indexEnd";
            if (par_indexStart >= par_indexEnd) return;

            if (par_indexOfPivot > par_indexEnd) par_bErrorOccurred = true;
            if (par_indexOfPivot > par_indexEnd) par_sErrorMessage = "par_indexOfPivot > par_indexEnd";
            if (par_indexOfPivot > par_indexEnd) return;

            if (par_indexOfPivot < par_indexStart) par_bErrorOccurred = true;
            if (par_indexOfPivot < par_indexStart) par_sErrorMessage = "par_indexOfPivot < par_indexStart";
            if (par_indexOfPivot < par_indexStart) return;

            if (par_indexEnd >= param_array.Length) par_bErrorOccurred = true;
            if (par_indexEnd >= param_array.Length) par_sErrorMessage = "par_indexEnd >= param_array.Length";
            if (par_indexEnd >= param_array.Length) return;

            int intPivotValue = param_array[par_indexOfPivot];
            int intCurrentPivotIndex = par_indexOfPivot;
            //int intInnerPointer = 0;
            //bool bLeftOfPivot;
            //bool bRightOfPivot;

            //
            //  Ironically, we take the pivot __out__ of the inner bulk of the array. 
            //
            //  Put the Pivot at the leftmost lefthand position of the array. 
            //
            //      (Swap the Pivot Value at the position 0.) 
            //
            //-----int intTempValue = param_array[0];
            if (par_indexOfPivot != par_indexStart)
            {
                //  Put the Pivot Item (Value) at the first, leftmost position of the sub-array
                //    defined by par_indexStart and par_indexEnd. 
                //    ----9/19/2020
                int intTempValue = param_array[par_indexStart];
                param_array[par_indexStart] = param_array[intCurrentPivotIndex];
                param_array[intCurrentPivotIndex] = intTempValue;
                //We have swapped the values, so the Pivot Index
                //   becomes the starting index of the sub-array. 
                intCurrentPivotIndex = par_indexStart;
            }

            //intCurrentPivotIndex = 0;
            bool bKeepLooping = true;
            bool bPointersCrossed = false;

            //
            //  Let's begin Hoare's Partioning.   
            //
            //  Hoare's Partitioning uses two pointers which begin at opposite sides of the 
            //  array.
            //
            //  The pivot is now at Index 0, so our loop below will skip tha 0t                    
            //
            // for (int intPointerIndex = 1; intPointerIndex <= -1 + param_array.Length; intPointerIndex++)

            //int intPointerIndex_I = 1;
            //int intPointerIndex_K = -1 + param_array.Length;
            //int intPointerIndex_I = par_indexStart + 1;
            int intPointerIndex_I = (intCurrentPivotIndex + 1);
            int intPointerIndex_K = par_indexEnd;

            bool boolLetsIncrementPointer_Left = false;
            bool boolLetsDecrementPointer_Right = false; 

            bool bNeedToThrow_LeftToRight = false;
            bool bNeedToThrow_RightToLeft = false;

            bool bItemIs_GreaterThanPivot = false;
            bool bItemIs_LessThanOrEqualToPivot = false;

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
                bNeedToThrow_LeftToRight = false; //Reinitialize; 
                do
                {
                    //----moved to bottom of loop---intPointerIndex_I++;

                    if (boolLetsIncrementPointer_Left) intPointerIndex_I++;

                    //Unlikely to occur, but possible....
                    if (intPointerIndex_I > -1 + param_array.Length) break;
                    if (intPointerIndex_I > par_indexEnd) break;

                    bItemIs_GreaterThanPivot = (param_array[intPointerIndex_I] > intPivotValue);
                    bNeedToThrow_LeftToRight = bItemIs_GreaterThanPivot;

                    //The following isn't needed at first, but will be needed eventually.
                    //----if (intPointerIndex_I > intPointerIndex_K) break;
                    bPointersCrossed = (intPointerIndex_I > intPointerIndex_K);

                    boolLetsIncrementPointer_Left = (false == (bPointersCrossed || bNeedToThrow_LeftToRight));

                } while (boolLetsIncrementPointer_Left);  //---- (false == bNeedToThrow_LeftToRight);


                //Have the two pointers croseed each other? 
                bKeepLooping = (intPointerIndex_I < intPointerIndex_K);
                if (false == bKeepLooping) break;


                //
                //Find the first righthand item which should be "thrown" to the left (i.e. right-to-left). 
                //
                bNeedToThrow_RightToLeft = false; //Reinitialize; 
                do
                {
                    //----moved to bottom of loop---intPointerIndex_K--;
                    if (boolLetsDecrementPointer_Right) intPointerIndex_K--;

                    //Unlikely to occur....
                    if (intPointerIndex_K < 1) break;
                    if (intPointerIndex_K < par_indexStart) break;

                    //bNeedToThrow_RightToLeft = (param_array[intPointerIndex_K] < intPivotValue);
                    bItemIs_LessThanOrEqualToPivot = (param_array[intPointerIndex_K] <= intPivotValue);
                    bNeedToThrow_RightToLeft = bItemIs_LessThanOrEqualToPivot;

                    //The following isn't needed at first, but will be needed eventually.
                    //----if (intPointerIndex_I > intPointerIndex_K) break;
                    bPointersCrossed = (intPointerIndex_I > intPointerIndex_K);

                    boolLetsDecrementPointer_Right = (false == (bPointersCrossed || bNeedToThrow_RightToLeft));

                } while (boolLetsDecrementPointer_Right);  //----(false == bNeedToThrow_LeftToRight);

                const bool c_checkPointers = false;
                if (c_checkPointers)
                {
                    //Unlikely to be needed....
                    bKeepLooping = (intPointerIndex_I <= -1 + param_array.Length);
                    if (false == bKeepLooping) break;
                    //Unlikely to be needed....
                    bKeepLooping = (intPointerIndex_K >= 1);
                    if (false == bKeepLooping) break;
                    //Have the two pointers croseed each other? 
                    bKeepLooping = (intPointerIndex_I < intPointerIndex_K);
                    if (false == bKeepLooping) break;
                }

                //
                //  Swap / Throw
                //
                if (bNeedToThrow_LeftToRight && bNeedToThrow_RightToLeft)
                {
                    int intThrow_LeftToRight = param_array[intPointerIndex_I];
                    int intThrow_RightToLeft = param_array[intPointerIndex_K];

                    param_array[intPointerIndex_I] = intThrow_RightToLeft;
                    param_array[intPointerIndex_K] = intThrow_LeftToRight;

                    boolLetsIncrementPointer_Left = true;
                    boolLetsDecrementPointer_Right = true;
                }
                else bKeepLooping = false;

            } while (bKeepLooping);

            //
            //Place the Pivot Value where it should go, i.e. somewhere
            //   in the midst of the array (vs. in the 0th position). 
            //
            int intLessThanPivot;
            const bool c_bMovePivotToPointerK = false;
            if (c_bMovePivotToPointerK)
            {
                intLessThanPivot = param_array[intPointerIndex_K];
                param_array[intPointerIndex_K] = intPivotValue;
                param_array[intCurrentPivotIndex] = intLessThanPivot;
                //Refresh the location of the Pivot.
                intCurrentPivotIndex = intPointerIndex_K;
            }
            else
            {
                intLessThanPivot = param_array[intPointerIndex_I];
                param_array[intPointerIndex_I] = intPivotValue;
                param_array[intCurrentPivotIndex] = intLessThanPivot;
                //Refresh the location of the Pivot.
                intCurrentPivotIndex = intPointerIndex_I;
            }

            //
            //---Recursive call !!   Left-hand branch. 
            //
            int intNextPivotIndex = par_indexStart;
            Partitioning_by_Hoare(param_array, par_indexStart, -1 + intCurrentPivotIndex,
                intNextPivotIndex, ref pbTrivialCase, ref pbErrorOccurred, ref psErrorMessage);

            //
            //---Recursive call !!   Right-hand branch. 
            //
            intNextPivotIndex = +1 + intCurrentPivotIndex;
            Partitioning_by_Hoare(param_array, +1 + intCurrentPivotIndex, par_indexEnd,
                intNextPivotIndex, ref bTrivialCase, ref bErrorOccurred, ref sErrorMessage);

            //
            //We have completed our work.  
            //
            return;

        }

        public void Partitioning_by_Lamuto(int[] param_array, int par_indexOfPivot)
        {
            //
            // Renamed from "Sort_InPlace_ByPivotIndex".  
            //
            // Added 3/12/2020 thomas downes 
            //
            //      Let's use Lamuto's Partitioning / Two-Pointer Approach   
            //
            if (1 == param_array.Length) return;

      

        }
    }
