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
            PossibleToppings.Clear();
            if (p) PossibleToppings.Add(new PizzaTopping(Topping.Pineapple, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Pineapple, false));
            if (h) PossibleToppings.Add(new PizzaTopping(Topping.Ham, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Ham, false));
            if (o) PossibleToppings.Add(new PizzaTopping(Topping.Onions, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Onions, false));


            foreach (PizzaTopping pi in PossibleToppings)
            {
                pi.PropertyChanged += OnToppingChanged;
            }
        }


        public HawaiianPizza()
        {
            PossibleToppings.Clear();
            PossibleToppings.Add(new PizzaTopping(Topping.Pineapple, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Onions, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Ham, true));


            foreach (PizzaTopping p in PossibleToppings)
            {
                p.PropertyChanged += OnToppingChanged;
            }
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
