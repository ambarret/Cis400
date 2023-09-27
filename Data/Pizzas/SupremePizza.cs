using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Pizzas
{
    /// <summary>
    /// The definition of the SupremePizza class
    /// </summary>
    public class SupremePizza : Pizza
    {
        public SupremePizza(bool s, bool pi, bool o, bool ps, bool on, bool m)
        {
            if (s) AddTopping(Topping.Sausage);
            if (pi) AddTopping(Topping.Pepperoni);
            if (o) AddTopping(Topping.Olives);
            if (ps) AddTopping(Topping.Peppers);
            if (on) AddTopping(Topping.Onions);
            if (m) AddTopping(Topping.Mushrooms);
        }

        public SupremePizza()
        {
            AddTopping(Topping.Sausage);
            AddTopping(Topping.Pepperoni);
            AddTopping(Topping.Olives);
            AddTopping(Topping.Peppers);
            AddTopping(Topping.Onions);
            AddTopping(Topping.Mushrooms);
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