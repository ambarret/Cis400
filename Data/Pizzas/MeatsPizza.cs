using PizzaParlor.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data.Pizzas
{
    /// <summary>
    /// The Meats pizza class
    /// </summary>
    public class MeatsPizza
    {
        /// <summary>
        /// The name of the MeatsPizza instance
        /// </summary>
        public string Name { get; } = "Meats Pizza";

        /// <summary>
        /// The description of the MeatsPizza instance
        /// </summary>
        public string Description { get; } = "All the meats";

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
        /// Private backing field for PizzaSize
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// The Size of this Meats Pizza instance
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
        /// The Crust for this Meats Pizza instance
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
        /// The ammount of slices in this MeatsPizza instance
        /// </summary>
        public uint Slices { get; set; } = 8;

        /// <summary>
        /// The price of the MeatsPizza instance
        /// </summary>
        public decimal Price 
        {
            get
            {
                decimal price = 15.99m;
                if (PizzaSize == Size.Small) price -= 2.00m;
                if (PizzaSize == Size.Large) price += 2.00m;
                if (PizzaCrust == Crust.DeepDish) price += 1.00m;
                return price;
            }
        }

        /// <summary>
        /// The calories per slice in the MeatsPizza instance
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint calories = 0;
                if (PizzaCrust == Crust.Thin) calories += 150;
                if (PizzaCrust == Crust.Original) calories += 250;
                if (PizzaCrust == Crust.DeepDish) calories += 300;
                if (Sausage) calories += 30;
                if (Ham) calories += 20;
                if (Bacon) calories += 20;
                if (Pepperoni) calories += 20;
                if (PizzaSize == Size.Small) return (uint)(calories * 0.75);
                if (PizzaSize == Size.Large) return (uint)(calories * 1.30);
                return calories;
            }
        }

        /// <summary>
        /// The total calories in the MeatsPizza instance
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the preperation for the MeatsPizza instance
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(PizzaSize.ToString());
                instructions.Add(PizzaCrust.ToString());
                if (!Sausage) instructions.Add("Hold Sausage");
                if (!Pepperoni) instructions.Add("Hold Pepperoni");
                if (!Bacon) instructions.Add("Hold Bacon");
                if (!Ham) instructions.Add("Hold Ham");
                return instructions;
            }
        }
    }
}
