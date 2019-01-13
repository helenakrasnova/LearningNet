using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning.Tests
{
    public class Finder
    {
        private IFileSystemVisitor _visitor;
        private IRandomGenerator _randomGenerator;
        public Finder(IFileSystemVisitor visitor, IRandomGenerator randomGenerator)
        {
            _visitor = visitor;
            _randomGenerator = randomGenerator;
        }
        public bool Find(string fileName)
        {
            string[] fileNames = _visitor.GetCurrentDirectoryFileNames();
            for (int i = 0; i < fileNames.Length; i++)
            {
                if (fileNames[i] == fileName)
                {
                    return true;
                }
            }
            return false;
        }
        public int FindMaxValue()
        {
            List<int> randomCollection = _randomGenerator.Generate(10);
            int maxNumber = randomCollection[0];
            for (int i = 0; i < randomCollection.Count; i++)
            {
                if (randomCollection[i] > maxNumber)
                {
                    maxNumber = randomCollection[i];
                }
            }
            return maxNumber;
        }
    }
}
