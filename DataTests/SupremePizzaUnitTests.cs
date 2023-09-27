namespace DataTests
{
    /// <summary>
    /// Testing class for Supreme Pizza
    /// </summary>
    public class SupremePizzaUnitTests
    {


        #region default values

        /// <summary>
        /// Tests that the name for Supreme Pizza
        /// </summary>
        [Fact]
        public void NameIsSupremePizza()
        {
            SupremePizza p = new SupremePizza();
            Assert.Equal("Supreme Pizza", p.Name);
        }

        /// <summary>
        /// Tests the the Description is correct
        /// </summary>
        [Fact]
        public void DescriptionIsTheCorrectPhrase()
        {
            SupremePizza p = new();
            Assert.Equal("Your standard supreme with meats and veggies", p.Description);
        }

        /// <summary>
        /// Tests that the default value is true
        /// </summary>
        [Fact]
        public void DefaultSizeIsMedium()
        {
            SupremePizza p = new();
            Assert.Equal(Size.Medium, p.PizzaSize);
        }

        /// <summary>
        /// Tests that the crust is original
        /// </summary>
        [Fact]
        public void DefaultCrustIsOriginal()
        {
            SupremePizza p = new();
            Assert.Equal(Crust.Original, p.PizzaCrust);
        }

        /// <summary>
        /// Tests that the number of slices is eight
        /// </summary>
        [Fact]
        public void DefaultSizeIsEight()
        {
            SupremePizza p = new();
            Assert.Equal((uint)8 , p.Slices);
        }

        /// <summary>
        /// Tests that the default calorieseach is 320
        /// </summary>
        [Fact]
        public void CaloriesPerEachIs320()
        {
            SupremePizza p = new();
            Assert.Equal((uint)320, p.CaloriesPerEach);
        }

        /// <summary>
        /// Tests that the whole pizza is 2560
        /// </summary>
        [Fact]
        public void TotalCaloriesIs2560()
        {
            SupremePizza p = new();
            Assert.Equal((uint)2560, p.CaloriesTotal);
        }
        #endregion

        #region  state Changes
        /// <summary>
        /// Tests that Calories per each is correct when values are changed
        /// </summary>
        /// <param name="sausage">Whether this SupremePizza instance contains sausage</param>
        /// <param name="pepperoni">Whether this SupremePizza instance contains pepperoni</param>
        /// <param name="olives">Whether this SupremePizza instance contains olives</param>
        /// <param name="peppers">Whether this SupremePizza instance contains peppers</param>
        /// <param name="onions">Whether this SupremePizza instance contains onions</param>
        /// <param name="mushrooms">Whether this SupremePizza instance contains mushrooms</param>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The crust of the pizza</param>
        /// <param name="cals">The ammount of calories expected</param>
        [Theory]
        [InlineData(true, true, true, true, true, true, Size.Medium, Crust.Original,
            250 + 30 + 20 + 5 + 5 + 5 + 5)]
        [InlineData(true, true, true, true, false, false, Size.Small, Crust.Thin,
            (uint)(0.75 * (150 + 30 + 20 + 5 + 5)))]
        [InlineData(false, true, false, true, false, true, Size.Large, Crust.DeepDish,
            (uint)(1.3 * (300 + 20 + 5 + 5)))]
        [InlineData(false, false, false, false, false, false, Size.Medium, Crust.Original,
            250)]
        [InlineData(false, false, false, false, false, false, Size.Medium, Crust.Thin,
            150)]
        [InlineData(false, false, false, false, false, false, Size.Medium, Crust.DeepDish,
            300)]
        [InlineData(true, true, false, true, false, true, Size.Medium, Crust.Original,
            250 + 30 + 20 + 5 + 5)]
        [InlineData(true, true, true, true, true, true, Size.Small, Crust.Original,
            (uint)(0.75 * (250 + 30 + 20 + 5 + 5 + 5 + 5)))]

        public void CaloriesPerEachTest(bool sausage, bool pepperoni, bool olives, bool peppers, bool onions,
                                bool mushrooms, Size s, Crust c, uint cals)
        {
            SupremePizza p = new SupremePizza(sausage,pepperoni,olives, peppers,onions,mushrooms)
            {
                PizzaSize = s,
                PizzaCrust = c
            };

            Assert.Equal(cals, p.CaloriesPerEach);


            
        }

        /// <summary>
        /// Checks that when the crust changes the price has also changed
        /// </summary>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The type of Crust</param>
        /// <param name="price">The expected price for the pizza</param>
        [Theory]
        [InlineData(Size.Medium, Crust.Original, 13.99)]
        [InlineData(Size.Small, Crust.Original, 11.99)]
        [InlineData(Size.Large, Crust.Original, 15.99)]
        [InlineData(Size.Small, Crust.DeepDish, 12.99)]
        [InlineData(Size.Medium, Crust.DeepDish, 14.99)]
        [InlineData(Size.Large, Crust.DeepDish, 16.99)]
        [InlineData(Size.Medium, Crust.Thin, 13.99)]
        [InlineData(Size.Small, Crust.Thin, 11.99)]
        public void PriceChangesWhenPizzaUpdates( Size s, Crust c, decimal price)
        {
            SupremePizza p = new SupremePizza
            {
                PizzaSize = s,
                PizzaCrust = c
            };
            Assert.Equal(price, p.Price);
        }

        /// <summary>
        /// Tests that the special instructions is correct
        /// </summary>
        /// <param name="sausage">Whether this SupremePizza instance contains sausage</param>
        /// <param name="pepperoni">Whether this SupremePizza instance contains pepperoni</param>
        /// <param name="olives">Whether this SupremePizza instance contains olives</param>
        /// <param name="peppers">Whether this SupremePizza instance contains peppers</param>
        /// <param name="onions">Whether this SupremePizza instance contains onions</param>
        /// <param name="mushrooms">Whether this SupremePizza instance contains mushrooms</param>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The crust of the pizza</param>
        /// <param name="instructions">expected instructions</param>
        [Theory]
        [InlineData(true, true, true, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Sausage", "Add Pepperoni", "Add Olives", "Add Onions", "Add Peppers", "Add Mushrooms" })]
        [InlineData(false, false, false, false, false, false, Size.Large, Crust.DeepDish, new string[] { "Large", "DeepDish"})]
        [InlineData(false, true, true, true, true, true, Size.Small, Crust.DeepDish, new string[] { "Small", "DeepDish", "Add Pepperoni", "Add Olives", "Add Onions", "Add Peppers", "Add Mushrooms" })]
        [InlineData(true, false, true, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Sausage", "Add Olives", "Add Onions", "Add Peppers", "Add Mushrooms" })]
        [InlineData(true, true, false, true, true, true, Size.Large, Crust.Thin, new string[] { "Large", "Thin", "Add Sausage", "Add Pepperoni", "Add Onions", "Add Peppers", "Add Mushrooms" })]
        [InlineData(true, true, true, false, true, true, Size.Small, Crust.Original, new string[] { "Small", "Original", "Add Sausage", "Add Pepperoni", "Add Olives", "Add Onions", "Add Mushrooms" })]
        [InlineData(true, true, true, true, false, true, Size.Medium, Crust.Thin, new string[] { "Medium", "Thin", "Add Sausage", "Add Pepperoni", "Add Olives", "Add Peppers", "Add Mushrooms" })]
        [InlineData(true, true, true, true, true, false, Size.Large, Crust.DeepDish, new string[] { "Large", "DeepDish", "Add Sausage", "Add Pepperoni", "Add Olives", "Add Onions", "Add Peppers" })]
        public void SpecialInstructionsAreCorrect(bool sausage, bool pepperoni, bool olives, bool peppers, bool onions,
                                bool mushrooms, Size s, Crust c, string[] instructions)
        {
            SupremePizza p = new SupremePizza(sausage, pepperoni, olives, peppers, onions, mushrooms)
            {
                PizzaSize = s,
                PizzaCrust = c
            };

            foreach (string instruction in instructions) 
            {
                Assert.Contains(instruction, p.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, p.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that it is assignable to Pizza
        /// </summary>
        [Fact]
        public void IsAPizza()
        {
            SupremePizza b = new() { };
            Assert.IsAssignableFrom<Pizza>(b);
        }
        #endregion
    }
}