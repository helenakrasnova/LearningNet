using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning.Tests
{
    public interface IFileSystemVisitor
    {
        string[] GetCurrentDirectoryFileNames();
    }
}
