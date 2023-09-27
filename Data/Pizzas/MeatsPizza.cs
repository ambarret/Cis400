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
            if(s) AddTopping(Topping.Sausage);
            if(h) AddTopping(Topping.Ham);
            if(b) AddTopping(Topping.Bacon);
            if(p) AddTopping(Topping.Pepperoni);
        }
        public MeatsPizza() 
        {
            AddTopping(Topping.Sausage);
            AddTopping(Topping.Ham);
            AddTopping(Topping.Bacon);
            AddTopping(Topping.Pepperoni);
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
