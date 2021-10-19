using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace TodoApp.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Failing()
        {
            throw new Exception("Test fehlgeschlagen");
        }

        [TestMethod]
        public void SuccessfulTest()
        {
            
        }

        [TestMethod]
        public void OnePlusOneIsTwo()
        {
            // Arrange
            var number1 = 1;
            var number2 = 1;
            // Act
            var result = number1 + number2;
            // Assert
            result.ShouldBe(2);
        }
    }
}
