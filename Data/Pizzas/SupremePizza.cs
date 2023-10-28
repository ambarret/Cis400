using PizzaParlor.Data.Enums;
using System.ComponentModel;

namespace PizzaParlor.Data.Pizzas
{
    /// <summary>
    /// The definition of the SupremePizza class
    /// </summary>
    public class SupremePizza : Pizza
    {

        public SupremePizza(bool s, bool pi, bool o, bool ps, bool on, bool m)
        {
            PossibleToppings.Clear();
            if (s) PossibleToppings.Add(new PizzaTopping(Topping.Sausage, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Sausage, false));
            if (pi) PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, false));
            if (o) PossibleToppings.Add(new PizzaTopping(Topping.Olives, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Olives, false));
            if (ps) PossibleToppings.Add(new PizzaTopping(Topping.Peppers, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Peppers, false));
            if (on) PossibleToppings.Add(new PizzaTopping(Topping.Onions, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Onions, false));
            if (m) PossibleToppings.Add(new PizzaTopping(Topping.Mushrooms, true));
            else PossibleToppings.Add(new PizzaTopping(Topping.Mushrooms, false));

            foreach (PizzaTopping p in PossibleToppings)
            {
                p.PropertyChanged += OnToppingChanged;
            }
        }


        public SupremePizza()
        {
            PossibleToppings.Clear();
            PossibleToppings.Add(new PizzaTopping(Topping.Sausage, true));
            PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, true));
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
        /// The name of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Supreme Pizza";

        /// <summary>
        /// The description of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Your standard supreme with meats and veggies";

        /// <summary>
        /// The price of this SupremePizza instance
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