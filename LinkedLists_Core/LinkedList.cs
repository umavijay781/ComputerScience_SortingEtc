using System;
//
//Added 3/2/2020 thomas downes
//

namespace LinkedLists_Core
{
    public class LinkedList
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
                
            mod_firstItem.CountItemsInChain(ref intCount);

            return intCount;  

        }

    }
}
