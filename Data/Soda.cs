using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The soda class
    /// </summary>
    public class Soda
    {
        /// <summary>
        /// The name of the Soda instance
        /// </summary>
        public string Name { get; } = "Soda";

        /// <summary>
        /// The description of the Soda instance
        /// </summary>
        public string Description { get; } = "Standard fountain drink";

        /// <summary>
        /// Decides weather ice is included for this soda instance
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// Private backing field for DrinkSize
        /// </summary>
        public Size _size = Size.Medium;

        /// <summary>
        /// The size of this soda instance
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
        /// private backing field for the DrinkType
        /// </summary>
        public SodaFlavor _flavor = SodaFlavor.Coke;

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
        public decimal Price
        {
            get
            {
                if (DrinkSize == Size.Large) return 2.50m;
                if (DrinkSize == Size.Small) return 1.50m;
                return 2.00m;
            }
        }
    }
}
