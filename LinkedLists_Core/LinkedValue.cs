using System;
using System.Collections.Generic;
using System.Text;

//
//Added 3/2/2020 thomas downes
//
namespace LinkedLists_Core
{
    public class LinkedValue
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

        public bool Contains_ThisOrNext(int par_intSearchingFor)
        {
            //
            //Added 3/2/2020  thomas downes  
            //
            bool boolFound;
            boolFound = (par_intSearchingFor == this.Value);

            if (NextValue != null && (boolFound == false))
            {
                //bool boolFound;
                //boolFound = (par_intSearchingFor == NextValue.Value);
                boolFound = NextValue.Contains_ThisOrNext(par_intSearchingFor);
            }

            return boolFound; 

        }

        public int GetValue_ByIndex(int par_index)
        {
            //
            //Added 3/2/2020 thomas downes
            //
            if (par_index == 0)
            {
                return this.Value;
            }
            else if (NextValue != null)
            {
                par_index--;
                return NextValue.GetValue_ByIndex(par_index);
            }
            throw new InvalidOperationException("Indexing error!!");
        }

        public void SetValue_ByIndex(int par_index, int par_value)
        {
            //
            //Added 3/2/2020 thomas downes
            //
            if (par_index == 0)
            {
                this.Value = par_value;
            }
            else if (NextValue != null)
            {
                par_index--;
                this.NextValue.SetValue_ByIndex(par_index, par_value);
            }
        }





    }
}
