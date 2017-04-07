using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntechCode.Tests
{
    [TestFixture]
    public class StreamTests
    {
        const string demoPath = @"C:\Intech\2017-1\S7-8\2017-1-IL-A4\FirstSolution\Tests\IntechCode.Tests\StreamTests.cs";
        const string outputPath = demoPath + ".bak";

        [Test]
        public void copying_a_stream()
        {
            using (FileStream input = new FileStream(demoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                CopyFromTo(input, output);
            }

        }

        static void CopyFromTo( Stream input, Stream output )
        {

        }
    }
}
