using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace MacGuffin.Business.Providers
{
    public interface IFileProvider
    {
        List<string> GetFileNames(string path);
        List<string> GetFolderNames(string path);
        void CopyToFolder(string filePath, string folderPath);
        string CreateZip(string folderPath, string zipFilePath);
        void RestoreFolderFromZip(string folderPath, string zipFilePath);
        void DeleteFile(string filePath);
    }

    public class FileProvider : IFileProvider
    {
        public List<string> GetFileNames(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var fileNames = directoryInfo.GetFiles().Select(x => x.Name).ToList();

            return fileNames;
        }

        public List<string> GetFolderNames(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var folderNames = directoryInfo.GetDirectories().Select(x => x.Name).ToList();

            return folderNames;
        }

        public void CopyToFolder(string filePath, string folderPath)
        {
            var fileName = Path.GetFileName(filePath);
            var newFilePath = Path.Combine(folderPath, fileName);

            File.Copy(filePath, newFilePath, true);
        }

        public string CreateZip(string folderPath, string zipFileName)
        {
            string tempFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempFolder);
            var zipFilePath = Path.Combine(tempFolder, zipFileName);

            ZipFile.CreateFromDirectory(folderPath, zipFilePath);

            return zipFilePath;
        }

        public void RestoreFolderFromZip(string folderPath, string zipFilePath)
        {
            var directoryInfo = new DirectoryInfo(folderPath);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                directory.Delete(true);
            }
            foreach (var file in directoryInfo.GetFiles())
            {
                file.Delete();
            }


            ZipFile.ExtractToDirectory(zipFilePath, folderPath);
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}
