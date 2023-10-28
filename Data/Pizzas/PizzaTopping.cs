using PizzaParlor.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data.Pizzas
{
    /// <summary>
    /// Class for the pizza toppings
    /// </summary>
    public class PizzaTopping : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Constructor for the pizza toppings
        /// </summary>
        /// <param name="t">The Topping</param>
        /// <param name="p">Whether or not it is on the pizza</param>
        public PizzaTopping(Topping t, bool p)
        {
            ToppingType = t;
            OnPizza = p;
        }

        /// <summary>
        /// Private backing field for the topping type method
        /// </summary>
        private Topping _toppingtype;

        /// <summary>
        /// Gets the topping type
        /// </summary>
        public Topping ToppingType
        {
            get { return _toppingtype; }
            init { _toppingtype = value; }
        }

        /// <summary>
        /// Private backing field for the on pizza method
        /// </summary>
        private bool _onpizza;

        /// <summary>
        /// Gets Whether if the topping is on the pizza
        /// </summary>
        public bool OnPizza
        {
            get 
            { 
                return _onpizza; 
            }
            set 
            {
                _onpizza = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OnPizza)));
            }
        }

        /// <summary>
        /// Gets the name of this pizza topping
        /// </summary>
        public string Name
        {
            get
            {
                switch (_toppingtype)
                {
                    case Topping.Sausage:
                        return "Sausage";
                    case Topping.Pepperoni:
                        return "Pepperoni";
                    case Topping.Ham:
                        return "Ham";
                    case Topping.Bacon:
                        return "Bacon";
                    case Topping.Olives:
                        return "Olives";
                    case Topping.Onions:
                        return "Onions";
                    case Topping.Mushrooms:
                        return "Mushrooms";
                    case Topping.Peppers:
                        return "Peppers";
                    case Topping.Pineapple:
                        return "Pineapple";
                    default:
                        return "Error";
                }
            }
        }

        /// <summary>
        /// Gets the calories for this pizza topping
        /// </summary>
        public uint BaseCalories
        {
            get
            {
                switch (_toppingtype)
                {
                    case Topping.Sausage:
                        return 30;
                    case Topping.Pepperoni:
                        return 20;
                    case Topping.Ham:
                        return 20;
                    case Topping.Bacon:
                        return 20;
                    case Topping.Olives:
                        return 5;
                    case Topping.Onions:
                        return 5;
                    case Topping.Mushrooms:
                        return 5;
                    case Topping.Peppers:
                        return 5;
                    case Topping.Pineapple:
                        return 10;
                    default:
                        return 0;
                }
            }
        }
    }
}
