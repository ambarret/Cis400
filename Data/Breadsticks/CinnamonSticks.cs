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
    public class CinnamonSticks : Sides
    {
        /// <summary>
        /// The name of the Cinnamonsticks instance
        /// </summary>
        public override string Name { get; } = "Cinnamon Sticks";

        /// <summary>
        /// The description of the Cinnamonsticks instance
        /// </summary>
        public override string Description { get; } = "Like breadsticks but for dessert";

        /// <summary>
        /// Backing Field for Frosting
        /// </summary>
        private bool _frosting = true;

        /// <summary>
        /// Whether this Cinnamonsticks instance contains Frosting
        /// </summary>
        public bool Frosting
        {
            get { return _frosting; }
            set 
            {
                _frosting = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// The price of the Cinnamonsticks instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Frosting)
                {
                    return 0.90m * SideCount;
                }
                else
                {
                    return 0.75m * SideCount;
                }
            }
        }

        /// <summary>
        /// The calories per stick in the Cinnamonsticks instance
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                uint calories = 160u;
                if (Frosting) calories += 30;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preperation for the Cinnamonsticks instance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add($"{SideCount} CinnamonSticks");
                if (!Frosting) instructions.Add("Hold Frosting");
                return instructions;
            }
        }
    }
}
