using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data.Breadsticks
{
    /// <summary>
    /// The Garlic Knots Class
    /// </summary>
    public class GarlicKnots : Sides
    {
        /// <summary>
        /// The name of the Garlic Knots instance
        /// </summary>
        public override string Name { get; } = "Garlic Knots";

        /// <summary>
        /// The description of the Garlic Knots instance
        /// </summary>
        public override string Description { get; } = "Twisted rolls with garlic and butter";

        /// <summary>
        /// The price of the Garlic Knots instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                return Count * 0.75m;
            }
        }

        /// <summary>
        /// The calories per stick in the Garlic Knots instance
        /// </summary>
        public override uint CaloriesPerEach { get; } = 175;

        /// <summary>
        /// Special instructions for the preperation for the Garlic Knots instance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add($"{Count} Garlic Knots");
                return instructions;
            }
        }
    }
}
