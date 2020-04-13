using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caspian_Cafe.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Caspian_Cafe.Validations;
using Caspian_Cafe.Models;

namespace Caspian_Cafe.Services.Tests
{
    [TestClass()]
    public class MenuServiceTests
    {
        private readonly ValidationResults validationResults = new ValidationResults();

        [TestMethod()]
        public void ProcessOrder_AllItems_Success()
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
        public void ProcessOrder_SingleItem_Success()
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
        public void ProcessOrder_MutipleDrinks_Success()
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
        public void ProcessOrder_MutipleFoodItems_Success()
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
        public void ProcessOrder_InvalidItem_Failure()
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
        public void ProcessOrder_InvalidItem2_Failure()
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
        public void ProcessOrder_EmptyOrder_Success()
        {
            // Arrange
            var order = new string[0];

            // Act
            var result = MenuService.ProcessOrder(order, validationResults);

            // Assert
            Assert.AreEqual(0.0M, result);
            Assert.IsFalse(validationResults.AnyErrorOrInvalid());
        }

        [TestMethod()]
        public void GetFoodServiceCharge_ValidValue_Success()
        {
            // Arrange
            var value = 10.00M;

            // Act
            var result = MenuService.GetFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(1.00M, result);
        }

        [TestMethod()]
        public void GetFoodServiceCharge_ValidValue2_Success()
        {
            // Arrange
            var value = 20.00M;

            // Act
            var result = MenuService.GetFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(2.00M, result);
        }

        [TestMethod()]
        public void GetFoodServiceCharge_NegativeValue_Success()
        {
            // Arrange
            var value = -10.00M;

            // Act
            var result = MenuService.GetFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(0.00M, result);
        }

        [TestMethod()]
        public void GetFoodServiceCharge_ZeroValue_Success()
        {
            // Arrange
            var value = 0.00M;

            // Act
            var result = MenuService.GetFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(0.00M, result);
        }

        [TestMethod()]
        public void GetHotFoodServiceCharge_ValidValue_Success()
        {
            // Arrange
            var value = 10.00M;

            // Act
            var result = MenuService.GetHotFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(2.00M, result);
        }

        [TestMethod()]
        public void GetHotFoodServiceCharge_ValidValue2_Success()
        {
            // Arrange
            var value = 20.00M;

            // Act
            var result = MenuService.GetHotFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(4.00M, result);
        }

        [TestMethod()]
        public void GetHotFoodServiceCharge_ValidValue3_Success()
        {
            // Arrange
            var value = 99.99M;

            // Act
            var result = MenuService.GetHotFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(20.00M, result);
        }

        [TestMethod()]
        public void GetHotFoodServiceCharge_ZeroValue_Success()
        {
            // Arrange
            var value = 0.00M;

            // Act
            var result = MenuService.GetHotFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(0.00M, result);
        }

        [TestMethod()]
        public void GetHotFoodServiceCharge_NegativeValue_Success()
        {
            // Arrange
            var value = -10.00M;

            // Act
            var result = MenuService.GetHotFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(0.00M, result);
        }

        [TestMethod()]
        public void GetHotFoodServiceCharge_TestLimitResultValue_Success()
        {
            // Arrange
            var value = 105.00M;

            // Act
            var result = MenuService.GetHotFoodServiceCharge(value);

            // Assert
            Assert.AreEqual(20.00M, result);
        }



        [TestMethod()]
        public void GetTotalWithServiceCharge_ValidValue_ServiceChargeNone_Success()
        {
            // Arrange
            var value = 10.00M;
            var serviceCharge = ServiceCharge.None;

            // Act
            var result = MenuService.GetTotalWithServiceCharge(value, serviceCharge);

            // Assert
            Assert.AreEqual(10.00M, result);
        }

        [TestMethod()]
        public void GetTotalWithServiceCharge_ValidValue_ServiceChargeFood_Success()
        {
            // Arrange
            var value = 10.00M;
            var serviceCharge = ServiceCharge.Food;

            // Act
            var result = MenuService.GetTotalWithServiceCharge(value, serviceCharge);

            // Assert
            Assert.AreEqual(11.00M, result);
        }

        [TestMethod()]
        public void GetTotalWithServiceCharge_ValidValue_ServiceChargeHotFood_Success()
        {
            // Arrange
            var value = 10.00M;
            var serviceCharge = ServiceCharge.HotFood;

            // Act
            var result = MenuService.GetTotalWithServiceCharge(value, serviceCharge);

            // Assert
            Assert.AreEqual(12.00M, result);
        }

        [TestMethod()]
        public void GetTotalWithServiceCharge_ZeroValue_ServiceChargeNone_Success()
        {
            // Arrange
            var value = 0.00M;
            var serviceCharge = ServiceCharge.None;

            // Act
            var result = MenuService.GetTotalWithServiceCharge(value, serviceCharge);

            // Assert
            Assert.AreEqual(0.00M, result);
        }

        [TestMethod()]
        public void GetTotalWithServiceCharge_ZeroValue_ServiceChargeFood_Success()
        {
            // Arrange
            var value = 0.00M;
            var serviceCharge = ServiceCharge.Food;

            // Act
            var result = MenuService.GetTotalWithServiceCharge(value, serviceCharge);

            // Assert
            Assert.AreEqual(0.00M, result);
        }

        [TestMethod()]
        public void GetTotalWithServiceCharge_ZeroValue_ServiceChargeHotFood_Success()
        {
            // Arrange
            var value = 0.00M;
            var serviceCharge = ServiceCharge.HotFood;

            // Act
            var result = MenuService.GetTotalWithServiceCharge(value, serviceCharge);

            // Assert
            Assert.AreEqual(0.00M, result);
        }

        [TestMethod()]
        public void GetItemServiceCharge_ColdDrink_Success()
        {
            // Arrange
            var menuitem = new MenuItem
            {
                ItemType = ItemType.Drink,
                Temperature = Temperature.Cold
            };

            // Act
            var result = MenuService.GetItemServiceCharge(menuitem);

            // Assert
            Assert.AreEqual(ServiceCharge.None, result);
        }

        [TestMethod()]
        public void GetItemServiceCharge_HotDrink_Success()
        {
            // Arrange
            var menuitem = new MenuItem
            {
                ItemType = ItemType.Drink,
                Temperature = Temperature.Hot
            };

            // Act
            var result = MenuService.GetItemServiceCharge(menuitem);

            // Assert
            Assert.AreEqual(ServiceCharge.None, result);
        }

        [TestMethod()]
        public void GetItemServiceCharge_ColdFood_Success()
        {
            // Arrange
            var menuitem = new MenuItem
            {
                ItemType = ItemType.Food,
                Temperature = Temperature.Cold
            };

            // Act
            var result = MenuService.GetItemServiceCharge(menuitem);

            // Assert
            Assert.AreEqual(ServiceCharge.Food, result);
        }

        [TestMethod()]
        public void GetItemServiceCharge_HotFood_Success()
        {
            // Arrange
            var menuitem = new MenuItem
            {
                ItemType = ItemType.Food,
                Temperature = Temperature.Hot
            };

            // Act
            var result = MenuService.GetItemServiceCharge(menuitem);

            // Assert
            Assert.AreEqual(ServiceCharge.HotFood, result);
        }
    }
}