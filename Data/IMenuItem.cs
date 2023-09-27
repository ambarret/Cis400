using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Interface for all items on the Menu
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// The name for this menu item
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The description for this menu item
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The price for this menu item
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The calories for each item in the menu item
        /// </summary>
        public uint CaloriesPerEach { get; }

        /// <summary>
        /// The total calories for all of that menu item
        /// </summary>
        public uint CaloriesTotal { get; }

        /// <summary>
        /// The instructions for that menu item
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; }
    }
}
