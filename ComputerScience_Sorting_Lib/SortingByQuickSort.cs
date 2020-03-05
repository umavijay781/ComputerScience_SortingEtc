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
     }
 }
