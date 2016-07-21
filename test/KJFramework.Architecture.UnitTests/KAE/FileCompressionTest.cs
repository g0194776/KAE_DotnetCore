using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KJFramework.ApplicationEngine.Helpers;
using NUnit.Framework;

namespace KJFramework.Architecture.UnitTest.KAE
{
    [TestFixture]
    public class FileCompressionTest
    {
        #region Methods.

        [Test]
        public void CompressTest()
        {
            string tmpPath = PrepareTestFiles("res-files-compression-test");
            List<FileInfo> files = Directory.GetFiles(tmpPath).Select(f => new FileInfo(f)).ToList();
            byte[] data = FileCompression.CompressFile(files, 9, false);
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length > 0);
            Directory.Delete(tmpPath, true);
        }

        [Test]
        public void UnCompressTest()
        {
            string tmpPath = PrepareTestFiles("res-files-uncompression-test");
            List<FileInfo> files = Directory.GetFiles(tmpPath).Select(f => new FileInfo(f)).ToList();
            byte[] data = FileCompression.CompressFile(files, 9, false);
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length > 0);



            IDictionary<string, byte[]> decompressedFiles = FileCompression.Decompress(data);
            Assert.IsNotNull(decompressedFiles);
            Assert.IsTrue(decompressedFiles.Count == 2);
            Assert.IsTrue(decompressedFiles.ContainsKey("1.txt"));
            Assert.IsTrue(decompressedFiles.ContainsKey("2.txt"));
            Assert.IsTrue(decompressedFiles["1.txt"].Length == 1024);
            Assert.IsTrue(decompressedFiles["2.txt"].Length == 1024);

            Directory.Delete(tmpPath, true);
        }

        private string PrepareTestFiles(string subPath)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "KJFramework.Architecture.UnitTests", subPath);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!File.Exists(Path.Combine(path, "1.txt")))
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(Path.Combine(path, "1.txt"), FileMode.CreateNew), Encoding.UTF8))
                {
                    writer.Write(new string('*', 1024));
                    writer.Flush();
                }
            }
            if (!File.Exists(Path.Combine(path, "2.txt")))
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(Path.Combine(path, "2.txt"), FileMode.CreateNew), Encoding.UTF8))
                {
                    writer.Write(new string('*', 1024));
                    writer.Flush();
                }
            }
            return path;
        }

        #endregion
    }
}