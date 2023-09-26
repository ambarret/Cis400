using PizzaParlor.Data.Enums;

namespace PizzaParlor.Data.Pizzas
{
    /// <summary>
    /// The definition of the SupremePizza class
    /// </summary>
    public class SupremePizza : IMenuItem
    {
        /// <summary>
        /// The name of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Supreme Pizza";

        /// <summary>
        /// The description of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description => "Your standard supreme with meats and veggies";

        /// <summary>
        /// Whether this SupremePizza instance contains sausage
        /// </summary>
        public bool Sausage { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains pepperoni
        /// </summary>
        public bool Pepperoni { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains olives
        /// </summary>
        public bool Olives { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains peppers
        /// </summary>
        public bool Peppers { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains mushrooms
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// Private backing field for PizzaSize
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// The Size of this Supreme Pizza instance
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
            }
        }

        /// <summary>
        /// Private backing field for PizzaCrust
        /// </summary>
        private Crust _crust = Crust.Original;

        /// <summary>
        /// The Crust for this Supreme Pizza instance
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
            }
        }

        /// <summary>
        /// The number of slices in this SupremePizza instance
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// The price of this SupremePizza instance
        /// </summary>
        public decimal Price
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

        /// <summary>
        /// The number of calories in each slice of this SupremePizza instance
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {

                uint cals = 0;
                if (PizzaCrust == Crust.Thin) cals += 150;
                if (PizzaCrust == Crust.Original) cals += 250;
                if (PizzaCrust == Crust.DeepDish) cals += 300;
                if (Sausage) cals += 30;
                if (Pepperoni) cals += 20;
                if (Olives) cals += 5;
                if (Peppers) cals += 5;
                if (Onions) cals += 5;
                if (Mushrooms) cals += 5;
                if (PizzaSize == Size.Small) return (uint)(cals * 0.75);
                if (PizzaSize == Size.Large) return (uint)(cals * 1.30);
                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this SupremePizza instance
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {

                return CaloriesPerEach * Slices;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this SupremePizza
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                instructions.Add(PizzaSize.ToString());
                instructions.Add(PizzaCrust.ToString());
                if (!Sausage) instructions.Add("Hold Sausage");
                if (!Pepperoni) instructions.Add("Hold Pepperoni");
                if (!Olives) instructions.Add("Hold Olives");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Onions) instructions.Add("Hold Onions");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                return instructions;
            }
        }
    }
}