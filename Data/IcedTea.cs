using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The Iced Tea Class
    /// </summary>
    public class IcedTea
    {
        /// <summary>
        /// The name for the Iced Tea instance
        /// </summary>
        public string Name { get; } = "Iced Tea";

        /// <summary>
        /// The Description for the Iced Tea instance
        /// </summary>
        public string Description { get; } = "Freshly brewed sweet tea";

        /// <summary>
        /// Decides weather ice is included for this Iced Tea instance
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// Private backing field for DrinkSize
        /// </summary>
        public Size _size = Size.Medium;

        /// <summary>
        /// The size of this Iced Tea instance
        /// </summary>
        public Size DrinkSize
        {
            get
            {
                return _size;
            }

            set
            {
                _size = Size.Medium;
                if (value == Size.Small) _size = Size.Small;
                if (value == Size.Large) _size = Size.Large;
            }
        }

        /// <summary>
        /// The price for this Iced Tea instance
        /// </summary>
        public decimal Price
        {
            get
            {
                if (DrinkSize == Size.Large) return 3.00m;
                if (DrinkSize == Size.Small) return 2.00m;
                if (DrinkSize == Size.Medium) return 2.50m;
                return 2.50m;
            }
        }

        /// <summary>
        /// The calories of this Iced Tea instance
        /// </summary>
        public uint Calories
        {
            get
            {
                if (DrinkSize == Size.Small) return 175;
                if (DrinkSize == Size.Medium) return 220;
                if (DrinkSize == Size.Large) return 275;
                return 220;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Iced Tea instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(DrinkSize.ToString());
                if (!Ice) instructions.Add("Hold Ice");
                return instructions;
            }
        }
    }
}
