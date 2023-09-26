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
    public class BreadSticks : IMenuItem
    {
        /// <summary>
        /// The name of the Breadsticks instance
        /// </summary>
        public string Name { get; } = "Breadsticks";

        /// <summary>
        /// The description of the Breadsticks instance
        /// </summary>
        public string Description { get; } = "Soft buttery breadsticks";

        /// <summary>
        /// private backing field for the Count Property
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// The ammount of sticks in this Breadsticks instance
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 4 && value <= 12)
                {

                    _count = value;
                }
            }
        }

        /// <summary>
        /// Whether this Breadsticks instance contains Pepperoni
        /// </summary>
        public bool Cheese { get; set; } = false;

        /// <summary>
        /// The price of the Breadsticks instance
        /// </summary>
        public decimal Price
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
        public uint CaloriesPerEach
        {
            get
            {
                uint calories = 150u;
                if (Cheese) calories += 50;
                return calories;
            }
        }

        /// <summary>
        /// The total calories in the Breadsticks instance
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return Count * CaloriesPerEach;
            }
        }

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
