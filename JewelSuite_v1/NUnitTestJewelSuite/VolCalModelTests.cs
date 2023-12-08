using System;
using System.Collections.Generic;
using System.Text;
using JewelSuite;
using NUnit.Framework;

namespace NUnitTestJewelSuite
{
    [TestFixture]
    public class VolCalModelTests
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public void CalculatedVolume_IsNotEmpty()
        {
            // Arrange
            VolCalModel _volCalModel = new VolCalModel();

            // Act
            double initialCounterValue =  _volCalModel.CalculatedVolume;

            // Assert
            Assert.IsNotEmpty(initialCounterValue.ToString());
        }
    }
}
