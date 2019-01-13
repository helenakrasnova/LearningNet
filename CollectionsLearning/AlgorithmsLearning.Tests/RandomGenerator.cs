using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning.Tests
{
    public class RandomGenerator :IRandomGenerator
    {
        Random random = new Random();
        public List<int> Generate(int maxNumber)
        {
            List<int> randomCollection = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                int randomNumber = random.Next(1, 100);
                randomCollection.Add(randomNumber);
            }
            return randomCollection;
        }
    }
}
