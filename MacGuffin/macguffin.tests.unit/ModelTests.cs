using System;
using System.Collections.Generic;
using System.Linq;
using MacGuffin.Models;
using NUnit.Framework;

namespace MacGuffin.Tests.Unit
{
    public class ModelTests : TestBase
    {
        [Test]
        public void ProductNameTest()
        {
            var photo = new Photo()
            {
                ProductNumber = "MacGuffin001"
            };

            Assert.AreEqual("MacGuffin001", photo.FullName);
            Assert.AreEqual(String.Empty,   photo.SizeName);
            Assert.AreEqual(String.Empty,   photo.ColorName);
        }

        [Test]
        public void SizeTest()
        {
            var photo = new Photo()
            {
                ProductNumber = "MacGuffin001",
                Size = "Large"
            };

            Assert.AreEqual("MacGuffin001-Large", photo.FullName);
            Assert.AreEqual("MacGuffin001-Large", photo.SizeName);
            Assert.AreEqual(String.Empty,         photo.ColorName);
        }

        [Test]
        public void ColorTest()
        {
            var photo = new Photo()
            {
                ProductNumber = "MacGuffin001",
                Color = "Blue"
            };

            Assert.AreEqual("MacGuffin001-Blue", photo.FullName);
            Assert.AreEqual("MacGuffin001-Blue", photo.ColorName);
            Assert.AreEqual(String.Empty,        photo.SizeName);
        }

        [Test]
        public void SizeAndColorTest()
        {
            var photo = new Photo()
            {
                ProductNumber = "MacGuffin001",
                Size = "Large",
                Color = "Blue"
            };

            Assert.AreEqual("MacGuffin001-Large-Blue", photo.FullName);
            Assert.AreEqual("MacGuffin001-Large",      photo.SizeName);
            Assert.AreEqual("MacGuffin001-Blue",       photo.ColorName);
        }

    }
}
