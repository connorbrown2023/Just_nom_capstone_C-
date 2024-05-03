using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_nom.Utilities
{
    public class OrderProcessor
    {
        private List<IOrderable> orderItems = new List<IOrderable>();
        private decimal totalCost = 0m; // Keep a running total if needed

        public void AddItem(IOrderable item)
        {
            orderItems.Add(item);
            totalCost += item.CalculateFinalPrice(); // Add to the total immediately
        }

        public void ProcessOrder()
        {
            Console.WriteLine("Finalizing your order...");
            Console.WriteLine($"Total order cost: {totalCost:C2}");
            Console.WriteLine("Order has been processed. Thank you for your purchase!");
            totalCost = 0; // Reset the total if the order is finalized
            orderItems.Clear(); // Optionally clear the list after order processing
        }

        public void DisplayOrderDetails()
        {
            if (orderItems.Count == 0)
            {
                Console.WriteLine("No items in your order.");
                return;
            }
            Console.WriteLine("Order Summary:");
            foreach (var item in orderItems)
            {
                Console.WriteLine($"{item.Name} - {item.CalculateFinalPrice():C2}");
            }
        }
    }

}
