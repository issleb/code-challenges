using System;
using System.Collections.Generic;
using System.Linq;
using MacGuffin.Business.Providers;
using NUnit.Framework;

namespace MacGuffin.Tests.Unit
{
    public class PhotoProviderTests : TestBase
    {
        private readonly string[] _filenames =
        {
            "Macguffin001.jpg",
            "macGuffin001-x-large-indigo.jpg",
            "macguffin002-Blue.jpg", 
            "macguffin003-Medium-orange.jpg",
            "MacGuffin005-Large.jpg"
        };

        private IPhotoProvider _photoProvider;

        [SetUp]
        public void SetUp()
        {
            _photoProvider = _autoMock.Create<PhotoProvider>();
        }


        #region GetPhotos

        [Test]
        public void CountTest()
        {
            var photos = _photoProvider.GetPhotos(_filenames);

            Assert.AreEqual(_filenames.Length, photos.Count);
        }

        [Test]
        public void ProductNameTest()
        {
            var photo = _photoProvider.GetPhotos(new[] { "MacGuffin001.jpg" })[0];

            Assert.AreEqual("MacGuffin001.jpg", photo.FileName);
            Assert.AreEqual("macguffin001", photo.ProductNumber);    
                      
            Assert.IsNull(photo.Size);
            Assert.IsNull(photo.Color);
        }

        [Test]
        public void SizeTest()
        {
            var photo = _photoProvider.GetPhotos(new[] { "MacGuffin001-Large.jpg" })[0];

            Assert.AreEqual("MacGuffin001-Large.jpg", photo.FileName);
            Assert.AreEqual("macguffin001", photo.ProductNumber);
            Assert.AreEqual("large", photo.Size.ToLower());
            
            Assert.IsNull(photo.Color);
        }

        [Test]
        public void SizeDashTest()
        {
            var photo = _photoProvider.GetPhotos(new[] { "MacGuffin001-X-Large.jpg" })[0];

            Assert.AreEqual("MacGuffin001-X-Large.jpg", photo.FileName);
            Assert.AreEqual("macguffin001", photo.ProductNumber);
            Assert.AreEqual("x-large", photo.Size.ToLower());

            Assert.IsNull(photo.Color);
        }

        [Test]
        public void SizeAndColorTest()
        {
            var photo = _photoProvider.GetPhotos(new[] { "MacGuffin001-Large-Blue.jpg" })[0];

            Assert.AreEqual("MacGuffin001-Large-Blue.jpg", photo.FileName);
            Assert.AreEqual("macguffin001", photo.ProductNumber);
            Assert.AreEqual("large", photo.Size.ToLower());
            Assert.AreEqual("blue", photo.Color);
        }

        #endregion
    }
}
