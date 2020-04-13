using System;
using System.Collections.Generic;
using System.Text;

namespace Caspian_Cafe.Models
{
    public class MenuItem
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public Temperature Temperature { get; set; }

        public ItemType ItemType { get; set; }
    }
}