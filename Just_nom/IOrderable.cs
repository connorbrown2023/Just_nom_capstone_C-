using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_nom
{
    public interface IOrderable
    {
        string Name { get; set; }
        decimal Price { get; set; }
        string Description { get; set; }

        decimal CalculateFinalPrice();
        string GetDescription();
    }

}
