using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Drinks
{
    /// <summary>
    /// The soda class
    /// </summary>
    public class Soda : Drink
    {
        /// <summary>
        /// The name of the Soda instance
        /// </summary>
        public override string Name { get; } = "Soda";

        /// <summary>
        /// The description of the Soda instance
        /// </summary>
        public override string Description { get; } = "Standard fountain drink";

        /// <summary>
        /// private backing field for the DrinkType
        /// </summary>
        private SodaFlavor _flavor = SodaFlavor.Coke;

        /// <summary>
        /// The Drink Type for this soda instance
        /// </summary>
        public SodaFlavor DrinkType
        {
            get
            {
                return _flavor;
            }
            set
            {
                _flavor = SodaFlavor.Coke;
                if (value == SodaFlavor.DietCoke) _flavor = SodaFlavor.DietCoke;
                if (value == SodaFlavor.DrPepper) _flavor = SodaFlavor.DrPepper;
                if (value == SodaFlavor.Sprite) _flavor = SodaFlavor.Sprite;
                if (value == SodaFlavor.RootBeer) _flavor = SodaFlavor.RootBeer;
            }
        }

        /// <summary>
        /// The price for this soda instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (DrinkSize == Size.Large) return 2.50m;
                if (DrinkSize == Size.Small) return 1.50m;
                return 2.00m;
            }
        }

        /// <summary>
        /// The calories of this soda instance
        /// </summary>
        public override uint CaloriesTotal
        {
            get
            {
                if (DrinkType == SodaFlavor.DietCoke) return 0;
                else
                {
                    if (DrinkSize == Size.Small) return 150;
                    if (DrinkSize == Size.Large) return 250;
                    return 200;
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Soda instance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(DrinkSize.ToString());
                instructions.Add(DrinkType.ToString());
                if (!Ice) instructions.Add("Hold Ice");
                return instructions;
            }
        }
    }
}
