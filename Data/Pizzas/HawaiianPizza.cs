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
    public class HawaiianPizza : Pizza
    {
        public HawaiianPizza(bool p, bool o, bool h)
        {
            if(p) AddTopping(Topping.Pineapple);
            if(o) AddTopping(Topping.Onions);
            if(h) AddTopping(Topping.Ham);
        }
        public HawaiianPizza()
        {
            AddTopping(Topping.Pineapple);
            AddTopping(Topping.Onions);
            AddTopping(Topping.Ham);
        }
        /// <summary>
        /// The name of the HawaiianPizza instance
        /// </summary>
        public override string Name { get; } = "Hawaiian Pizza";

        /// <summary>
        /// The description of the HawaiianPizza instance
        /// </summary>
        public override string Description { get; } = "The pizza with pineapple";

        /// <summary>
        /// The price of the HawaiianPizza instance
        /// </summary>
        public override decimal Price
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
    }
}
