namespace DataTests
{
    /// <summary>
    /// Testing class for Veggie Pizza
    /// </summary>
    public class VeggiePizzaUnitTests
    {
        #region Defaults
        /// <summary>
        /// Tests that the name for Veggie Pizza
        /// </summary>
        [Fact]
        public void NameIsVeggiePizza()
        {
            VeggiePizza p = new VeggiePizza();
            Assert.Equal("Veggie Pizza", p.Name);
        }

        /// <summary>
        /// Tests that the ToString for Veggie Pizza
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            VeggiePizza p = new VeggiePizza();
            Assert.Equal("Veggie Pizza", p.ToString());
        }

        /// <summary>
        /// Tests the the Description is correct
        /// </summary>
        [Fact]
        public void DescriptionIsTheCorrectPhrase()
        {
            VeggiePizza p = new();
            Assert.Equal("All the veggies", p.Description);
        }

        /// <summary>
        /// Tests that the default value is true
        /// </summary>
        [Fact]
        public void DefaultSizeIsMedium()
        {
            VeggiePizza p = new();
            Assert.Equal(Size.Medium, p.PizzaSize);
        }

        /// <summary>
        /// Tests that the crust is original
        /// </summary>
        [Fact]
        public void DefaultCrustIsOriginal()
        {
            VeggiePizza p = new();
            Assert.Equal(Crust.Original, p.PizzaCrust);
        }

        /// <summary>
        /// Tests that the number of slices is eight
        /// </summary>
        [Fact]
        public void DefaultSizeIsEight()
        {
            VeggiePizza p = new();
            Assert.Equal((uint)8, p.Slices);
        }

        /// <summary>
        /// Tests that the default calorieseach is 270
        /// </summary>
        [Fact]
        public void CaloriesPerEachIs270()
        {
            VeggiePizza p = new();
            Assert.Equal((uint)270, p.CaloriesPerEach);
        }

        /// <summary>
        /// Tests that the whole pizza is 2160
        /// </summary>
        [Fact]
        public void TotalCaloriesIs2160()
        {
            VeggiePizza p = new();
            Assert.Equal((uint)2160, p.CaloriesTotal);
        }

        #endregion
        #region StateChanges

        /// <summary>
        /// Tests that Calories per each is correct when values are changed
        /// </summary>
        /// <param name="olives">Whether this VeggiePizza instance contains olives</param>
        /// <param name="peppers">Whether this VeggiePizza instance contains peppers</param>
        /// <param name="onions">Whether this VeggiePizza instance contains onions</param>
        /// <param name="mushrooms">Whether this VeggiePizza instance contains mushrooms</param>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The crust of the pizza</param>
        /// <param name="cals">The ammount of calories expected</param>
        [Theory]
        [InlineData( true, true, true, true, Size.Medium, Crust.Original,
            250 + 5 + 5 + 5 + 5)]
        [InlineData( true, true, false, false, Size.Small, Crust.Thin,
            (uint)(0.75 * (150 + 5 + 5)))]
        [InlineData( false, true, false, true, Size.Large, Crust.DeepDish,
            (uint)(1.3 * (300 +  5 + 5)))]
        [InlineData( false, false, false, false, Size.Medium, Crust.Original,
            250)]
        [InlineData( false, false, false, false, Size.Medium, Crust.Thin,
            150)]
        [InlineData( false, false, false, false, Size.Medium, Crust.DeepDish,
            300)]
        [InlineData( false, true, false, true, Size.Medium, Crust.Original,
            250 + 5 + 5)]
        [InlineData( true, true, true, true, Size.Small, Crust.Original,
            (uint)(0.75 * (250 + 5 + 5 + 5 + 5)))]

        public void CaloriesPerEachTest(bool olives, bool peppers, bool onions,
                                bool mushrooms, Size s, Crust c, uint cals)
        {
            VeggiePizza p = new VeggiePizza(olives, peppers, onions, mushrooms)
            {
                PizzaCrust = c,
                PizzaSize= s
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
        [InlineData(Size.Medium, Crust.Original, 12.99)]
        [InlineData(Size.Small, Crust.Original, 12.99 - 2.00)]
        [InlineData(Size.Large, Crust.Original, 12.99 + 2.00)]
        [InlineData(Size.Small, Crust.DeepDish, 12.99 - 2.00 + 1.00)]
        [InlineData(Size.Medium, Crust.DeepDish, 12.99 + 1.00)]
        [InlineData(Size.Large, Crust.DeepDish, 12.99 + 2.00 + 1.00)]
        [InlineData(Size.Medium, Crust.Thin, 12.99)]
        [InlineData(Size.Small, Crust.Thin, 12.99 - 2.00)]
        public void PriceChangesWhenPizzaUpdates(Size s, Crust c, decimal price)
        {
            VeggiePizza p = new VeggiePizza
            {
                PizzaSize = s,
                PizzaCrust = c
            };
            Assert.Equal(price, p.Price);
        }


        /// <summary>
        /// Tests that the special instructions is correct
        /// </summary>
        /// <param name="olives">Whether this VeggiePizza instance contains olives</param>
        /// <param name="peppers">Whether this VeggiePizza instance contains peppers</param>
        /// <param name="onions">Whether this VeggiePizza instance contains onions</param>
        /// <param name="mushrooms">Whether this VeggiePizza instance contains mushrooms</param>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The crust of the pizza</param>
        /// <param name="instructions">expected instructions</param>
        [Theory]
        [InlineData( true, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Olives", "Add Onions", "Add Peppers", "Add Mushrooms" })]
        [InlineData( false, false, false, false, Size.Large, Crust.DeepDish, new string[] { "Large", "DeepDish" })]
        [InlineData( true, true, true, true, Size.Small, Crust.DeepDish, new string[] { "Small", "DeepDish", "Add Olives", "Add Onions", "Add Peppers", "Add Mushrooms" })]
        [InlineData( true, true, true, true, Size.Medium, Crust.Thin, new string[] { "Medium", "Thin", "Add Olives", "Add Onions", "Add Peppers", "Add Mushrooms" })]
        [InlineData( false, true, true, true, Size.Large, Crust.Thin, new string[] { "Large", "Thin", "Add Onions", "Add Peppers", "Add Mushrooms" })]
        [InlineData( true, false, true, true, Size.Small, Crust.Original, new string[] { "Small", "Original", "Add Olives", "Add Onions", "Add Mushrooms" })]
        [InlineData( true, true, false, true, Size.Medium, Crust.Thin, new string[] { "Medium", "Thin", "Add Olives", "Add Peppers", "Add Mushrooms" })]
        [InlineData( true, true, true, false, Size.Large, Crust.DeepDish, new string[] { "Large", "DeepDish", "Add Olives", "Add Onions", "Add Peppers" })]
        public void SpecialInstructionsAreCorrect( bool olives, bool peppers, bool onions,
                                bool mushrooms, Size s, Crust c, string[] instructions)
        {
            VeggiePizza p = new VeggiePizza(olives, peppers, onions, mushrooms)
            {
                PizzaCrust = c,
                PizzaSize = s
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
            VeggiePizza b = new() { };
            Assert.IsAssignableFrom<Pizza>(b);
        }
        #endregion

    }
}
