using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Just_nom.Models
{
    public class Pizza : Main
    {
        public List<Topping> SelectedToppings { get; private set; }
        public PizzaSize Size { get; set; }

        public Pizza()
        {
            SelectedToppings = new List<Topping>();
            Price = 10.00m;  // Base price for Small, you can change the default or set it dynamically
        }

        public override decimal CalculateFinalPrice()
        {
            decimal sizePriceModifier = GetSizePriceModifier(Size);
            return (Price + SelectedToppings.Sum(topping => topping.Price)) * sizePriceModifier;
        }

        private decimal GetSizePriceModifier(PizzaSize size)
        {
            switch (size)
            {
                case PizzaSize.Medium:
                    return 1.25m; // 25% more expensive than small
                case PizzaSize.Large:
                    return 1.50m; // 50% more expensive than small
                default:
                    return 1.0m;  // Default small size
            }
        }

        public void ChooseToppings(Dictionary<string, Topping> availableToppings)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            Console.WriteLine("Available Toppings:");
            foreach (var topping in availableToppings)
            {
                Console.WriteLine($"{topping.Key}: {topping.Value.Price:C2}");
            }

            Console.WriteLine("Enter the names of the toppings you want, separated by commas:");
            string input = Console.ReadLine();
            string[] toppingNames = input.Split(',');

            foreach (var name in toppingNames)
            {
                string cleanedName = name.Trim();
                string titleCaseName = textInfo.ToTitleCase(cleanedName.ToLower()); // Convert to Title Case

                if (availableToppings.TryGetValue(titleCaseName, out Topping topping))
                {
                    SelectedToppings.Add(topping);
                    Console.WriteLine($"{topping.Name} added.");
                }
                else
                {
                    Console.WriteLine($"Topping {titleCaseName} not found.");
                }
            }
        }

        public void SelectSize()
        {
            Console.WriteLine("Available Sizes: 1. Small, 2. Medium, 3. Large");
            Console.WriteLine("Select the size (1-3):");
            string input = Console.ReadLine();
            int choice = int.Parse(input);
            Size = (PizzaSize)(choice - 1);
        }
        public override string GetDescription()
        {
            var toppingsDescription = SelectedToppings.Any() ? string.Join(", ", SelectedToppings.Select(t => t.Name)) : "No additional toppings";
            return $"{Size} Pizza with {toppingsDescription}";
        }
    }


    public class Burger : Main
    {
        public bool HasChips { get; set; }  // Indicates if chips are included
        public bool HasCheese { get; set; }
        public BurgerSize Size { get; set; }
        public SideOption Side { get; set; }

        public Burger()
        {
            this.HasChips = false;  // Default to no chips
            this.HasCheese = false; // Default to no cheesy chips
        }

        public override decimal CalculateFinalPrice()
        {
            decimal finalPrice = this.Price;
            if (HasChips)
            {
                finalPrice += 1.00m; // Price increment if chips are added
                if (HasCheese)
                {
                    finalPrice += 1.00m; // Additional price for cheesy chips
                }
            }
            return finalPrice;
        }

        public void SelectSize()
        {
            Console.WriteLine("Available Sizes: 1. Quarter Pounder, 2. Half Pounder");
            Console.WriteLine("Select the size (1-2):");
            string input = Console.ReadLine();
            Size = (BurgerSize)(int.Parse(input) - 1);
        }

        public void ChooseSide()
        {
            Console.WriteLine("Side options: 1. None, 2. Chips, 3. Cheesy Chips");
            Console.WriteLine("Select your side (1-3):");
            string input = Console.ReadLine();
            Side = (SideOption)(int.Parse(input) - 1);
        }
        public override string GetDescription()
        {
            string sideDescription = "No sides";
            if (HasChips)
            {
                sideDescription = HasCheese ? "Cheesy Chips" : "Chips";
            }
            return $"{Size} Burger with {sideDescription}";
        }

    }

    public class Chips : Side
    {
        public bool IsCheesy { get; set; }

        public Chips()
        {
            Price = 2.00m; // Base price for chips
        }

        public override decimal CalculateFinalPrice()
        {
            return Price + (IsCheesy ? 1.00m : 0m); // Add 1 pound if cheesy chips
        }
        public override string GetDescription()
        {
            return IsCheesy ? "Cheesy Chips" : "Chips";
        }

    }

    public class Wings : Side
    {
        public int Quantity { get; set; }

        public Wings()
        {
            Price = 0.50m; // Price per wing
            Quantity = 5; // Default quantity
        }

        public override decimal CalculateFinalPrice()
        {
            return Price * Quantity;
        }
        public override string GetDescription()
        {
            return $"{Quantity} Wings";
        }

    }

    public class Alcohol : Drink
    {
        public string Type { get; set; }  // Property to hold the type of alcohol

        public Alcohol(string type)  // Constructor that takes the type as a parameter
        {
            this.Type = type;
            this.Price = DetermineBasePrice(type);  // Optionally set price based on type
        }

        private decimal DetermineBasePrice(string type)
        {
            switch (type.ToLower())  // Example: different prices for different types of drinks
            {
                case "beer":
                    return 5.00m;
                case "wine":
                    return 7.00m;
                case "whiskey":
                    return 10.00m;
                default:
                    return 5.00m;  // Default price if type is not recognized
            }
        }

        public override decimal CalculateFinalPrice()
        {
            return this.Price;  // Return base price, additional logic can be added if needed
        }

        public override string GetDescription()
        {
            return $"Alcoholic Drink - {Type}";
        }
    }


    public class NonAlcohol : Drink
    {
        public NonAlcohol()
        {
            Price = 2.00m; // Base price for a non-alcoholic drink
        }

        public override decimal CalculateFinalPrice()
        {
            return Price; // Could vary if there are different types or sizes
        }
        public override string GetDescription()
        {
            return $"Non-Alcoholic Drink - {Type}";  // Assuming `Type` is a property like "Soda", "Juice", etc.
        }

    }



}

