using System;
using System.Collections.Generic;
using System.Text;

//
//Added 3/2/2020 thomas downes
//
namespace LinkedLists_Core
{
    class LinkedValue
    {
        //
        //Added 3/2/2020 thomas downes
        //
        public int Value = 0;
        public LinkedValue NextValue;

        public LinkedValue(int param_value)
        {
            Value = param_value; 

        }

        public void PassValue_ToEndOfList(int param_value)
        {
            if (NextValue == null)
            {
                NextValue = new LinkedValue(param_value);
            }
            else
            {
                NextValue.PassValue_ToEndOfList(param_value);
            }

        }

        public void CountItemsInChain(ref int par_intCount)
        {
            //
            //Added 3/2/2020  thomas downes  
            //
            if (NextValue != null)
            {
                par_intCount++;  
                NextValue.CountItemsInChain(ref par_intCount);
            }

        }

    }
}
