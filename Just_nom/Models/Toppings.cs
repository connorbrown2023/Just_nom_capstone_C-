using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_nom.Models
{
    public class Topping
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Topping(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

}
