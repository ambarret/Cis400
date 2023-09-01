using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The BreadStick class
    /// </summary>
    public class BreadSticks
    {
        /// <summary>
        /// The name of the Breadsticks instance
        /// </summary>
        public string Name { get; } = "";

        /// <summary>
        /// The description of the Breadsticks instance
        /// </summary>
        public string Description { get; } = "";

        /// <summary>
        /// The ammount of sticks in this Breadsticks instance
        /// </summary>
        public uint Count { get; set; } = 8;

        /// <summary>
        /// Whether this Breadsticks instance contains Pepperoni
        /// </summary>
        public bool Cheese { get; set; } = false;

        /// <summary>
        /// The price of the Breadsticks instance
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The calories per stick in the Breadsticks instance
        /// </summary>
        public uint CaloriesPerEach { get; }

        /// <summary>
        /// The total calories in the Breadsticks instance
        /// </summary>
        public uint CaloriesTotal { get; }

        /// <summary>
        /// Special instructions for the preperation for the Breadsticks instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Cheese) instructions.Add($"{Count} BreadSticks");
                else instructions.Add($"{Count} CheeseSticks");
                return instructions;
            }
        }
    }
}
