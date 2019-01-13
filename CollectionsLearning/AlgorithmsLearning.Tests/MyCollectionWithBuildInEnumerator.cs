using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsLearning.Tests
{
    public class MyCollectionWithBuildInEnumerator : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return 5;
            yield return 111;
            yield return 16;
            yield return -50;
            yield return 69;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
