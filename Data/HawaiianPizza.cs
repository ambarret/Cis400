using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// the Hawaiian Pizza class
    /// </summary>
    public class HawaiianPizza
    {
        /// <summary>
        /// The name of the HawaiianPizza instance
        /// </summary>
        public string Name { get; } = "Hawaiian Pizza";

        /// <summary>
        /// The description of the HawaiianPizza instance
        /// </summary>
        public string Description { get; } = "The pizza with pineapple";

        /// <summary>
        /// Whether this HawaiianPizza instance contains Onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this HawaiianPizza instance contains Ham
        /// </summary>
        public bool Ham { get; set; } = true;

        /// <summary>
        /// Whether this HawaiianPizza instance contains Pineapple
        /// </summary>
        public bool Pineapple { get; set; } = true;

        /// <summary>
        /// The ammount of slices in this HawaiianPizza instance
        /// </summary>
        public uint Slices { get; set; } = 8;

        /// <summary>
        /// The price of the HawaiianPizza instance
        /// </summary>
        public decimal Price { get; } = 13.99m;

        /// <summary>
        /// The calories per slice in the HawaiianPizza instance
        /// </summary>
        public uint CaloriesPerEach 
        {
            get
            {
                uint calories = 250;
                if (Ham) calories += 30;
                if (Pineapple) calories += 15;
                if (Onions) calories += 5;
                return calories;
            }
        }

        /// <summary>
        /// The total calories in the HawaiianPizza instance
        /// </summary>
        public uint CaloriesTotal 
        {
            get
            {
                return (CaloriesPerEach * Slices);
            } 
        }

        /// <summary>
        /// Special instructions for the preperation for the HawaiianPizza instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Onions) instructions.Add("Hold Onions");
                if (!Pineapple) instructions.Add("Hold Pineapple");
                if (!Ham) instructions.Add("Hold Ham");
                return instructions;
            }
        }
    }
}
