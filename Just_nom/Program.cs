using Just_nom.Menus;
using Just_nom.Models;
using static Just_nom.Main;
using static Just_nom.Utilities.ToppingsManager;

namespace Just_nom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MainMenu menu = new MainMenu();
                menu.Display(); // Start the application by displaying the main menu
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(); // Keep the console open until a key is pressed
        }
    }
}