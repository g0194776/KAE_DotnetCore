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
            char[] content1 = new string('*', 1024).ToCharArray();
            content1[0] = 'z';
            content1[content1.Length - 1] = 'z';


            char[] content2 = new string('*', 1024).ToCharArray();
            content2[0] = 'y';
            content2[content2.Length - 1] = 'y';


            Assert.IsTrue(Encoding.UTF8.GetString(decompressedFiles["1.txt"]) == new string(content1));
            Assert.IsTrue(Encoding.UTF8.GetString(decompressedFiles["2.txt"]) == new string(content2));

            Directory.Delete(tmpPath, true);
        }

        private string PrepareTestFiles(string subPath)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "KJFramework.Architecture.UnitTests", subPath);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!File.Exists(Path.Combine(path, "1.txt")))
            {
                using (FileStream writer = new FileStream(Path.Combine(path, "1.txt"), FileMode.CreateNew))
                {
                    char[] content = new string('*', 1024).ToCharArray();
                    content[0] = 'z';
                    content[content.Length - 1] = 'z';
                    string tmpStr = new string(content);
                    byte[] tmpData = Encoding.UTF8.GetBytes(tmpStr);
                    writer.Write(tmpData, 0, tmpData.Length);
                    writer.Flush();
                }
            }
            if (!File.Exists(Path.Combine(path, "2.txt")))
            {
                using (FileStream writer = new FileStream(Path.Combine(path, "2.txt"), FileMode.CreateNew))
                {
                    char[] content = new string('*', 1024).ToCharArray();
                    content[0] = 'y';
                    content[content.Length - 1] = 'y';
                    string tmpStr = new string(content);
                    byte[] tmpData = Encoding.UTF8.GetBytes(tmpStr);
                    writer.Write(tmpData, 0, tmpData.Length);
                    writer.Flush();
                }
            }
            return path;
        }

        #endregion
    }
}