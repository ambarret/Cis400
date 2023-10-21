using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data.Breadsticks
{
    /// <summary>
    /// The BreadStick class
    /// </summary>
    public class BreadSticks : Sides
    {
        /// <summary>
        /// The name of the Breadsticks instance
        /// </summary>
        public override string Name { get; } = "Breadsticks";

        /// <summary>
        /// The description of the Breadsticks instance
        /// </summary>
        public override string Description { get; } = "Soft buttery breadsticks";

        /// <summary>
        /// Backing field for Cheese
        /// </summary>
        private bool _cheese = false;

        /// <summary>
        /// Whether this Breadsticks instance contains Pepperoni
        /// </summary>
        public bool Cheese
        {
            get { return _cheese; }
            set
            {
                _cheese = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// The price of the Breadsticks instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Cheese)
                {
                    return SideCount * 1.00m;
                }
                else
                {
                    return SideCount * 0.75m;
                }
            }
        }

        /// <summary>
        /// The calories per stick in the Breadsticks instance
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                uint calories = 150u;
                if (Cheese) calories += 50;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preperation for the Breadsticks instance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Cheese) instructions.Add($"{SideCount} BreadSticks");
                else instructions.Add($"{SideCount} CheeseSticks");
                return instructions;
            }
        }
    }
}
