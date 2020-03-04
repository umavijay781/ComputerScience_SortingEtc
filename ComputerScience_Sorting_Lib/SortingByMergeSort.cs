using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;  // Added 3/3/2020 thomas downes

namespace ComputerScience_Sorting_Lib
{
    class SortingByMergeSort : ParentAbstractClass
    {

        //private Dictionary<int, int[]> mod_arraysByLength = new Dictionary<int, int[]> ();
        private List<int[]> mod_list_splitArrays = new List<int[]> ();
        //----00--private Lookup<int, int[]> mod_arraysByLength; // = new Lookup<int, int[]>();

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
            Split_Array_Recursive(current_array);

            //
            //  Lookup<TKey,TElement> Class 
            //  https://docs.microsoft.com/en-us/dotnet/api/system.linq.lookup-2?redirectedfrom=MSDN&view=netframework-4.8
            //
            // Create a Lookup to organize the packages. Use the first character of Company as the key value.
            // Select Company appended to TrackingNumber for each element value in the Lookup.
            //   Lookup<char, string> lookup = (Lookup<char, string>)packages.ToLookup(p => Convert.ToChar(p.Company.Substring(0, 1)),
            //                                                p => p.Company + " " + p.TrackingNumber);

            //----00--mod_arraysByLength = (Lookup<int, int[]>)mod_list_splitArrays.ToLookup(array => array.Length, array => array);

            const bool c_bCollectMergedArrays = true; // Conveniently, we can use the same collection that houses
            //  the split-up arrays, to also house the merged arrays as they get bigger and bigger. 

            for (int intSize = 2; intSize < intLength_param_array; intSize++)
            {
                //
                //
                //
                //mod_arraysByLength.Append<Tuple<int, int[]>>(Tuple.Create(5, new int[] { 45, 67 }));

                Merge_AllArrays_BySize( mod_list_splitArrays, intSize, c_bCollectMergedArrays);

                //
                // Refresh the Lookup.  
                //
                //----00--mod_arraysByLength = (Lookup<int, int[]>)mod_list_splitArrays.ToLookup(array => array.Length, array => array);

            }

            //return param_array;

            int intCountOfRemainingArrays = mod_list_splitArrays.Count;

            if (1 != intCountOfRemainingArrays) throw new Exception("We are supposed to have only one left.");

            timeFinish = DateTime.Now;
            double millisecondsTime = (timeFinish - timeStart).TotalMilliseconds;
            return millisecondsTime;

        }

        private void Merge_AllArrays_BySize(List<int[]> par_list_splitArrays, int param_intSize,
                           bool par_RollMergedArraysIntoList)
        {
            //
            // https://docs.microsoft.com/en-us/dotnet/api/system.linq.lookup-2?redirectedfrom=MSDN&view=netframework-4.8
            //
            //foreach (int[] each_array in mod_arraysByLength.Where(p => p.Key == param_intSize).Select(p => p.ElementAt))

            //List<int[]> list_arrays = new List<int[]> ();

            //Func<IGrouping<int, int[]>, bool> my_function_predicate;
            //my_function_predicate = (p => (p.Key == param_intSize || p.Key == (+1 + param_intSize)));
            
            Func<int[], bool> my_function_predicate;
            my_function_predicate = (p => (p.Length == param_intSize || p.Length == (+1 + param_intSize)));

            //var group_of_arrays = mod_arraysByLength.Where(my_function_predicate);
            //var group_of_arrays = mod_list_splitArrays.Where(my_function_predicate);
            var group_of_arrays = par_list_splitArrays.Where(my_function_predicate);

            //
            // Iterate through the arrays of a certain approximate length (length || (1 + length)). 
            //
            //foreach (IGrouping<int, int[]> each_packageGroup in group_of_arrays)
            //{
            //    for (int intIndex = 0; intIndex <= each_packageGroup.Count(); intIndex++)
            //    {
            //        list_arrays.Add(packageGroup.ElementAt(0));
            //    }
            //}

            int[] prior_array = null;
            int[] new_merged_array = null; 

            foreach (int[] each_array in group_of_arrays)
            {
                if (prior_array == null)
                {
                    prior_array = each_array;
                }
                else
                {
                    new_merged_array =
                        Merge_Arrays(prior_array, each_array);
                    //
                    //Follow-up work. 
                    //
                    if (par_RollMergedArraysIntoList)
                    {
                        //mod_list_splitArrays.Add(new_merged_array);
                        par_list_splitArrays.Add(new_merged_array);
                    }
                    //mod_list_splitArrays.Remove(prior_array);
                    //mod_list_splitArrays.Remove(each_array);
                    prior_array = null;
                    new_merged_array = null; 
                }
            }

            //
            //Follow-up work. 
            //
            Predicate<int[]> my_predicate = 
                (p => (p.Length == param_intSize || 
                p.Length == (+1 + param_intSize))) ;
            //
            // Remove the array items. 
            //
            //mod_list_splitArrays.RemoveAll(my_predicate);
            par_list_splitArrays.RemoveAll(my_predicate);

        }

        private bool Split_Array_Recursive(int[] param_array)
        {
            //
            // private Tuple<int[],int[]> Split_Array(int[] param_array, ref bool pref_noOperation)
            //
            // Added 3/3/2020 thomas d.
            //
            //if (param_array.Length == 1)
            if (param_array.Length <= 2)
            {
                //pref_noOperation = true;
                //return null;
                Sort_AdjacentPair(param_array, 1);
                //mod_arraysByLength.Add(param_array.Length, param_array);
                mod_list_splitArrays.Add(param_array);
                return false;
            }

            int[] array1of2 = new int[param_array.Length % 2];
            int[] array2of2 = new int[param_array.Length - (param_array.Length / 2)];

            //param_array.CopyTo(array1of2, 0);
            int intStartOfCopy2;  // = array1of2.Length;
            //param_array.CopyTo(array2of2, intStartOfCopy2);

            //Fill the half-shorter array #1 of 2. 
            CopyFromArrayToShorterArray(param_array, array1of2, 0);
            //Fill the half-shorter array #1 of 2. 
            intStartOfCopy2 = array1of2.Length;  // Skip the same number of items as the 
            CopyFromArrayToShorterArray(param_array, array2of2, intStartOfCopy2);

            //return new Tuple<int[], int[]>(array1of2, array2of2 );

            //
            //Recursive Call #1 of 2
            //
            Split_Array_Recursive(array1of2);

            //
            //Recursive Call #2 of 2
            //
            Split_Array_Recursive(array2of2);

            return true; 

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
                if ((intIndexInputArr1 <= -1 + param_array1.Length) && (param_array1[intIndexInputArr1] < param_array2[intIndexInputArr2]))
                {
                    intValueLesser = param_array1[intIndexInputArr1];
                    intIndexInputArr1++;
                }
                else if (intIndexInputArr2 <= -1 + param_array2.Length)
                {
                    intValueLesser = param_array2[intIndexInputArr2];
                    intIndexInputArr2++;
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
