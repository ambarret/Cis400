using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The Meats pizzaclass
    /// </summary>
    public class MeatsPizza
    {
        /// <summary>
        /// The name of the MeatsPizza instance
        /// </summary>
        public string Name { get; } = "";

        /// <summary>
        /// The description of the MeatsPizza instance
        /// </summary>
        public string Description { get; } = "";

        /// <summary>
        /// Whether this MeatsPizza instance contains Sausage
        /// </summary>
        public bool Sausage { get; set; } = true;

        /// <summary>
        /// Whether this MeatsPizza instance contains Pepperoni
        /// </summary>
        public bool Pepperoni { get; set; } = true;

        /// <summary>
        /// Whether this MeatsPizza instance contains Ham
        /// </summary>
        public bool Ham { get; set; } = true;

        /// <summary>
        /// Whether this MeatsPizza instance contains Bacon
        /// </summary>
        public bool Bacon { get; set; } = true;

        /// <summary>
        /// The ammount of slices in this MeatsPizza instance
        /// </summary>
        public uint Slices { get; set; } = 8;

        /// <summary>
        /// The price of the MeatsPizza instance
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The calories per slice in the MeatsPizza instance
        /// </summary>
        public uint CaloriesPerEach { get; }

        /// <summary>
        /// The total calories in the MeatsPizza instance
        /// </summary>
        public uint CaloriesTotal { get; }

        /// <summary>
        /// Special instructions for the preperation for the MeatsPizza instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Sausage) instructions.Add("Hold Sausage");
                if (!Pepperoni) instructions.Add("Hold Pepperoni");
                if (!Bacon) instructions.Add("Hold Bacon");
                if (!Ham) instructions.Add("Hold Ham");
                return instructions;
            }
        }
    }
}
