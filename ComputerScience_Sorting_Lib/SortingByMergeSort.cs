using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerScience_Sorting_Lib
{
    class SortingByMergeSort : ParentAbstractClass
    {

        public override double Sort_ReturnMilliseconds(int[] param_array)
        {
            //
            // Added 3/1/2020 thomas downes 
            //
            //    https://sorting.at   
            //
            //throw new NotImplementedException();

            DateTime timeStart = DateTime.Now;
            DateTime timeFinish = DateTime.MaxValue;
            bool bKeepLooping = true;
            bool bNoSplitPossible = false;
            int[] current_array = param_array;  

            do
            {
                Tuple<int[], int[]> two_arrays_fromOne =
                    Split_Array(current_array, ref bNoSplitPossible);


            } while (bKeepLooping);

            //return param_array;

            timeFinish = DateTime.Now;
            double millisecondsTime = (timeFinish - timeStart).TotalMilliseconds;
            return millisecondsTime;

        }

        private Tuple<int[],int[]> Split_Array(int[] param_array, ref bool pref_noOperation)
        {
            //
            // Added 3/3/2020 thomas d.
            //
            if (param_array.Length == 1)
            {
                pref_noOperation = true;
                return null;  
            }

            int[] array1of2 = new int[param_array.Length % 2];
            int[] array2of2 = new int[param_array.Length - (param_array.Length / 2)];

            param_array.CopyTo(array1of2, 0);

            int intStartOfCopy2 = array1of2.Length;
            param_array.CopyTo(array2of2, intStartOfCopy2);

            return new Tuple<int[], int[]>(array1of2, array2of2 );

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
            int intValueGreater;
            int intValueLesser; 

            for (int intIndexInput = 0; intIndexInput < (-1 + intLengthCommon); intIndexInput++)
            {
                intValueGreater = (param_array1[intIndexInput] > param_array2[intIndexInput] ? param_array1[intIndexInput] : param_array2[intIndexInput]);
                intValueLesser = (param_array1[intIndexInput] < param_array2[intIndexInput] ? param_array1[intIndexInput] : param_array2[intIndexInput]);

                array_out_merged[intIndexOutput] = intValueLesser;
                Sort_AdjacentPair(array_out_merged, intIndexOutput);
                intIndexOutput++;
                array_out_merged[intIndexOutput] = intValueGreater;
                Sort_AdjacentPair(array_out_merged, intIndexOutput);
                intIndexOutput++;
            }

            if (bArray1_IsLonger && intLengthDifference == 1)
            {
                //
                // Array # 1 is longer. 
                //
                array_out_merged[intIndexOutput] = param_array1[-1 + param_array1.Length];
                Sort_AdjacentPair(array_out_merged, intIndexOutput);
            }
            else if (intLengthDifference == 1)
            {
                //
                // Array # 2 is longer. 
                //
                array_out_merged[intIndexOutput] = param_array2[-1 + param_array2.Length];
                Sort_AdjacentPair(array_out_merged, intIndexOutput);
            }

            return array_out_merged;

        }

        private void Sort_AdjacentPair(int[] param_array, int param_indexOf2ndItem)
        {
            //
            // If needed, switch the most-recently-added pair of integers (in the merged array).  
            //
            if (param_array[param_indexOf2ndItem] < param_array[-1 + param_indexOf2ndItem] )
            {
                int intTemp = param_array[param_indexOf2ndItem];
                param_array[param_indexOf2ndItem] = param_array[-1 + param_indexOf2ndItem];
                param_array[-1 + param_indexOf2ndItem] = intTemp;
            }

        }



    }
}
