using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace AlgorithmsLearning.Tests
{
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> testNumbers = new List<int>
           {
                5,6,53,100,8,-2,66,-98,-2,1
           };

            Mock<IRandomGenerator> mockedRandomGenerator = new Mock<IRandomGenerator>();
            mockedRandomGenerator.Setup(visitor => visitor.Generate(10))
                .Returns(testNumbers);

            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor();
            Finder finder = new Finder(fileSystemVisitor, mockedRandomGenerator.Object);

            int findedValue = finder.FindMaxValue();

            Assert.AreEqual(100, findedValue);

            //    Console.WriteLine("Before");
            //    ShowCollection(randomCollection);

            //    for (int i = 0; i < randomCollection.Count; i++)
            //    {
            //        if (randomCollection[i] % 2 == 0)
            //        {
            //            randomCollection.RemoveAt(i);
            //            i--;
            //        }
            //    }

            //    Console.WriteLine("After");
            //    ShowCollection(randomCollection);

            //
        }
        private void ShowCollection(List<int> randomCollection)
        {
            foreach (int currentValue in randomCollection)
            {
                Console.WriteLine(currentValue);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi ex diam, elementum eget porta ut, rutrum id est.";
            int i = 1;
            foreach (char symbol in text)
            {
                if (' ' == symbol)
                {
                    i++;
                }
            }
            Assert.AreEqual(31, i);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string text = "  Lorem ipsum dolor sit amet   ";

            string trimmedText = TrimSpace(text);

            Assert.AreEqual("Lorem ipsum dolor sit amet", trimmedText);
        }
        public string TrimSpace(string text)
        {
            StringBuilder textInCollection = new StringBuilder(text);

            while (char.IsWhiteSpace(textInCollection[0]))
            {
                textInCollection.Remove(0, 1);
            }

            while (char.IsWhiteSpace(textInCollection[textInCollection.Length - 1]))
            {
                textInCollection.Remove(textInCollection.Length - 1, 1);
            }

            return textInCollection.ToString();
        }
        [TestMethod]
        public void TestMethod4()
        {
            string text = "Lorem ipsum dolor sit amet";

            string reversedText = Reverse(text);

            Assert.AreEqual("tema tis rolod muspi meroL", reversedText);
        }

        public string Reverse(string text)
        {
            StringBuilder emptyForReverse = new StringBuilder();
            int length = text.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                char symbol = text[i];
                emptyForReverse.Append(symbol);
            }
            return emptyForReverse.ToString();
        }
        [TestMethod]
        public void TestMethod5()
        {
            string word = " love";
            int position = 5;
            string text = "Lorem ipsum dolor sit amet";

            string insertedText = Insert(text, word, position);

            Assert.AreEqual("Lorem love ipsum dolor sit amet", insertedText);
        }

        public string Insert(string text, string word, int position)
        {
            if (position < 0 || position > text.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            StringBuilder emptyForInsert = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (i != position)
                {
                    emptyForInsert.Append(text[i]);
                }
                else
                {
                    emptyForInsert.Append(word);
                    emptyForInsert.Append(text[i]);
                }
            }
            return emptyForInsert.ToString();
        }
        [TestMethod]
        public void TestMethod6()
        {
            MyCollectionWithBuildInEnumerator myCollection = new MyCollectionWithBuildInEnumerator();
            foreach (int item in myCollection)
            {
                Console.WriteLine(item);
            }
        }
        [TestMethod]
        public void TestMethod7()
        {
            MyCollectionWithCustomEnumerator myCollection = new MyCollectionWithCustomEnumerator(100);
            foreach (int item in myCollection)
            {
                Console.WriteLine(item);
            }
        }
        [TestMethod]
        public void TestMethod8()
        {
            string[] testFileNames = new string[]
            {
                "testFileName1",
                "testFileName2",
                "testFileName3",
                "testFileName4"
            };

            Mock<IFileSystemVisitor> mockedFileSystemVisitor = new Mock<IFileSystemVisitor>();
            mockedFileSystemVisitor.Setup(visitor => visitor.GetCurrentDirectoryFileNames())
                .Returns(testFileNames);

            RandomGenerator randomGenerator = new RandomGenerator();
            Finder finder = new Finder(mockedFileSystemVisitor.Object, randomGenerator);

            bool isFinded = finder.Find("testFileName3");


            Assert.AreEqual(true, isFinded);
            //string[] fileNames = fileSystemVisitor.GetCurrentDirectoryFileNames();
            //foreach (string name in fileNames)
            //{
            //    Console.WriteLine(name);
            //}
        }
        [TestMethod]
        public void TestMethod9()
        {
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing sit amet, amet consectetur elit.";
            List<string> splittedWords = SplitTextByWords(text);
            Dictionary<string,int> countedWords = CountWords(splittedWords);
            foreach (KeyValuePair<string,int> item in countedWords)
            {
                Console.WriteLine($"Word is {item.Key}. Repetitions are {item.Value}");
            }

            Assert.AreEqual(12, splittedWords.Count);
            Assert.AreEqual(3,countedWords["amet"]);
            Assert.AreEqual(1, countedWords["Lorem"]);
            Assert.AreEqual(2, countedWords["sit"]);
        }
        private List<string> SplitTextByWords(string text)
        {
            List<string> splittedWords = new List<string>();
            StringBuilder tempreraryString = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]) || i == text.Length - 1)
                {
                    if (i == text.Length - 1 && char.IsPunctuation(text[i]) == false)
                    {
                        tempreraryString.Append(text[i]);
                    }
                    splittedWords.Add(tempreraryString.ToString());
                    tempreraryString.Clear();
                }
                else
                {
                    if (char.IsPunctuation(text[i]) == false)
                    {
                        tempreraryString.Append(text[i]);
                    }
                }
            }
            return splittedWords;
        }
        private Dictionary<string, int> CountWords(List<string> splittedWords)
        {
            Dictionary<string, int> countedWords = new Dictionary<string, int>();
            foreach (string word in splittedWords)
            {
                if (countedWords.ContainsKey(word))
                {
                    countedWords[word] = countedWords[word] + 1;
                }
                else
                {
                    countedWords.Add(word, 1);
                }
            }
            return countedWords;
        }
    }
}

