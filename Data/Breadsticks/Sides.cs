using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Breadsticks
{ 
    /// <summary>
    /// The sides class
    /// </summary>
    public class Sides : IMenuItem
    {
        /// <summary>
        /// The name for this Side
        /// </summary>
        public virtual string Name { get; } = "Side";

        /// <summary>
        /// The description for this Side
        /// </summary>
        public virtual string Description { get; } = "Side description";

        /// <summary>
        /// The price for this Side
        /// </summary>
        public virtual decimal Price { get; }

        /// <summary>
        /// The calories for each item in the Side
        /// </summary>
        public virtual uint CaloriesPerEach { get; }

        /// <summary>
        /// The total calories for all of that Side
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return Count * CaloriesPerEach;
            }
        }

        /// <summary>
        /// The instructions for that Side
        /// </summary>
        public virtual IEnumerable<string> SpecialInstructions { get; } = new List<string>();

        /// <summary>
        /// private backing field for the Count Property
        /// </summary>
        protected uint _count = 8;

        /// <summary>
        /// The ammount of sticks in this Wings instance
        /// </summary>
        public virtual uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 4 && value <= 12)
                {
                    _count = value;
                }
            }
        }
    }
}
