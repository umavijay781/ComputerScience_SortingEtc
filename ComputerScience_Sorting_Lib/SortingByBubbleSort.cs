using System;

namespace ComputerScience_Sorting_Lib
{
    public class SortingByBubbleSort : ISortingByTypeOfSort
    {
        public void TestSorting_TimesToComplete()
        {
            Double ms_ForArrayLengthN_20 = 0;
            Double ms_ForArrayLengthN_50 = 0;
            Double ms_ForArrayLengthN_100 = 0;

            ms_ForArrayLengthN_20 = Sort_ReturnMilliseconds(new int[] 
                    { 23, 13, 45, 63, 23, 45, 32, 2, 67, 12, 
                        91, 2, 67, 24 , 50, 45, 12, 78, 34, 43 } );

            ms_ForArrayLengthN_50 = Sort_ReturnMilliseconds(new int[]
                    { 23, 13, 45, 63, 23, 45, 32, 2, 67, 12,
                        91, 2, 67, 24 , 50, 45, 12, 78, 34, 43,
                          65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
                        81, 12, 57, 34 , 40, 55, 12, 88, 24, 53,
                          65, 23, 45, 12, 89, 48, 81, 3, 67, 77  });

            ms_ForArrayLengthN_100 = Sort_ReturnMilliseconds(new int[]
                    { 23, 13, 45, 63, 23, 45, 32, 2, 67, 12,
                        91, 2, 67, 24 , 50, 45, 12, 78, 34, 43,
                          65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
                        81, 12, 57, 34 , 40, 55, 12, 88, 24, 53,
                          65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
                      23, 13, 45, 63, 23, 45, 32, 2, 67, 12,
                        91, 2, 67, 24 , 50, 45, 12, 78, 34, 43,
                          65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
                        81, 12, 57, 34 , 40, 55, 12, 88, 24, 53,
                          65, 23, 45, 12, 89, 48, 81, 3, 67, 77  });




        }

        public double Sort_ReturnMilliseconds(int[] param_array)
        {
            //throw new NotImplementedException();

            DateTime timeStart = DateTime.Now;
            DateTime timeFinish = DateTime.MaxValue; 
            int intCountBubbleSteps = -1;
            bool bOutOfOrder = false;
            int intTemp = 0; 

            do
            {
                intCountBubbleSteps = 0; //Reinitialize. 

                 for (int indexItem = 0; indexItem < -1 + param_array.Length; indexItem++)
                {
                    bOutOfOrder = (param_array[indexItem] > param_array[indexItem + 1]);
                    if (bOutOfOrder)
                    {
                        intCountBubbleSteps++;
                        intTemp = param_array[indexItem];
                        param_array[indexItem] = param_array[indexItem + 1];
                        param_array[indexItem + 1] = intTemp;
                    }
                }

            } while (intCountBubbleSteps != 0);

            //return param_array;

            timeFinish = DateTime.Now;
            double millisecondsTime = (timeFinish - timeStart).TotalMilliseconds;
            return millisecondsTime; 

        }
    }
}
