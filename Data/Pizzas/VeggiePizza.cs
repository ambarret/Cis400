using PizzaParlor.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data.Pizzas
{
    /// <summary>
    /// THe Veggie Pizza class
    /// </summary>
    public class VeggiePizza : IMenuItem
    {
        /// <summary>
        /// The name of the VeggiePizza instance
        /// </summary>
        public string Name { get; } = "Veggie Pizza";

        /// <summary>
        /// The description of the VeggiePizza instance
        /// </summary>
        public string Description { get; } = "All the veggies";

        /// <summary>
        /// Whether this VeggiePizza instance contains Olives
        /// </summary>
        public bool Olives { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Peppers
        /// </summary>
        public bool Peppers { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this VeggiePizza instance contains Mushrooms
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// Private backing field for PizzaSize
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// The Size of this Veggie Pizza instance
        /// </summary>
        public Size PizzaSize
        {
            get
            {
                return _size;
            }
            set
            {
                if (value == Size.Large) _size = Size.Large;
                if (value == Size.Medium) _size = Size.Medium;
                if (value == Size.Small) _size = Size.Small;
            }
        }

        /// <summary>
        /// Private backing field for PizzaCrust
        /// </summary>
        private Crust _crust = Crust.Original;

        /// <summary>
        /// The Crust for this Veggie Pizza instance
        /// </summary>
        public Crust PizzaCrust
        {
            get
            {
                return _crust;
            }
            set
            {
                if (value == Crust.Thin) _crust = Crust.Thin;
                if (value == Crust.Original) _crust = Crust.Original;
                if (value == Crust.DeepDish) _crust = Crust.DeepDish;
            }
        }
        /// <summary>
        /// The ammount of slices in this VeggiePizza instance
        /// </summary>
        public uint Slices { get; set; } = 8;

        /// <summary>
        /// The price of the VeggiePizza instance
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal price = 12.99m;
                if (PizzaSize == Size.Small) price -= 2.00m;
                if (PizzaSize == Size.Large) price += 2.00m;
                if (PizzaCrust == Crust.DeepDish) price += 1.00m;
                return price;
            }
        }

        /// <summary>
        /// The calories per slice in the VeggiePizza instance
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint calories = 0;
                if (PizzaCrust == Crust.Thin) calories += 150;
                if (PizzaCrust == Crust.Original) calories += 250;
                if (PizzaCrust == Crust.DeepDish) calories += 300;
                if (Onions) calories += 5;
                if (Peppers) calories += 5;
                if (Mushrooms) calories += 5;
                if (Olives) calories += 5;
                if (PizzaSize == Size.Small) return (uint)(calories * 0.75);
                if (PizzaSize == Size.Large) return (uint)(calories * 1.30);
                return calories;
            }
        }

        /// <summary>
        /// The total calories in the VeggiePizza instance
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the preperation for the VeggiePizza instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(PizzaSize.ToString());
                instructions.Add(PizzaCrust.ToString());
                if (!Onions) instructions.Add("Hold Onions");
                if (!Olives) instructions.Add("Hold Olives");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                return instructions;
            }
        }
    }
}
