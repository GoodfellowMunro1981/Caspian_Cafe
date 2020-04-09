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
                        Temperature = Temperature.Cold
                    },
                    new MenuItem
                    {
                        Name = "Coffee",
                        Cost = 1.00M,
                        Temperature = Temperature.Hot
                    },
                    new MenuItem
                    {
                        Name = "Cheese Sandwich",
                        Cost = 2.00M,
                        Temperature = Temperature.Cold
                    },
                    new MenuItem
                    {
                        Name = "Steak Sandwich",
                        Cost = 4.50M,
                        Temperature = Temperature.Hot
                    }
                }
            };

            return menu;
        }

        public static decimal ProcessOrder(IEnumerable<string> order, ValidationResults validationResults)
        {
            var menu = GetMenu();
            var totalCost = 0.0M;

            foreach (var item in order)
            {
                if (!string.IsNullOrEmpty(item) && menu.Items.Any(x => x.Name == item))
                {
                    var menuItem = menu.Items
                                    .Where(x => x.Name == item)
                                    .FirstOrDefault();


                    totalCost += menuItem.Cost;

                }
                else
                {
                    var message = string.Format("Order item is not valid '{0}'", item);

                    validationResults.AddValidation(ValidationSeverity.Error, message);
                }
            }

            return validationResults.AnyErrorOrInvalid()
                ? 0.0M
                : totalCost;
        }
    }
}
