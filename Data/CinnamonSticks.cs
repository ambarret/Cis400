using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    public class CinnamonSticks
    {
        /// <summary>
        /// The name of the Cinnamonsticks instance
        /// </summary>
        public string Name { get; } = "";

        /// <summary>
        /// The description of the Cinnamonsticks instance
        /// </summary>
        public string Description { get; } = "";

        /// <summary>
        /// The ammount of sticks in this Cinnamonsticks instance
        /// </summary>
        public uint Count { get; set; } = 8;

        /// <summary>
        /// Whether this Cinnamonsticks instance contains Frosting
        /// </summary>
        public bool Frosting { get; set; } = true;

        /// <summary>
        /// The price of the Cinnamonsticks instance
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The calories per stick in the Cinnamonsticks instance
        /// </summary>
        public uint CaloriesPerEach { get; }

        /// <summary>
        /// The total calories in the Cinnamonsticks instance
        /// </summary>
        public uint CaloriesTotal { get; }

        /// <summary>
        /// Special instructions for the preperation for the Cinnamonsticks instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add($"{Count} CinnamonSticks");
                if(!Frosting) instructions.Add("Hold Frosting");
                return instructions;
            }
        }
    }
}
