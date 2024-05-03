using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_nom
{
    public abstract class Main : IOrderable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public enum PizzaSize
        {
            Small,
            Medium,
            Large
        }
        public enum BurgerSize
        {
            QuarterPounder,  // 1/4 pound
            HalfPounder      // 1/2 pound
        }

        public enum SideOption
        {
            None,
            Chips,
            CheesyChips
        }


        public PizzaSize Size { get; set; }

        public virtual decimal CalculateFinalPrice()
        {
            return Price; // Base implementation, subclasses may override to add logic for toppings, etc.
        }

        public abstract string GetDescription();
    }


    public abstract class Side : IOrderable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual decimal CalculateFinalPrice()
        {
            return Price; // Base implementation, subclasses may override to add logic for toppings, etc.
        }
        public abstract string GetDescription();
    }

    public abstract class Drink : IOrderable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual decimal CalculateFinalPrice()
        {
            return Price; // Base implementation, subclasses may override to add logic for toppings, etc.
        }
        public abstract string GetDescription();
    }

}
