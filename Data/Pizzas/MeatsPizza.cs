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
    public class MeatsPizza : Pizza
    {

        public MeatsPizza(bool s, bool h, bool b, bool p)
        {
            PossibleToppings.Clear();
            if (s) PossibleToppings.Add(new PizzaTopping(Topping.Sausage, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Sausage, false));
            if (p) PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, false));
            if (b) PossibleToppings.Add(new PizzaTopping(Topping.Bacon, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Bacon, false));
            if (h) PossibleToppings.Add(new PizzaTopping(Topping.Ham, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Ham, false));


            foreach (PizzaTopping pi in PossibleToppings)
            {
                pi.PropertyChanged += OnToppingChanged;
            }
        }


        public MeatsPizza() 
        {
            PossibleToppings.Clear();
            PossibleToppings.Add(new PizzaTopping(Topping.Sausage, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Ham, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Bacon, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, true));


            foreach (PizzaTopping p in PossibleToppings)
            {
                p.PropertyChanged += OnToppingChanged;
            }
        }

        /// <summary>
        /// The name of the MeatsPizza instance
        /// </summary>
        public override string Name { get; } = "Meats Pizza";

        /// <summary>
        /// The description of the MeatsPizza instance
        /// </summary>
        public override string Description { get; } = "All the meats";


        /// <summary>
        /// The price of the MeatsPizza instance
        /// </summary>
        public override decimal Price 
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
    }
}
