using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntechCode;
using System.Runtime.CompilerServices;

namespace IntechCode.Tests
{
    [TestFixture]
    public class StreamTests
    {
        static string GetThisFilePath([CallerFilePath]string path = null) => path;

        static readonly string demoPath = GetThisFilePath();
        static readonly string outputPath = demoPath + ".bak";

        [Test]
        public void copying_a_stream()
        {
            using (FileStream input = new FileStream(demoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                CopyFromTo(input, output);
            }
            File.ReadAllBytes(demoPath).ShouldBeEquivalentTo(File.ReadAllBytes(outputPath));
        }

        [Test]
        public void krabouille_and_unkrabouille()
        {
            // demoPath => demoPath+".crypt" => demoPath+".clear"
            string inputPath = demoPath;
            string cryptPath = demoPath + ".crypt";
            string clearPath = demoPath + ".clear";

            // 1 - Writing cryptPath file.
            using (Stream input = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream output = new FileStream(cryptPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            using (Stream outputK = new KrabouilleStream(output, "pwd!", KrabouilleMode.Krabouille))
            {
                //CopyFromTo(input, outputK);
                // (or using the standard method:)
                input.CopyTo(outputK, 4 * 1024);
            }
            File.ReadAllBytes(inputPath).Should().NotEqual(File.ReadAllBytes(cryptPath), ".crypt has been Krabouilled." );

            // 2 - Writing clearPath file (from cryptPath).
            using (Stream input = new FileStream(cryptPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream inputUK = new KrabouilleStream(input, "pwd!", KrabouilleMode.UnKrabouille))
            using (Stream output = new FileStream(clearPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                inputUK.CopyTo(output, 4 * 1024);
            }

            File.ReadAllBytes(inputPath).Should().Equal(File.ReadAllBytes(clearPath), ".crypt has been decrypted." );
        }

        static void CopyFromTo( Stream input, Stream output, byte[] buffer = null )
        {
            if (input == null || !input.CanRead) throw new ArgumentException("Must be readable.", nameof(input));
            if (output == null || !output.CanWrite) throw new ArgumentException("Must be writable.", nameof(output));
            if (buffer == null) buffer = new byte[4 * 1024];

            int lenRead;
            do
            {
                lenRead = input.Read(buffer, 0, buffer.Length);
                output.Write(buffer, 0, lenRead);
            }
            while(lenRead == buffer.Length);
        }
    }
}
