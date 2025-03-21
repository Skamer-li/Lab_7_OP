using System.Collections;
using System.Collections.Generic;

namespace linked_list
{
    public class ListEnumerator : IEnumerator<float>
    {
        private LinkedListMod _list;
        private int _index;

        public ListEnumerator(LinkedListMod list)
        {
            _list = list;
            _index = -1;
        }
        public float Current => _list[_index];

        object IEnumerator.Current => _list[_index];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _index++;

            if (!_list.isEmpty() && _index < _list.Count()) 
                return true;
            else
                return false;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
