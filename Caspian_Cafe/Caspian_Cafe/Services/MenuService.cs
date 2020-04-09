using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caspian_Cafe.Models;
using Caspian_Cafe.Validations;

namespace Caspian_Cafe.Services
{
    public static class MenuService
    {
        public static Menu GetMenu()
        {
            var menu = new Menu
            {
                Items = new List<MenuItem>()
                {
                    new MenuItem
                    {
                        Name = "Cola",
                        Cost = 0.50M,
                        Temperature = Temperature.Cold,
                        ItemType = ItemType.Drink
                    },
                    new MenuItem
                    {
                        Name = "Coffee",
                        Cost = 1.00M,
                        Temperature = Temperature.Hot,
                        ItemType = ItemType.Drink
                    },
                    new MenuItem
                    {
                        Name = "Cheese Sandwich",
                        Cost = 2.00M,
                        Temperature = Temperature.Cold,
                        ItemType = ItemType.Food
                    },
                    new MenuItem
                    {
                        Name = "Steak Sandwich",
                        Cost = 4.50M,
                        Temperature = Temperature.Hot,
                        ItemType = ItemType.Food
                    }
                }
            };

            return menu;
        }

        public static decimal ProcessOrder(IEnumerable<string> order, ValidationResults validationResults)
        {
            var menu = GetMenu();
            var totalCost = 0.0M;
            var foodIncluded = false;
            var hotFoodIncluded = false;

            foreach (var item in order)
            {
                if (!string.IsNullOrEmpty(item) && menu.Items.Any(x => x.Name == item))
                {
                    var menuItem = menu.Items
                                    .Where(x => x.Name == item)
                                    .FirstOrDefault();

                    totalCost += menuItem.Cost;

                    if(menuItem.ItemType == ItemType.Food)
                    {
                        foodIncluded = true;

                        if(menuItem.Temperature == Temperature.Hot)
                        {
                            hotFoodIncluded = true;
                        }
                    }
                }
                else
                {
                    var message = string.Format("Order item is not valid '{0}'", item);
                    validationResults.AddValidation(ValidationSeverity.Error, message);
                }
            }


            if(!validationResults.AnyErrorOrInvalid())
            {
                if(foodIncluded && !hotFoodIncluded)
                {
                    return totalCost + GetFoodServiceCharge(totalCost);
                }
                
                if(hotFoodIncluded)
                {
                    return totalCost + GetHotFoodServiceCharge(totalCost);
                }

                return totalCost;
            }

            return validationResults.AnyErrorOrInvalid()
                ? 0.0M
                : totalCost;
        }

        #region Private Helpers
        private static decimal GetFoodServiceCharge(decimal value)
        {
            var charge = (value / 100) * 10;

            return charge;
        }

        private static decimal GetHotFoodServiceCharge(decimal value)
        {
            var charge = (value / 100) * 20;

            if(charge <= 20.00M)
            {
                return charge;
            }

            return 20.00M;
        }
        #endregion
    }
}