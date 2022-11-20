using System;
using System.Collections.Generic;
using System.Linq;
using MacGuffin.Business;
using MacGuffin.Business.Providers;
using MacGuffin.Models;
using Moq;
using NUnit.Framework;

namespace MacGuffin.Tests.Unit
{
    public class PhotoSorterTests : TestBase
    {
        private readonly string[] _categories =
        {
            "Macguffin001",
            "macGuffin001-x-large-indigo",
            "macguffin002-Blue", 
            "macguffin003-Medium",
            "MacGuffin005-Large",
            "Macguffin006-Large",
            "MacGuffin006-orange",
        };

        private Mock<IFileProvider> _fileProvider;
        private Mock<IPhotoProvider> _photoProvider;
        private string _categoryName;

        [SetUp]
        public void SetUp()
        {
            _fileProvider = _autoMock.Mock<IFileProvider>();
            _photoProvider = _autoMock.Mock<IPhotoProvider>();

            _fileProvider.Setup(x => x.GetFolderNames(It.IsAny<string>())).Returns(_categories.ToList());

            _fileProvider.Setup(x => x.CopyToFolder(It.IsAny<string>(), It.IsAny<string>())).Callback<string, string>((x, y) =>
            {
                _categoryName = y;
            });
        }

        [Test]
        public void ProductNameTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin001"                   
                }
            });
            
            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("Macguffin001", _categoryName);
        }

        [Test]
        public void SizeTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin005",
                    Size = "large",
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("MacGuffin005-Large", _categoryName);
        }

        [Test]
        public void ColorTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin002",
                    Color = "blue",
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("macguffin002-Blue", _categoryName);
        }

        [Test]
        public void SizeAndColorTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin001",
                    Size = "x-large",
                    Color = "indigo"
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("macGuffin001-x-large-indigo", _categoryName);
        }

        [Test]
        public void SizeNoSizeTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin001",
                    Size = "medium",
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("Macguffin001", _categoryName);
        }

        [Test]
        public void ColorNoColorTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin001",
                    Color = "orange",
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("Macguffin001", _categoryName);
        }

        [Test]
        public void SizeAndColorNoneTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin001",
                    Size = "x-large",
                    Color = "indigo"
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("macGuffin001-x-large-indigo", _categoryName);
        }

        [Test]
        public void SizeAndColorNoSizeTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin002",
                    Size = "medium",
                    Color = "blue",
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("macguffin002-Blue", _categoryName);
        }

        [Test]
        public void SizeAndColorNoColorTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin003",
                    Size = "medium",
                    Color = "blue",
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("macguffin003-Medium", _categoryName);
        }

        [Test]
        public void SizeAndColorBothTest()
        {
            _photoProvider.Setup(x => x.GetPhotos(It.IsAny<List<string>>())).Returns(new List<Photo>()
            {
                new Photo()
                {
                    FileName = "",
                    ProductNumber = "macguffin006",
                    Size = "large",
                    Color = "orange",
                }
            });

            var photoSorter = _autoMock.Create<PhotoSorter>();
            photoSorter.SortPhotos("", "");

            Assert.AreEqual("Macguffin006-Large", _categoryName);
        }
    }
}
