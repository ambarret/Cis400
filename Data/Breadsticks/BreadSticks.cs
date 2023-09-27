using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data.Breadsticks
{
    /// <summary>
    /// The BreadStick class
    /// </summary>
    public class BreadSticks : Sides
    {
        /// <summary>
        /// The name of the Breadsticks instance
        /// </summary>
        public override string Name { get; } = "Breadsticks";

        /// <summary>
        /// The description of the Breadsticks instance
        /// </summary>
        public override string Description { get; } = "Soft buttery breadsticks";

        /// <summary>
        /// Whether this Breadsticks instance contains Pepperoni
        /// </summary>
        public bool Cheese { get; set; } = false;

        /// <summary>
        /// The price of the Breadsticks instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Cheese)
                {
                    return Count * 1.00m;
                }
                else
                {
                    return Count * 0.75m;
                }
            }
        }

        /// <summary>
        /// The calories per stick in the Breadsticks instance
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                uint calories = 150u;
                if (Cheese) calories += 50;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preperation for the Breadsticks instance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
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
