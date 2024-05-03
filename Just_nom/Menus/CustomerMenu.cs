using Just_nom.Models;
using Just_nom.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_nom.Menus
{
    // CustomerMenu.cs
    public class CustomerMenu
    {
        private OrderProcessor orderProcessor;

        public CustomerMenu()
        {
            orderProcessor = new OrderProcessor();  // Initialize once at the creation of the CustomerMenu
        }

        public void Display()
        {
            Console.WriteLine("Customer Menu:");
            Console.WriteLine("1. Order Pizza");
            Console.WriteLine("2. Order Burger");
            Console.WriteLine("3. Order Sides");
            Console.WriteLine("4. Order Drinks");
            Console.WriteLine("5. Process Order and Checkout");
            Console.WriteLine("Enter option or press 'Q' to quit:");
            string option = Console.ReadLine();

            switch (option.ToUpper())
            {
                case "1":
                    Pizza pizza = StartPizzaOrder();
                    if (pizza != null)
                        orderProcessor.AddItem(pizza);
                    break;
                case "2":
                    Burger burger = StartBurgerOrder();
                    if (burger != null)
                        orderProcessor.AddItem(burger);
                    break;
                case "3":
                    OrderSides();
                    break;
                case "4":
                    OrderDrinks();
                    break;
                case "5":
                    orderProcessor.DisplayOrderDetails();
                    orderProcessor.ProcessOrder();
                    break;
                case "Q":
                    Console.WriteLine("Exiting the menu.");
                    return; // Exits the customer menu
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
            Display(); // Recursively call Display to show the menu again
        }

        private Pizza StartPizzaOrder()
        {
            var toppings = ToppingsManager.LoadToppingsFromFile(@"C:\Users\conno\OneDrive\Desktop\UNI\Architectures, Operating Systems and Cloud\Just_nom\Just_nom\Data\Toppings.txt");
            if (toppings.Count == 0)
            {
                Console.WriteLine("No toppings loaded. Please check the toppings data file and try again.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                return null; // No toppings means no pizza can be created
            }

            Console.WriteLine($"{toppings.Count} toppings loaded.");

            Pizza myPizza = new Pizza();
            myPizza.SelectSize();
            myPizza.ChooseToppings(toppings);

            decimal finalPrice = myPizza.CalculateFinalPrice();
            Console.WriteLine($"The total price of your {myPizza.Size} pizza is: {finalPrice:C2}");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return myPizza; // Successfully created pizza is returned
        }

        private Burger StartBurgerOrder()
        {
            Burger myBurger = new Burger();

            myBurger.SelectSize();
            myBurger.ChooseSide();

            decimal finalPrice = myBurger.CalculateFinalPrice();
            Console.WriteLine($"The total price of your {myBurger.Size} burger with {myBurger.Side} is: {finalPrice:C2}");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return myBurger; // Return the created burger
        }

        private Side OrderSides()
        {
            Console.WriteLine("Choose your side:");
            Console.WriteLine("1. Chips");
            Console.WriteLine("2. Wings");
            Console.WriteLine("Select your choice:");
            string choice = Console.ReadLine();

            Side sideItem = null;
            switch (choice)
            {
                case "1":
                    sideItem = new Chips();
                    Console.WriteLine("Do you want cheesy chips? (yes/no)");
                    if (Console.ReadLine().Trim().ToLower() == "yes")
                    {
                        ((Chips)sideItem).IsCheesy = true;
                    }
                    break;
                case "2":
                    sideItem = new Wings();
                    Console.WriteLine("Enter quantity of wings:");
                    ((Wings)sideItem).Quantity = int.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to main menu.");
                    return null;
            }

            Console.WriteLine($"Added {sideItem.Name}. Total added cost: {sideItem.CalculateFinalPrice():C2}");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return sideItem;
        }


        private Drink OrderDrinks()
        {
            Console.WriteLine("Choose your drink:");
            Console.WriteLine("1. Alcoholic Drink");
            Console.WriteLine("2. Non-Alcoholic Drink");
            Console.WriteLine("Select your choice:");
            string choice = Console.ReadLine();

            Drink drink = null;
            switch (choice)
            {
                case "1":
                    drink = new Alcohol();
                    break;
                case "2":
                    drink = new NonAlcohol();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to main menu.");
                    return null;
            }

            Console.WriteLine($"Added {drink.Name}. Total added cost: {drink.CalculateFinalPrice():C2}");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            return drink;
        }


        private void ProcessOrder()
        {
            // Implementation to finalize the order and provide a summary
            Console.WriteLine("Order processed. Your final receipt is being prepared...");
            // Add logic to show order summary and finalize the order

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Display(); // Return to the main menu to allow further actions or exit
        }

        // You will need to implement the corresponding methods to handle these orders
    }

}
