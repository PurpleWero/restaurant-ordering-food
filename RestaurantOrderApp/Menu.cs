using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderApp
{
    internal class Menu
    {
        public List<MenuItem> Items { get; set; }

        public Menu()
        {
            Items = new List<MenuItem>
            {
                new MenuItem("Burger", "Food", 4.99m),
                new MenuItem("Hot Dog", "Food", 3.99m),
                new MenuItem("Wrap", "Food", 2.99m),
                new MenuItem("Wings", "Food", 6.99m),
                new MenuItem("Pizza", "Food", 8.99m),
                new MenuItem("Coke", "Drink", 1.99m),
                new MenuItem("Beer", "Drink", 2.99m),
                new MenuItem("Tea", "Drink", 1.49m),
                new MenuItem("Water", "Drink", 0.99m),
                new MenuItem("Milkshake", "Drink", 3.99m),
                new MenuItem("Baked Apple Pie", "Dessert", 3.99m),
                new MenuItem("Ice Cream", "Dessert", 1.99m),
                new MenuItem("Vanilla Cone", "Dessert", 1.49m),
                new MenuItem("Chocolate Fudge", "Dessert", 3.49m),
                new MenuItem("Butter Pecan", "Dessert", 1.99m),
            };
        }
    }
}
