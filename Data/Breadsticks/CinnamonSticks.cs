using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data.Breadsticks
{
    /// <summary>
    /// The CinnamonSticks class
    /// </summary>
    public class CinnamonSticks
    {
        /// <summary>
        /// The name of the Cinnamonsticks instance
        /// </summary>
        public string Name { get; } = "Cinnamon Sticks";

        /// <summary>
        /// The description of the Cinnamonsticks instance
        /// </summary>
        public string Description { get; } = "Like breadsticks but for dessert";

        /// <summary>
        /// Private backing for Count
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// The ammount of sticks in this Cinnamonsticks instance
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 4)
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
                    _count = 8;
                }
            }
        }

        /// <summary>
        /// Whether this Cinnamonsticks instance contains Frosting
        /// </summary>
        public bool Frosting { get; set; } = true;

        /// <summary>
        /// The price of the Cinnamonsticks instance
        /// </summary>
        public decimal Price
        {
            get
            {
                if (Frosting)
                {
                    return 0.90m * Count;
                }
                else
                {
                    return 0.75m * Count;
                }
            }
        }

        /// <summary>
        /// The calories per stick in the Cinnamonsticks instance
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint calories = 160u;
                if (Frosting) calories += 30;
                return calories;
            }
        }

        /// <summary>
        /// The total calories in the Cinnamonsticks instance
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Count;
            }
        }

        /// <summary>
        /// Special instructions for the preperation for the Cinnamonsticks instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add($"{Count} CinnamonSticks");
                if (!Frosting) instructions.Add("Hold Frosting");
                return instructions;
            }
        }
    }
}
