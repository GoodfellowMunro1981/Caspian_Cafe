using System;
using System.Collections.Generic;
using System.Linq;
using Caspian_Cafe.Data;
using Caspian_Cafe.Models;
using Caspian_Cafe.Validations;

namespace Caspian_Cafe.Services
{
    public static class MenuService
    {
        public static decimal ProcessOrder(IEnumerable<string> order, ValidationResults validationResults)
        {
            var menu =  MenuData.GetMenu();
            var totalCost = 0.0M;
            var serviceCharge = ServiceCharge.None;

            foreach (var item in order)
            {
                if (!string.IsNullOrEmpty(item) && menu.Items.Any(x => x.Name == item))
                {
                    var menuItem = menu.Items
                                    .Where(x => x.Name == item)
                                    .FirstOrDefault();

                    totalCost += menuItem.Cost;

                    var itemServiceCharge = GetItemServiceCharge(menuItem);

                    if (itemServiceCharge > serviceCharge)
                    {
                        serviceCharge = itemServiceCharge;
                    }
                }
                else
                {
                    AddInvalidItemMessage(item, validationResults);
                }
            }

            return !validationResults.AnyErrorOrInvalid()
                    ? GetTotalWithServiceCharge(totalCost, serviceCharge)
                    : 0.0M;
        }

        public static ServiceCharge GetItemServiceCharge(MenuItem menuItem)
        {
            if (menuItem.ItemType == ItemType.Food)
            {
                if (menuItem.Temperature == Temperature.Hot)
                {
                    return ServiceCharge.HotFood;
                }

                return ServiceCharge.Food;
            }

            return ServiceCharge.None;
        }

        public static decimal GetTotalWithServiceCharge(decimal value, ServiceCharge serviceCharge)
        {
            return serviceCharge switch
            {
                ServiceCharge.Food => value + GetFoodServiceCharge(value),
                ServiceCharge.HotFood => value + GetHotFoodServiceCharge(value),
                _ => value,
            };
        }

        public static decimal GetFoodServiceCharge(decimal value)
        {
            var charge = (value / 100) * 10;

            return charge < 0
                ? 0.00M
                : Math.Round(charge, 2);
        }

        public static decimal GetHotFoodServiceCharge(decimal value)
        {
            var charge = (value / 100) * 20;

            if (charge >= 0 && charge <= 20.00M)
            {
                return Math.Round(charge, 2);
            }

            return charge < 0
                    ? 0.00M
                    : 20.00M;
        }

        #region Private Helpers
        private static void AddInvalidItemMessage(string item, ValidationResults validationResults)

        {
            var message = string.Format("Order item is not valid '{0}'", item);
            validationResults.AddValidation(ValidationSeverity.Error, message);
        }
        #endregion
    }
}