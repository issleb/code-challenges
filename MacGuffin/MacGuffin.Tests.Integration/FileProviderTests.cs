using System;
using System.IO;
using System.Linq;
using MacGuffin.Business.Providers;
using NUnit.Framework;

namespace MacGuffin.Tests.Integration
{
    public class FileProviderTests : TestBase
    {
        private readonly string[] _filenames =
        {
            "Macguffin001.jpg",
            "macguffin002-Blue.jpg",
            "MacGuffin002-Orange.jpg",
            "Macguffin003-medium-Violet.jpg",
            "MacGuffin003-X-Small-Red.jpg"
        };

        private FileProvider _fileProvider;

        [SetUp]
        public void SetUp()
        {
            _fileProvider = _autoMock.Create<FileProvider>();
        }

        [Test]
        public void GetFileNamesTest()
        {
            var folderPath = Path.Combine(TestFolder, "Content", "Photos");
            var filesNames = _fileProvider.GetFileNames(folderPath);

            Assert.AreEqual(5, filesNames.Count);
            Assert.AreEqual("macguffin002-Blue.jpg", filesNames[1]);
        }

        [Test]
        public void CopyToFolderTest()
        {
            var tempFolder = CreateTempFolder();
            var filePath = Path.Combine(TestFolder, "Content", "Photos", _filenames[0]);

            _fileProvider.CopyToFolder(filePath, tempFolder);

            var file = new DirectoryInfo(tempFolder).GetFiles().Single();

            Assert.AreEqual(_filenames[0], file.Name);
        }


        private static string CreateTempFolder()
        {
            string tempFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempFolder);
            return tempFolder;
        }
    }
}
