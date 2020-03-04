using System;

namespace ComputerScience_Sorting_Lib
{
    public class SortingByBubbleSort : ParentAbstractClass // : ISortingByTypeOfSort
    {
        public void TestSorting_TimesToComplete()
        {
            //
            // Added 3/1/2020 thomas downes 
            //
            Double ms_ForArrayLengthN_20 = 0;
            Double ms_ForArrayLengthN_50 = 0;
            Double ms_ForArrayLengthN_100 = 0;

            //ms_ForArrayLengthN_20 = Sort_ReturnMilliseconds(new int[] 
            //        { 23, 13, 45, 63, 23, 45, 32, 2, 67, 12, 
            //            91, 2, 67, 24 , 50, 45, 12, 78, 34, 43 } );
            ms_ForArrayLengthN_20 = Sort_ReturnMilliseconds(this.DataSetToTest(Enum_DataSetSize.N_is20));

            //ms_ForArrayLengthN_50 = Sort_ReturnMilliseconds(new int[]
            //        { 23, 13, 45, 63, 23, 45, 32, 2, 67, 12,
            //            91, 2, 67, 24 , 50, 45, 12, 78, 34, 43,
            //              65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
            //            81, 12, 57, 34 , 40, 55, 12, 88, 24, 53,
            //              65, 23, 45, 12, 89, 48, 81, 3, 67, 77  });
            ms_ForArrayLengthN_50 = Sort_ReturnMilliseconds(this.DataSetToTest(Enum_DataSetSize.N_is50));

            //ms_ForArrayLengthN_100 = Sort_ReturnMilliseconds(new int[]
            //        { 23, 13, 45, 63, 23, 45, 32, 2, 67, 12,
            //            91, 2, 67, 24 , 50, 45, 12, 78, 34, 43,
            //              65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
            //            81, 12, 57, 34 , 40, 55, 12, 88, 24, 53,
            //              65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
            //          23, 13, 45, 63, 23, 45, 32, 2, 67, 12,
            //            91, 2, 67, 24 , 50, 45, 12, 78, 34, 43,
            //              65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
            //            81, 12, 57, 34 , 40, 55, 12, 88, 24, 53,
            //              65, 23, 45, 12, 89, 48, 81, 3, 67, 77  });
            ms_ForArrayLengthN_100 = Sort_ReturnMilliseconds(this.DataSetToTest(Enum_DataSetSize.N_is100));




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

        public override double Sort_ReturnMilliseconds(int[] param_array, bool pbPleaseSortInput, bool pbDontSortInput)
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
            bool bOutOfOrder = false;
            int intTemp = 0;

            //
            // Will we work with a copy, or the original input array?  
            //
            int[] array_working;
            if (pbPleaseSortInput || (false == pbDontSortInput))
            {
                array_working = param_array;
            }
            else //----if (true || pbPleaseDontModifyInput)
            {
                array_working = new int[param_array.Length];
                param_array.CopyTo(array_working, 0);
            }

            do
            {
                intCountInversions = 0; //Reinitialize. 

                 for (int indexItem = 0; indexItem < -1 + array_working.Length; indexItem++)
                {
                    bOutOfOrder = (array_working[indexItem] > array_working[indexItem + 1]);
                    if (bOutOfOrder)
                    {
                        intCountInversions++;
                        intTemp = array_working[indexItem];
                        array_working[indexItem] = array_working[indexItem + 1];
                        array_working[indexItem + 1] = intTemp;
                    }
                }

            } while (intCountInversions != 0);

            //return param_array;

            timeFinish = DateTime.Now;
            double millisecondsTime = (timeFinish - timeStart).TotalMilliseconds;
            return millisecondsTime; 

        }
    }
}
