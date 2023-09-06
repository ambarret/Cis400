using PizzaParlor.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data.Pizzas
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
        /// Private backing field for PizzaSize
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// The Size of this Hawaiian Pizza instance
        /// </summary>
        public Size PizzaSize 
        {
            get
            {
                return _size;
            }
            set
            {
                if( value == Size.Large) _size = Size.Large;
                if( value == Size.Medium) _size = Size.Medium;
                if( value == Size.Small) _size = Size.Small;   
            }
        }

        /// <summary>
        /// Private backing field for PizzaCrust
        /// </summary>
        private Crust _crust = Crust.Original;

        /// <summary>
        /// The Crust for this Hawaiian Pizza instance
        /// </summary>
        public Crust PizzaCrust
        {
            get
            {
                return _crust;
            }
            set
            {
                if(value == Crust.Thin) _crust = Crust.Thin;
                if(value == Crust.Original) _crust = Crust.Original;
                if(value == Crust.DeepDish) _crust = Crust.DeepDish;
            }
        }

        /// <summary>
        /// The ammount of slices in this HawaiianPizza instance
        /// </summary>
        public uint Slices { get; set; } = 8;

        /// <summary>
        /// The price of the HawaiianPizza instance
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal price = 13.99m;
                if (PizzaSize == Size.Small) price -= 2.00m;
                if (PizzaSize == Size.Large) price += 2.00m;
                if (PizzaCrust == Crust.DeepDish) price += 1.00m;
                return price;
            }
        }

        /// <summary>
        /// The calories per slice in the HawaiianPizza instance
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint calories = 0;
                if (PizzaCrust == Crust.Thin) calories += 150;
                if (PizzaCrust == Crust.Original) calories += 250;
                if (PizzaCrust == Crust.DeepDish) calories += 300;
                if (Ham) calories += 20;
                if (Pineapple) calories += 10;
                if (Onions) calories += 5;
                if (PizzaSize == Size.Small) return (uint)(calories * 0.75);
                if (PizzaSize == Size.Large) return (uint)(calories * 1.30);
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
                return CaloriesPerEach * Slices;
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
                instructions.Add(PizzaSize.ToString());
                instructions.Add(PizzaCrust.ToString());
                if (!Onions) instructions.Add("Hold Onions");
                if (!Pineapple) instructions.Add("Hold Pineapple");
                if (!Ham) instructions.Add("Hold Ham");
                return instructions;
            }
        }
    }
}
