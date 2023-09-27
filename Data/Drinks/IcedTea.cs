using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Drinks
{
    /// <summary>
    /// The Iced Tea Class
    /// </summary>
    public class IcedTea : Drink
    {
        /// <summary>
        /// The name for the Iced Tea instance
        /// </summary>
        public override string Name { get; } = "Iced Tea";

        /// <summary>
        /// The Description for the Iced Tea instance
        /// </summary>
        public override string Description { get; } = "Freshly brewed sweet tea";

        /// <summary>
        /// The price for this Iced Tea instance
        /// </summary>
        public override decimal Price
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
        public override uint CaloriesTotal
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
        public override IEnumerable<string> SpecialInstructions
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
