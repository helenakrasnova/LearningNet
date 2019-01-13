using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning.Tests
{
    public class FileSystemVisitor : IFileSystemVisitor
    {
        public string[] GetCurrentDirectoryFileNames()
        {
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            string[] currentDirectoryFiles = Directory.GetFiles(currentDirectoryPath)
                                                .Select(f => Path.GetFileName(f)).ToArray();
            return currentDirectoryFiles;
        }
    }
}
