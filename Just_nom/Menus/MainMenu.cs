using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_nom.Menus
{
    public class MainMenu
    {
        public void Display()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Guest");
            Console.WriteLine("3. Customer");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.Display();
                    break;
                case "2":
                    GuestMenu guestMenu = new GuestMenu();
                    guestMenu.Display();
                    break;
                case "3":
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.Display();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    Display();
                    break;
            }
        }
    }

}
