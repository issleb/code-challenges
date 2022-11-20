using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac.Extras.Moq;
using NUnit.Framework;

namespace MacGuffin.Tests.Integration
{
    public class TestBase
    {
        protected AutoMock _autoMock { get; set; }

        protected string TestFolder
        {
            get
            {
                string path = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));

                return path;
            }
        }

        [SetUp]
        public void SetUpBase()
        {
            _autoMock = AutoMock.GetLoose();
        }
    }
}
