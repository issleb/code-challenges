using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.Moq;
using NUnit.Framework;

namespace MacGuffin.Tests.Unit
{
    public class TestBase
    {
        protected AutoMock _autoMock;

        [SetUp]
        public void SetUpBase()
        {
            _autoMock = AutoMock.GetLoose();
        }
    }
}
