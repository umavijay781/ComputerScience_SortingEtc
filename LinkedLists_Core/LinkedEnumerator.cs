using System;
//using System.Collections.Generic;
using System.Collections;
using System.Text;

//
// Added 3/2/2020 thomas downes 
//
namespace LinkedLists_Core
{
    public class LinkedEnumerator : IEnumerator
    {
        private LinkedList _list;
        private int _currentIndex = 0; 

        public LinkedEnumerator(LinkedList par_list)
        {
            _list = par_list;

        }

        public object Current
        {
            get
            {
                return _list[_currentIndex];
            }
        }

        public bool MoveNext()
        {
            _currentIndex++;
            if (_currentIndex > -1 + _list.Count()) return false;
            return true;
        }

        public void Reset()
        {
            _currentIndex = 0;
        }


    }
}
