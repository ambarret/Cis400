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
        public string Name { get; } = "Garlic Knots";

        /// <summary>
        /// The description of the Garlic Knots instance
        /// </summary>
        public string Description { get; } = "Twisted rolls with garlic and butter";

        /// <summary>
        /// Private backing for Count
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// The ammount of sticks in this Garlic knots instance
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 1)
                {
                    if (value <= 12)
                    {
                        _count = value;
                    }
                    else
                    {
                        _count = 12;
                    }
                }
                else
                {
                    _count = 1;
                }
            }
        }

        /// <summary>
        /// The price of the Garlic Knots instance
        /// </summary>
        public decimal Price 
        {
            get
            {
                return Count * 0.75m;
            }
        }

        /// <summary>
        /// The calories per stick in the Garlic Knots instance
        /// </summary>
        public uint CaloriesPerEach { get; } = 175;

        /// <summary>
        /// The total calories in the Garlic Knots instance
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Count;
            }
        }

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
