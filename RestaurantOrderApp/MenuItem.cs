using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderApp
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string name, string type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - ${Price}";
        }
    }
}