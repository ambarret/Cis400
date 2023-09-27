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
    public class VeggiePizza : Pizza
    {
        public VeggiePizza(bool ol, bool p, bool on, bool m)
        {
            if(ol) AddTopping(Topping.Olives);
            if(p) AddTopping(Topping.Peppers);
            if(on) AddTopping(Topping.Onions);
            if(m) AddTopping(Topping.Mushrooms);
        }

        public VeggiePizza() 
        {
            AddTopping(Topping.Olives);
            AddTopping(Topping.Peppers);
            AddTopping(Topping.Onions);
            AddTopping(Topping.Mushrooms);
        }

        /// <summary>
        /// The name of the VeggiePizza instance
        /// </summary>
        public override string Name { get; } = "Veggie Pizza";

        /// <summary>
        /// The description of the VeggiePizza instance
        /// </summary>
        public override string Description { get; } = "All the veggies";

        /// <summary>
        /// The price of the VeggiePizza instance
        /// </summary>
        public override decimal Price
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
    }
}
