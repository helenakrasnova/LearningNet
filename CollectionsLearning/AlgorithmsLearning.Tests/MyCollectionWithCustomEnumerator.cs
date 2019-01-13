using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning.Tests
{
    public class MyCollectionWithCustomEnumerator : IEnumerable<int>
    {
        private int _maxValue;
        public MyCollectionWithCustomEnumerator(int maxValue)
        {
            _maxValue = maxValue;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator(_maxValue);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(_maxValue);
        }
    }
    public class MyEnumerator : IEnumerator<int>
    {
        private int _current;
        private readonly int _maxValue;
        public MyEnumerator(int maxValue)
        {
            _maxValue = maxValue;
            _current = 0;
        }
        public int Current
        {
            get
            {
                return _current;
            }
        }

        object IEnumerator.Current => _current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current < _maxValue)
            {
                _current = _current + 2;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}
