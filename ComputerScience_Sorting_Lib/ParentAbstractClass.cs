using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerScience_Sorting_Lib
{
    /// <summary>
    /// See "Big-O Notation" in my small green Computer Science book. 
    /// </summary>
    public enum Enum_BigO_Time{ 
       Undetermined, 
        NSquared_eg_Bubble, 
        NLogN_eg_Merge, 
        NLinear, 
        LogN, 
        ConstantTime,
        Exponential
    }

    public enum Enum_DataSetSize
    {
        Undetermined,
        N_is20,
        N_is50,
        N_is100
    }

    public abstract class ParentAbstractClass : ISortingByTypeOfSort
    {
        /// <summary>
        /// Abstract method. 
        /// </summary>
        /// <param name="param_array"></param>
        /// <returns></returns>
        public abstract double Sort_ReturnMilliseconds(int[] param_array);

        /// <summary>
        /// Abstract method. 
        /// </summary>
        /// <param name="param_array"></param>
        /// <returns></returns>
        public abstract double Sort_ReturnMilliseconds(int[] param_array, 
            bool pbPleaseSortInputArray,
            bool pbPleaseDontSortInput);

        /// <summary>
        /// Virtual (overridable) method.  
        /// </summary>
        /// <param name="par_milliseconds1"></param>
        /// <param name="par_milliseconds2"></param>
        /// <returns></returns>
        public virtual bool CompareSortingTimes(double par_milliseconds1, double par_milliseconds2)
        {
            //
            // This is "virtual", i.e. ovveridable.  
            //
            // Added 3/3/2020 thomas downes  
            //

            return False;

        }

        public virtual Enum_BigO_Time DetermineBest_BigOEnum(int par_N_items, double par_milliseconds)
        {
            //
            // This is an approximation, or "Best Guess".   An accurate & reliable determination
            //    may necessitate human analysis over many trials.  At present, it is unknown
            //    how to automate this with anywhere-near-100% reliability.  
            //
            // This is "virtual", i.e. ovveridable.  
            //
            // Added 3/3/2020 thomas downes  
            //

            return Enum_BigO_Time.Undetermined;

        }

        public virtual int[] DataSetToTest(Enum_DataSetSize par_size)
        {
            switch (par_size)
            {
                case Enum_DataSetSize.N_is20:
                    return (new int[]
{ 23, 13, 45, 63, 23, 45, 32, 2, 67, 12,
                        91, 2, 67, 24 , 50, 45, 12, 78, 34, 43 });

                case Enum_DataSetSize.N_is50:
                    return (new int[]
{ 23, 13, 45, 63, 23, 45, 32, 2, 67, 12,
                        91, 2, 67, 24 , 50, 45, 12, 78, 34, 43,
                          65, 23, 45, 12, 89, 48, 81, 3, 67, 77,
                        81, 12, 57, 34 , 40, 55, 12, 88, 24, 53,
                          65, 23, 45, 12, 89, 48, 81, 3, 67, 77  });

                case Enum_DataSetSize.N_is100:
                    return (new int[]
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

                default: return null;
            }

        }


        public virtual Tuple<List<int>, string> DataSetToTest_Tuple(Enum_DataSetSize par_enumSize)
        {
            //
            //Added 3/4/2020 thomas downes
            //
            System.Text.StringBuilder sbAllNumbers = new StringBuilder(300);
            List<int> obj_listNums = new List<int>();

            foreach (int intEachValue in DataSetToTest(par_enumSize))
            {
                obj_listNums.Add(intEachValue);

                sbAllNumbers.Append("  " + intEachValue.ToString());

            }

            return Tuple.Create(obj_listNums, sbAllNumbers.ToString());

        }




    }
}
