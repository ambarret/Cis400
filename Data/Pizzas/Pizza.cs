using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Pizzas
{
    /// <summary>
    /// Class for Custom built pizzas
    /// </summary>
    public class Pizza : INotifyPropertyChanged, IMenuItem
    {
        public Pizza()
        {
            PossibleToppings.Add(new PizzaTopping(Topping.Sausage, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Ham, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Bacon, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Olives, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Onions, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Mushrooms, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Peppers, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Pineapple, false));

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Method to Invoke Property Changed
        /// </summary>
        /// <param name="propertyName">The Property to change</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Adds a topping to the Pizza
        /// </summary>
        /// <param name="t">The topping to add</param>
        public void AddTopping(Topping t)
        {
            PossibleToppings.Remove(new PizzaTopping(t, false));
            PossibleToppings.Remove(new PizzaTopping(t, true));
            PossibleToppings.Add(new PizzaTopping(t, true));

            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(SpecialInstructions));
            OnPropertyChanged(nameof(CaloriesPerEach));
            OnPropertyChanged(nameof(CaloriesTotal));

        }

        /// <summary>
        /// Removes a topping to the Pizza
        /// </summary>
        /// <param name="t">The topping to Remove</param>
        public void RemoveTopping(Topping t)
        {
            PizzaTopping search = new(t, true);
            if (PossibleToppings.Contains(search))
            {
                PossibleToppings.Remove(search);
                PossibleToppings.Add(new PizzaTopping(t, false));
            }

            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(SpecialInstructions));
            OnPropertyChanged(nameof(CaloriesPerEach));
            OnPropertyChanged(nameof(CaloriesTotal));
        }

        /// <summary>
        /// The name for this Pizza instance
        /// </summary>
        public virtual string Name { get; } = "Build-Your-Own Pizza";

        /// <summary>
        /// The Description for this pizza
        /// </summary>
        public virtual string Description { get; } = "A pizza you get to build";

        /// <summary>
        /// The ammount of slices in this pizza
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// Private backing field for PizzaSize
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// The Size of this Pizza instance
        /// </summary>
        public Size PizzaSize
        {
            get
            {
                return _size;
            }
            set
            {
                if (value == Size.Large) _size = Size.Large;
                if (value == Size.Medium) _size = Size.Medium;
                if (value == Size.Small) _size = Size.Small;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// Private backing field for PizzaCrust
        /// </summary>
        private Crust _crust = Crust.Original;

        /// <summary>
        /// The Crust for this Pizza instance
        /// </summary>
        public Crust PizzaCrust
        {
            get
            {
                return _crust;
            }
            set
            {
                if (value == Crust.Thin) _crust = Crust.Thin;
                if (value == Crust.Original) _crust = Crust.Original;
                if (value == Crust.DeepDish) _crust = Crust.DeepDish;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// List of the possible toppings for this pizza
        /// </summary>
        public List<PizzaTopping> PossibleToppings { get; } = new List<PizzaTopping>();

        /// <summary>
        /// The price of the pizza
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                decimal price = 9.99m;
                if (PizzaSize == Size.Small) price -= 2.00m;
                if (PizzaSize == Size.Large) price += 2.00m;
                if (PizzaCrust == Crust.DeepDish) price += 1.00m;
                foreach(PizzaTopping p in PossibleToppings)
                {
                    price += 1.00m;
                }
                return price;
            }
        }

        /// <summary>
        /// The ammount of calories per slice of pizza
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint calories = 0;
                if (PizzaCrust == Crust.Thin) calories += 150;
                if (PizzaCrust == Crust.Original) calories += 250;
                if (PizzaCrust == Crust.DeepDish) calories += 300;
                foreach(PizzaTopping p in PossibleToppings)
                {
                    if(p.OnPizza) calories += p.BaseCalories;
                }
                if (PizzaSize == Size.Small) return (uint)(calories * 0.75);
                if (PizzaSize == Size.Large) return (uint)(calories * 1.30);
                return calories;
            }
        }

        /// <summary>
        /// The total ammount of calories for the entire pizza
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {

                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// The Instructions to construct this pizza
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(PizzaSize.ToString());
                instructions.Add(PizzaCrust.ToString());
                foreach(PizzaTopping p in PossibleToppings)
                {
                    if(p.OnPizza)instructions.Add($"Add {p.Name}");
                }
                return instructions;
            }
        }

        /// <summary>
        /// Returns the name of the pizza instance
        /// </summary>
        /// <returns>The name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
