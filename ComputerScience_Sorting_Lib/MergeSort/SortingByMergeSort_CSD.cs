using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerScience_Sorting_Lib
{
    //
    //
    //  Let's implement page 50 (top) of __Computer Science Distilled__
    //      ----3/5/2020 thomas downes
    //
    public class SortingByMergeSort_CSD : ParentAbstractClass
    {
        //
        //  _CSD = _Computer Science Distilled_ by Wladston Ferreira Filho, pub. Code Energy LLC
        //
        //
        //  Let's implement page 50 (top) of __Computer Science Distilled__
        //      ----3/5/2020 thomas downes
        //
        //
        //private Dictionary<int, int[]> mod_arraysByLength = new Dictionary<int, int[]> ();
        private List<int[]> mod_list_splitArrays = new List<int[]>();
        //----00--private Lookup<int, int[]> mod_arraysByLength; // = new Lookup<int, int[]>();

        public override double Sort_ReturnMilliseconds(int[] param_array)
        {
            //
            // Added 3/1/2020 thomas downes 
            //
            return Sort_ReturnMilliseconds(param_array, true, false);

        }

        public override double Sort_ReturnMilliseconds(int[] param_array, bool pbPleaseSortInput, bool pbPleaseDontSortInput)
        {
            //
            // Added 3/1/2020 thomas downes 
            //
            //    https://sorting.at   
            //
            //throw new NotImplementedException();

            DateTime timeStart = DateTime.Now;
            DateTime timeFinish = DateTime.MaxValue;
            //bool bKeepLooping = true;
            //bool bNoSplitPossible = false;
            int[] current_array = param_array;
            int intLength_param_array = param_array.Length;

            //do
            //{
            //    Tuple<int[], int[]> two_arrays_fromOne =
            //        Split_Array(current_array, ref bNoSplitPossible);
            //} while (bKeepLooping);

            //
            //Splitting part
            //
            merge_sort(current_array);

            //
            //Copy the sorted items back to the original input array. 
            //
            if (pbPleaseSortInput)
            {
                for (int intIndex = 0; intIndex < param_array.Length; intIndex++)
                {
                    //3-6-2020 td//param_array[intIndex] = array_sortingCompleted[intIndex];
                    param_array[intIndex] = current_array[intIndex];
                }
            }

            timeFinish = DateTime.Now;
            double millisecondsTime = (timeFinish - timeStart).TotalMilliseconds;
            return millisecondsTime;

        }


        private int[] merge_sort(int[] param_array)
        {
            //
            // Added 3/5/2020 thomas d.
            //
            if (param_array.Length == 1)
            {
                return param_array;
            }

            int[] array1of2;
            int[] array2of2;
            
            array1of2 = new int[param_array.Length / 2];
            array2of2 = new int[param_array.Length - (param_array.Length / 2)];

            int intStartOfCopy2;  // = array1of2.Length;

            //Fill the half-shorter array #1 of 2. 
            CopyFromArrayToShorterArray(param_array, array1of2, 0);
            //Fill the half-shorter array #1 of 2. 
            intStartOfCopy2 = array1of2.Length;  // Skip the same number of items as the 
            CopyFromArrayToShorterArray(param_array, array2of2, intStartOfCopy2);

            //
            //Recursive Call #1 of 2
            //
            merge_sort(array1of2);

            //
            //Recursive Call #2 of 2
            //
            merge_sort(array2of2);

            //
            // Merge two arrays and return the single, merged array. 
            //
            return Merge_Arrays(array1of2, array2of2);

        }



        private void CopyFromArrayToShorterArray(int[] param_arraySource, int[] param_arrayShort, int par_StartSourceIndex)
        {
            //
            //It's annoying that I had to write this function, rather then using
            //   the CopyTo method of the Array.   The CopyTo method is persnickety
            //   about the target array being big enough to contain all of the 
            //   source values.   -----3/4/2020 thomas d. 
            //
            //bool bShortArrayIsFilled = false;
            int intIndexSource = -1;
            int intIndexTarget = -1;

            //for (int intIndex = par_StartSourceIndex; intIndex <= (-1 + param_arraySource.Length); intIndex++ )
            //{
            //    bShortArrayIsFilled = (intIndex - par_StartSourceIndex > -1 + param_arrayShort.Length);
            //    if (bShortArrayIsFilled) break;
            //    param_arrayShort[intIndex - par_StartSourceIndex] = param_arraySource[intIndex];
            //}

            foreach (int intEachValue in param_arraySource)
            {
                intIndexSource++;

                //Skip the first (-1 + par_StartSourceIndex) items.
                if (intIndexSource < par_StartSourceIndex) continue;

                try
                {
                    intIndexTarget++;  // This will start at 0 and progress through all the slots of the target array.
                    param_arrayShort[intIndexTarget] = intEachValue;  // Fill the target array with the source value.
                }
                catch // (Exception ex)
                {
                    //We are done filling up the array. 
                    //   string strErrMessage = ex.Message;
                    break;
                }
            }

        }


        private int[] Merge_Arrays(int[] param_array1, int[] param_array2)
        {
            //
            // Added 3/3/2020 thomas d.
            //
            bool boolEqualLength = (param_array1.Length == param_array2.Length);
            bool bUnequalLength = (param_array1.Length != param_array2.Length);
            bool bArray1_IsLonger = (param_array1.Length > param_array2.Length);

            int intLengthDifference = (bArray1_IsLonger ?
                   (param_array1.Length - param_array2.Length) :
                   (param_array2.Length - param_array1.Length));

            int intLengthCommon = (param_array1.Length > param_array2.Length ? param_array2.Length : param_array1.Length);
            int intLengthCombined = (param_array1.Length + param_array2.Length);
            int[] array_out_merged = new int[intLengthCombined];

            if (intLengthDifference > 1) throw new NotSupportedException("Arrays must be nearly-equal in length.");

            //
            //Looping !!   Added 3/3/2020 thomas downes
            //
            int intIndexOutput = 0;
            int intIndexInputArr1 = 0;
            int intIndexInputArr2 = 0;
            int intValueGreater;
            int intValueLesser;
            bool bKeepLooping = true; //Added 3/3/2020 thomas downes

            //for (int intIndexInput = 0; intIndexInput < (-1 + intLengthCommon); intIndexInput++)
            //{
            //    intValueGreater = (param_array1[intIndexInput] > param_array2[intIndexInput] ? param_array1[intIndexInput] : param_array2[intIndexInput]);
            //    intValueLesser = (param_array1[intIndexInput] < param_array2[intIndexInput] ? param_array1[intIndexInput] : param_array2[intIndexInput]);

            //    array_out_merged[intIndexOutput] = intValueLesser;
            //    Sort_AdjacentPair(array_out_merged, intIndexOutput);
            //    intIndexOutput++;
            //    array_out_merged[intIndexOutput] = intValueGreater;
            //    Sort_AdjacentPair(array_out_merged, intIndexOutput);
            //    intIndexOutput++;
            //}

            do
            {
                //bool bExhaustedArray1 = (intIndexInputArr1 > -1 + param_array1.Length);
                //bool bExhaustedArray2 = (intIndexInputArr2 > -1 + param_array2.Length);
                bool bWithinArray1 = (intIndexInputArr1 <= -1 + param_array1.Length);
                bool bWithinArray2 = (intIndexInputArr2 <= -1 + param_array2.Length);
                bool bLesserIsArray1;

                //if ((intIndexInputArr1 <= -1 + param_array1.Length) && (param_array1[intIndexInputArr1] < param_array2[intIndexInputArr2]))
                if (bWithinArray1 && bWithinArray2)
                {
                    bLesserIsArray1 = (param_array1[intIndexInputArr1] < param_array2[intIndexInputArr2]);
                    intValueLesser = (bLesserIsArray1 ? param_array1[intIndexInputArr1] : param_array1[intIndexInputArr2]);
                    if (bLesserIsArray1) intIndexInputArr1++;  // Move the index for Array #1.
                    if (false == bLesserIsArray1) intIndexInputArr2++; // Move the index for Array #2.
                }
                else if (bWithinArray1)  // (intIndexInputArr1 <= -1 + param_array1.Length)
                {
                    intValueLesser = param_array1[intIndexInputArr1];
                    intIndexInputArr1++; // Move the index for Array #1.
                }
                else if (bWithinArray2)  // (intIndexInputArr2 <= -1 + param_array2.Length)
                {
                    intValueLesser = param_array2[intIndexInputArr2];
                    intIndexInputArr2++; // Move the index for Array #2.
                }
                else
                {
                    intValueLesser = -99;
                }

                array_out_merged[intIndexOutput] = intValueLesser;
                intIndexOutput++;
                bKeepLooping = (intIndexInputArr1 <= -1 + param_array1.Length) ||
                               (intIndexInputArr2 <= (-1 + param_array2.Length));

            } while (bKeepLooping);


            if (bArray1_IsLonger && intLengthDifference == 1)
            {
                //
                // Array # 1 is longer. 
                //
                array_out_merged[intIndexOutput] = param_array1[-1 + param_array1.Length];
                //Sort_AdjacentPair(array_out_merged, intIndexOutput);
                SortingByMergeSort_TD.Sort_AdjacentPair(array_out_merged, intIndexOutput);
            }
            else if (intLengthDifference == 1)
            {
                //
                // Array # 2 is longer. 
                //
                array_out_merged[intIndexOutput] = param_array2[-1 + param_array2.Length];
                //Sort_AdjacentPair(array_out_merged, intIndexOutput);
                SortingByMergeSort_TD.Sort_AdjacentPair(array_out_merged, intIndexOutput);
            }

            return array_out_merged;

        }









    }
}
