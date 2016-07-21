using System;
using System.Globalization;
using System.IO;
using System.Text;
using KJFramework.ApplicationEngine.Resources;
using KJFramework.ApplicationEngine.Resources.Packs;
using KJFramework.ApplicationEngine.Resources.Packs.Sections;
using NUnit.Framework;

namespace KJFramework.Architecture.UnitTest.KAE
{
    [TestFixture]
    public class KPPResourceTest
    {
        #region Methods.

        [Test]
        public void PackTest()
        {
            DateTime now = DateTime.Now;
            string fileName = DateTime.Now.Ticks + ".kpp";
            Guid guid = Guid.NewGuid();
            KPPDataHead head = new KPPDataHead();
            PackageAttributeDataSection section = new PackageAttributeDataSection();
            section.SetField("PackName", "test.package");
            section.SetField("PackDescription", "test package description.");
            section.SetField("EnvironmentFlag", (byte)0x01);
            section.SetField("Version", "1.0.0");
            section.SetField("PackTime", now);
            section.SetField("ApplicationMainFileName", "1.txt");
            section.SetField("GlobalUniqueIdentity", guid);
            string tmpPath = PrepareTestFiles("res-files");
            KPPResource.Pack(tmpPath, fileName, head, true, section);
            Assert.IsTrue(File.Exists(fileName));
            File.Delete(fileName);
            Directory.Delete(tmpPath, true);
        }

        private string  PrepareTestFiles(string subPath)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "KJFramework.Architecture.UnitTests", subPath);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if(!File.Exists(Path.Combine(path, "1.txt")))
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

        [Test]
        public void PackTestWithoutDelete()
        {
            DateTime now = DateTime.Now;
            string fileName = DateTime.Now.Ticks + ".kpp";
            Guid guid = Guid.NewGuid();
            KPPDataHead head = new KPPDataHead();
            PackageAttributeDataSection section = new PackageAttributeDataSection();
            section.SetField("PackName", "test.package");
            section.SetField("PackDescription", "test package description.");
            section.SetField("EnvironmentFlag", (byte)0x01);
            section.SetField("Version", "2.0.0");
            section.SetField("PackTime", now);
            section.SetField("ApplicationMainFileName", "KJFramework.ApplicationEngine.ApplicationTest.dll");
            section.SetField("GlobalUniqueIdentity", guid);
            section.SetField("IsCompletedEnvironment", false);
            string tmpPath = PrepareTestFiles("res-files");
            KPPResource.Pack(tmpPath, fileName, head, false, section);
            Assert.IsTrue(File.Exists(fileName));
            Directory.Delete(tmpPath, true);
        }

        [Test]
        public void PackNonCompletedEnvironmentTestWithoutDelete()
        {
            DateTime now = DateTime.Now;
            string fileName = DateTime.Now.Ticks + ".kpp";
            Guid guid = Guid.NewGuid();
            KPPDataHead head = new KPPDataHead();
            PackageAttributeDataSection section = new PackageAttributeDataSection();
            section.SetField("PackName", "test.package");
            section.SetField("PackDescription", "test package description.");
            section.SetField("EnvironmentFlag", (byte)0x01);
            section.SetField("Version", "1.0.0");
            section.SetField("PackTime", now);
            section.SetField("ApplicationMainFileName", "KJFramework.ApplicationEngine.ApplicationTest.dll");
            section.SetField("GlobalUniqueIdentity", guid);
            section.SetField("IsCompletedEnvironment", false);
            string tmpPath = PrepareTestFiles("res-files");
            KPPResource.Pack(tmpPath, fileName, head, false, section);
            Assert.IsTrue(File.Exists(fileName));
            Directory.Delete(tmpPath, true);
        }

        [Test]
        public void UnPackTest()
        {
            DateTime now = DateTime.Now;
            string fileName = DateTime.Now.Ticks + ".kpp";
            Guid guid = Guid.NewGuid();
            KPPDataHead head = new KPPDataHead();
            PackageAttributeDataSection section = new PackageAttributeDataSection();
            section.SetField("PackName", "test.package");
            section.SetField("PackDescription", "test package description.");
            section.SetField("EnvironmentFlag", (byte)0x01);
            section.SetField("Version", "1.0.0");
            section.SetField("PackTime", now);
            section.SetField("ApplicationMainFileName", "1.txt");
            section.SetField("GlobalUniqueIdentity", guid);
            string tmpPath = PrepareTestFiles("res-files");
            KPPResource.Pack(tmpPath, fileName, head, true, section);
            Assert.IsTrue(File.Exists(fileName));

            KPPDataStructure structure = KPPResource.UnPack(fileName);
            Assert.IsTrue(structure.GetSectionField<string>(0x00 , "PackName") == "test.package");
            Assert.IsTrue(structure.GetSectionField<string>(0x00 , "PackDescription") == "test package description.");
            Assert.IsTrue(structure.GetSectionField<string>(0x00 , "Version") == "1.0.0");
            Assert.IsTrue(structure.GetSectionField<string>(0x00 , "ApplicationMainFileName") == "1.txt");
            Assert.IsTrue(structure.GetSectionField<DateTime>(0x00 , "PackTime") == now);
            Assert.IsTrue(structure.GetSectionField<byte>(0x00 , "EnvironmentFlag") == 0x01);
            Assert.IsTrue(structure.GetSectionField<Guid>(0x00 , "GlobalUniqueIdentity") == guid);
            Assert.IsNotNull(structure);


            File.Delete(fileName);
            Directory.Delete(tmpPath, true);
        }

        #endregion
    }
}