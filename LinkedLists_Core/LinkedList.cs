using System;
using System.Collections;
//
//Added 3/2/2020 thomas downes
//

namespace LinkedLists_Core
{
    public class LinkedList : IEnumerable
    {
        //
        //Added 3/2/2020 thomas downes
        //
        LinkedValue mod_firstItem;  

        public LinkedList(int param_FirstItem)
        {
            //
            //Added 3/2/2020 thomas downes
            //
            mod_firstItem = new LinkedValue(param_FirstItem);

        }

        public void Add(int param_NextItem)
        {
            //
            //Added 3/2/2020 thomas downes
            //
            mod_firstItem.PassValue_ToEndOfList(param_NextItem);

        }

        public int Count()
        {
            //
            //Added 3/2/2020 td 
            //
            int intCount = (mod_firstItem == null ? 0 : 1);

            if (mod_firstItem != null)
            {
                mod_firstItem.CountItemsInChain(ref intCount);
            }

            return intCount;   

        }

        public bool Contains(int par_intValue)
        {
            //
            //Added 3/2/2020 td 
            //
            bool boolFound = false; 

            if (mod_firstItem != null)
            {
                boolFound =
                  mod_firstItem.Contains_ThisOrNext(par_intValue);
            }

            return boolFound;

        }

        /// <summary>
        /// Include an indexer. 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int this[int par_index]
            {
            //
            //  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
            //
            get
            {
                //return mod_firstItem.GetValue_ByIndex(par_index).Value;
                return mod_firstItem.GetValue_ByIndex(par_index);
            }
            set
            {
                mod_firstItem.SetValue_ByIndex(par_index, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //
            //Added 3/2/2020 td 
            //
            return (IEnumerator)GetEnumerator();

        }

        public LinkedEnumerator GetEnumerator()
        {
            //
            //Added 3/2/2020 td 
            //
            return new LinkedEnumerator(this);

        }




    }
}
