using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace KJFramework.ApplicationEngine.Helpers
{
    /// <summary>  
    /// 文件(夹)压缩、解压缩  
    /// </summary>  
    internal static class FileCompression
    {
        #region 压缩文件

        /// <summary>    
        ///     压缩文件    
        /// </summary>    
        /// <param name="fileNames">要打包的文件列表</param>    
        /// <param name="compressionLevel">压缩品质级别（0~9）</param>    
        /// <param name="deleteFile">是否删除原文件</param>  
        public static byte[] CompressFile(List<FileInfo> fileNames, int compressionLevel, bool deleteFile)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create))
            {
                foreach (FileInfo file in fileNames)
                {
                    archive.CreateEntryFromFile(file.FullName, Path.GetFileName(file.Name));
                    if (deleteFile) file.Delete();
                }
            }
            byte[] buffer = memoryStream.ToArray();
            return buffer;
        }

        /// <summary>    
        /// 获取所有文件    
        /// </summary>    
        /// <returns></returns>    
        private static Dictionary<string, DateTime> GetAllFies(string dir)
        {
            Dictionary<string, DateTime> FilesList = new Dictionary<string, DateTime>();
            DirectoryInfo fileDire = new DirectoryInfo(dir);
            if (!fileDire.Exists)
            {
                throw new FileNotFoundException("目录:" + fileDire.FullName + "没有找到!");
            }
            GetAllDirFiles(fileDire, FilesList);
            GetAllDirsFiles(fileDire.GetDirectories(), FilesList);
            return FilesList;
        }

        /// <summary>    
        /// 获取一个文件夹下的所有文件夹里的文件    
        /// </summary>    
        /// <param name="dirs"></param>    
        /// <param name="filesList"></param>    
        private static void GetAllDirsFiles(DirectoryInfo[] dirs, Dictionary<string, DateTime> filesList)
        {
            foreach (DirectoryInfo dir in dirs)
            {
                foreach (FileInfo file in dir.GetFiles("*.*"))
                {
                    filesList.Add(file.FullName, file.LastWriteTime);
                }
                GetAllDirsFiles(dir.GetDirectories(), filesList);
            }
        }

        /// <summary>    
        /// 获取一个文件夹下的文件    
        /// </summary>    
        /// <param name="dir">目录名称</param>    
        /// <param name="filesList">文件列表HastTable</param>    
        private static void GetAllDirFiles(DirectoryInfo dir, Dictionary<string, DateTime> filesList)
        {
            foreach (FileInfo file in dir.GetFiles("*.*"))
            {
                filesList.Add(file.FullName, file.LastWriteTime);
            }
        }

        #endregion

        #region 解压缩文件
        
        /// <summary>    
        /// 解压缩文件    
        /// </summary>    
        /// <param name="zippedData">已压缩的文件流</param>    
        /// <param name="targetPath">解压缩目标路径</param>           
        public static IDictionary<string, byte[]> Decompress(byte[] zippedData)
        {
            int size;
            IDictionary<string, byte[]> files = new Dictionary<string, byte[]>();
            using (MemoryStream stream = new MemoryStream(zippedData))
            using (ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {
                    using (MemoryStream fileRealStream = new MemoryStream())
                    using (Stream fileStream = entry.Open())
                    {
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = fileStream.Read(data, 0, data.Length);
                            if (size <= 0) break;
                            fileRealStream.Write(data, 0, size);
                        }
                        files.Add(entry.Name, fileRealStream.ToArray());
                    }
                }
            }
            return files;
        }

        #endregion
    }
}