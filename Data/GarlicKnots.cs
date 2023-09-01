using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The Garlic Knots Class
    /// </summary>
    public class GarlicKnots
    {
        /// <summary>
        /// The name of the Garlic Knots instance
        /// </summary>
        public string Name { get; } = "";

        /// <summary>
        /// The description of the Garlic Knots instance
        /// </summary>
        public string Description { get; } = "";

        /// <summary>
        /// The ammount of sticks in this Garlic Knots instance
        /// </summary>
        public uint Count { get; set; } = 8;


        /// <summary>
        /// The price of the Garlic Knots instance
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The calories per stick in the Garlic Knots instance
        /// </summary>
        public uint CaloriesPerEach { get; }

        /// <summary>
        /// The total calories in the Garlic Knots instance
        /// </summary>
        public uint CaloriesTotal { get; }

        /// <summary>
        /// Special instructions for the preperation for the Garlic Knots instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add($"{Count} Garlic knots");
                return instructions;
            }
        }
    }
}
