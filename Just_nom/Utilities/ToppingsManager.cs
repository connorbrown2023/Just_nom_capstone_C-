using Just_nom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Just_nom.Utilities
{
    public static class ToppingsManager
    {
            public static Dictionary<string, Topping> LoadToppingsFromFile(string filePath)
            {
                var toppingsDictionary = new Dictionary<string, Topping>();

                try
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string name = parts[0].Trim('\'', ' ');
                            decimal price = decimal.Parse(parts[1].Trim('\'', ' '));

                            if (!toppingsDictionary.ContainsKey(name))
                            {
                                toppingsDictionary.Add(name, new Topping(name, price));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., file not found, no access)
                    // Optionally rethrow or handle the error according to your needs
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }

                return toppingsDictionary;
            }
        


    }
}
