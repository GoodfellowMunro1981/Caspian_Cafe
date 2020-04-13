using System.Collections.Generic;
using Caspian_Cafe.Models;

namespace Caspian_Cafe.Data
{
    public static class MenuData
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
    }
}