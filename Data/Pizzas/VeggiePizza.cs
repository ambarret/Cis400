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
            PossibleToppings.Clear();
            if (ol) PossibleToppings.Add(new PizzaTopping(Topping.Olives, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Olives, false));
            if (p) PossibleToppings.Add(new PizzaTopping(Topping.Peppers, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Peppers, false));
            if (on) PossibleToppings.Add(new PizzaTopping(Topping.Onions, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Onions, false));
            if (m) PossibleToppings.Add(new PizzaTopping(Topping.Mushrooms, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Mushrooms, false));

            
            foreach(PizzaTopping pi in PossibleToppings)
            {
                pi.PropertyChanged += OnToppingChanged;
            }
        }

        public VeggiePizza() 
        {
            PossibleToppings.Clear();
            PossibleToppings.Add(new PizzaTopping(Topping.Olives, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Peppers, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Onions, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Mushrooms, true));

            foreach (PizzaTopping p in PossibleToppings)
            {
                p.PropertyChanged += OnToppingChanged;
            }
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
