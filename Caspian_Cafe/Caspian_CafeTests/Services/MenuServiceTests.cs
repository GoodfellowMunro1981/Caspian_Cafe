using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caspian_Cafe.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Caspian_Cafe.Validations;

namespace Caspian_Cafe.Services.Tests
{
    [TestClass()]
    public class MenuServiceTests
    {
        private readonly ValidationResults validationResults = new ValidationResults();

        [TestMethod()]
        public void ProcessOrderTest_AllItems_Success()
        {
            // Arrange
            var order = new[] { "Cola", "Coffee", "Cheese Sandwich", "Steak Sandwich" };

            // Act
            var result = MenuService.ProcessOrder(order, validationResults);

            // Assert
            Assert.AreEqual(9.60M, result);
            Assert.IsFalse(validationResults.AnyErrorOrInvalid());
        }

        [TestMethod()]
        public void ProcessOrderTest_SingleItem_Success()
        {
            // Arrange
            var order = new[] { "Cola" };

            // Act
            var result = MenuService.ProcessOrder(order, validationResults);

            // Assert
            Assert.AreEqual(0.50M, result);
            Assert.IsFalse(validationResults.AnyErrorOrInvalid());
        }

        [TestMethod()]
        public void ProcessOrderTest_MutipleDrinks_Success()
        {
            // Arrange
            var order = new[] { "Cola", "Coffee" };

            // Act
            var result = MenuService.ProcessOrder(order, validationResults);

            // Assert
            Assert.AreEqual(1.50M, result);
            Assert.IsFalse(validationResults.AnyErrorOrInvalid());
        }

        [TestMethod()]
        public void ProcessOrderTest_MutipleFoodItems_Success()
        {
            // Arrange
            var order = new[] { "Cheese Sandwich", "Steak Sandwich" };

            // Act
            var result = MenuService.ProcessOrder(order, validationResults);

            // Assert
            Assert.AreEqual(7.80M, result);
            Assert.IsFalse(validationResults.AnyErrorOrInvalid());
        }

        [TestMethod()]
        public void ProcessOrderTest_InvalidItem_Failure()
        {
            // Arrange
            var order = new[] { "Cola", "" };

            // Act
            var result = MenuService.ProcessOrder(order, validationResults);

            // Assert
            Assert.AreEqual(0.0M, result);
            Assert.IsTrue(validationResults.AnyErrorOrInvalid());
        }

        [TestMethod()]
        public void ProcessOrderTest_InvalidItem2_Failure()
        {
            // Arrange
            var order = new[] { "cola", "" };

            // Act
            var result = MenuService.ProcessOrder(order, validationResults);

            // Assert
            Assert.AreEqual(0.0M, result);
            Assert.IsTrue(validationResults.AnyErrorOrInvalid());
        }

        [TestMethod()]
        public void ProcessOrderTest_EmptyOrder_Success()
        {
            // Arrange
            var order = new string[0];

            // Act
            var result = MenuService.ProcessOrder(order, validationResults);

            // Assert
            Assert.AreEqual(0.0M, result);
            Assert.IsFalse(validationResults.AnyErrorOrInvalid());
        }
    }
}