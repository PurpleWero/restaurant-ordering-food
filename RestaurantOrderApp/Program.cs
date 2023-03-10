using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace RestaurantOrderApp
{
    class Program
    {
        static List<MenuItem> currentOrder = new List<MenuItem>();
        static Menu menu = new Menu();

        delegate void MenuDelegate(Menu menu);

        static MenuDelegate menuDelegate = DisplayMenu;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Black Pepper!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. List the restaurant menu");
                Console.WriteLine("2. Start an order");
                Console.WriteLine("3. View current order");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine();
                        menuDelegate.Invoke(menu);
                        bool validAnswer = false;
                        while (!validAnswer)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Do you want to start ordering? (Y/N)");

                            string answer = Console.ReadLine();

                            if (answer.ToUpper() == "Y")
                            {
                                validAnswer = true;
                                StartOrder();
                                break;
                            }
                            else if (answer.ToUpper() == "N")
                            {
                                validAnswer = true;
                                Console.WriteLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Invalid input, please enter Y or N.");
                            }
                        }
                        
                        break;
                    case "2":
                        StartOrder();
                        break;
                    case "3":
                        DisplayCurrentOrder();
                        break;
                   
                    case "4":
                        Checkout();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for your visit!");
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid input, please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void DisplayMenu(Menu menu)
        {
            Console.WriteLine("Menu:");

            for (int i = 0; i < menu.Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu.Items[i]}");
            }
        }

        static void StartOrder()
        {
            Console.WriteLine();
            menuDelegate.Invoke(menu);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter item number to add to order, or type 'done' to finish order:");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                {
                    break;
                }


                int itemNumber;
                bool isNumeric = int.TryParse(input, out itemNumber);


                if (!isNumeric || itemNumber < 1 || itemNumber > menu.Items.Count)
                {
                    Console.WriteLine("Invalid input, please enter a valid item number or type 'done' to finish.");
                    Console.WriteLine();
                    continue;
                }

                itemNumber = int.Parse(input) - 1;

                if (itemNumber >= 0 && itemNumber < menu.Items.Count)
                {
                    currentOrder.Add(menu.Items[itemNumber]);
                    Console.WriteLine(menu.Items[itemNumber] + " added to order.");
                }

            }

            while (true)
            {
                Console.WriteLine();
                DisplayCurrentOrder();
                Console.WriteLine();
                bool validAnswer = false;
                while (!validAnswer)
                {
                    Console.WriteLine();
                    Console.WriteLine("Do you want to modify your order? (Y/N)");

                    string answer = Console.ReadLine();

                    if (answer.ToUpper() == "Y")
                    {
                        validAnswer = true;
                        ModifyCurrentOrder();

                    }
                    else if (answer.ToUpper() == "N")
                    {
                        validAnswer = true;
                        Console.WriteLine();
                        break;
                        

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid input, please enter Y or N.");
                    }

                }
                break;

            }
            Console.WriteLine();
            Console.WriteLine("Order complete.");
            Console.WriteLine();
        }

        static void ModifyCurrentOrder()
        {
            bool validAnswer = false;
            while (!validAnswer)
            {
                Console.WriteLine();
                Console.WriteLine("Please type Add / Remove to modify the order: ");

                string answer = Console.ReadLine();

                if (answer.ToUpper() == "ADD")
                {
                    validAnswer = true;
                    menuDelegate.Invoke(menu);
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter item number to add to order, or type 'done' to finish order:");
                        string input = Console.ReadLine();

                        if (input.ToLower() == "done")
                        {
                            break;
                        }


                        int itemNumber;
                        bool isNumeric = int.TryParse(input, out itemNumber);
                       

                        if (!isNumeric || itemNumber < 1 || itemNumber > menu.Items.Count)
                        {
                            Console.WriteLine("Invalid input, please enter a valid item number or type 'done' to finish.");
                            Console.WriteLine();
                            continue;
                        }

                        itemNumber = int.Parse(input) - 1;

                        if (itemNumber >= 0 && itemNumber < menu.Items.Count)
                        {
                            currentOrder.Add(menu.Items[itemNumber]);
                            Console.WriteLine(menu.Items[itemNumber] + " added to order.");
                        }

                    }


                }
                else if (answer.ToUpper() == "REMOVE")
                {
                    validAnswer = true;
                    while (true)
                    {
                        Console.WriteLine();
                        DisplayCurrentOrder();
                        Console.WriteLine();
      
                        Console.WriteLine("Enter item number to remove from order, or type 'done' to continue:");
                        string input = Console.ReadLine();

                        if (input.ToLower() == "done")
                        {
                            break;
                        }


                        int itemNumber;
                        bool isNumeric = int.TryParse(input, out itemNumber);
                        

                        if (!isNumeric || itemNumber < 1 || itemNumber > menu.Items.Count)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid input, please enter a valid item number or type 'done' to finish.");
                            Console.WriteLine();
                            continue;
                        }

                        itemNumber = int.Parse(input) - 1;

                        if (itemNumber >= 0 && itemNumber < currentOrder.Count)
                        {
                            MenuItem removedItem = currentOrder[itemNumber];
                            currentOrder.RemoveAt(itemNumber);
                            Console.WriteLine();
                            Console.WriteLine(removedItem + " removed from order.");
                        }

                    }

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input, please enter Add / Remove.");
                }
            }
        }
        static void DisplayCurrentOrder()
        {
            Console.WriteLine();
            if (currentOrder.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("You don't have an order yet.");
                Console.WriteLine();
            }
            else
            {
                decimal total = 0;
                Console.WriteLine();
                Console.WriteLine("Current order:");
                Console.WriteLine();
                for (int i = 0; i < currentOrder.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {currentOrder[i]}");
                    total += currentOrder[i].Price;
                }

                Console.WriteLine($"Total: ${total}");
                Console.WriteLine();
          
            }
        }
        static void Checkout()
        {
            decimal totalPrice = 0;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Checkout of your final order:");
            Console.WriteLine();
            for (int i = 0; i < currentOrder.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {currentOrder[i]}");
                totalPrice += currentOrder[i].Price;
            }
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${totalPrice}");

            bool validAnswer = false;
            while (!validAnswer)
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to proceed with the checkout? (Y/N)");

                string answer = Console.ReadLine();

                if (answer.ToUpper() == "Y")
                {
                    validAnswer = true;
                    Console.WriteLine();
                    Console.WriteLine("Preparing your order...");

                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Orders");
                    string filePath = Path.Combine(folderPath, "orders.txt");
                    Directory.CreateDirectory(folderPath);

                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine("Order: ");
                        foreach (var item in currentOrder)
                        {
                            sw.WriteLine($"{item.Name} - {item.Price:C}");
                        }
                        sw.WriteLine($"Total: ${totalPrice}");
                        sw.WriteLine();
                        sw.WriteLine("Preparing your order...");
                        sw.WriteLine("Your order is on the way");
                        sw.WriteLine("Your order has been delivered");
                        sw.WriteLine("-------------------------------");
                        sw.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Thank you for your order!");
                    Console.WriteLine();
                    currentOrder.Clear();

                }
                else if (answer.ToUpper() == "N")
                {
                    validAnswer = true;
                    Console.WriteLine();
                    Console.WriteLine("Checkout cancelled.");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input, please enter Y or N.");
                }
            }
        }
    }
}
