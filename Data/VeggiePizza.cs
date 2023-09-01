using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// THe Veggie Pizza class
    /// </summary>
    public class VeggiePizza
    {
        /// <summary>
        /// The name of the VeggiePizza instance
        /// </summary>
        public string Name { get; } = "Veggie Pizza";

        /// <summary>
        /// The description of the VeggiePizza instance
        /// </summary>
        public string Description { get; } = "All the veggies";

        /// <summary>
        /// Whether this VeggiePizza instance contains Olives
        /// </summary>
        public bool Olives { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Peppers
        /// </summary>
        public bool Peppers { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Mushrooms
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// The ammount of slices in this VeggiePizza instance
        /// </summary>
        public uint Slices { get; set; } = 8;

        /// <summary>
        /// The price of the VeggiePizza instance
        /// </summary>
        public decimal Price { get; } = 12.99m;

        /// <summary>
        /// The calories per slice in the VeggiePizza instance
        /// </summary>
        public uint CaloriesPerEach 
        {
            get 
            {
                uint calories = 250;
                if (Onions) calories += 5;
                if (Peppers) calories += 5;
                if (Mushrooms) calories += 5;
                if (Olives) calories += 5;
                return calories;
            } 
        }

        /// <summary>
        /// The total calories in the VeggiePizza instance
        /// </summary>
        public uint CaloriesTotal 
        {
            get
            {
                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the preperation for the VeggiePizza instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Onions) instructions.Add("Hold Onions");
                if (!Olives) instructions.Add("Hold Olives");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                return instructions;
            }
        }
    }
}
