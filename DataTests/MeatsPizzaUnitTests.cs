namespace DataTests
{
    /// <summary>
    /// Testing class for Meats Pizza
    /// </summary>
    public class MeatsPizzaUnitTests
    {
        #region Defaults
        /// <summary>
        /// Tests that the name for Meats Pizza
        /// </summary>
        [Fact]
        public void NameIsMeatsPizza()
        {
            MeatsPizza p = new MeatsPizza();
            Assert.Equal("Meats Pizza", p.Name);
        }

        /// <summary>
        /// Tests the the Description is correct
        /// </summary>
        [Fact]
        public void DescriptionIsTheCorrectPhrase()
        {
            MeatsPizza p = new();
            Assert.Equal("All the meats", p.Description);
        }

        /// <summary>
        /// Tests that the default value is true
        /// </summary>
        [Fact]
        public void DefaultSizeIsMedium()
        {
            MeatsPizza p = new();
            Assert.Equal(Size.Medium, p.PizzaSize);
        }

        /// <summary>
        /// Tests that the crust is original
        /// </summary>
        [Fact]
        public void DefaultCrustIsOriginal()
        {
            MeatsPizza p = new();
            Assert.Equal(Crust.Original, p.PizzaCrust);
        }

        /// <summary>
        /// Tests that the number of slices is eight
        /// </summary>
        [Fact]
        public void DefaultSizeIsEight()
        {
            MeatsPizza p = new();
            Assert.Equal((uint)8, p.Slices);
        }

        /// <summary>
        /// Tests that the default calorieseach is 340
        /// </summary>
        [Fact]
        public void CaloriesPerEachIs340()
        {
            MeatsPizza p = new();
            Assert.Equal((uint)340, p.CaloriesPerEach);
        }

        /// <summary>
        /// Tests that the whole pizza is 2720
        /// </summary>
        [Fact]
        public void TotalCaloriesIs2720()
        {
            MeatsPizza p = new();
            Assert.Equal((uint)2720, p.CaloriesTotal);
        }

        #endregion
        #region StateChanges

        /// <summary>
        /// Tests that Calories per each is correct when values are changed
        /// </summary>
        /// <param name="sausage">Whether this MeatsPizza instance contains sausage</param>
        /// <param name="ham">Whether this MeatsPizza instance contains ham</param>
        /// <param name="bacon">Whether this MeatsPizza instance contains bacon</param>
        /// <param name="pepperoni">Whether this MeatsPizza instance contains pepperoni</param>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The crust of the pizza</param>
        /// <param name="cals">The ammount of calories expected</param>
        [Theory]
        [InlineData(true, true, true, true, Size.Medium, Crust.Original,
            250 + 30 + 20 + 20 + 20)]
        [InlineData(true, true, false, false, Size.Small, Crust.Thin,
            (uint)(0.75 * (150 + 30 + 20)))]
        [InlineData(false, true, false, true, Size.Large, Crust.DeepDish,
            (uint)(1.3 * (300 + 20 + 20)))]
        [InlineData(false, false, false, false, Size.Medium, Crust.Original,
            250)]
        [InlineData(false, false, false, false, Size.Medium, Crust.Thin,
            150)]
        [InlineData(false, false, false, false, Size.Medium, Crust.DeepDish,
            300)]
        [InlineData(false, true, false, true, Size.Medium, Crust.Original,
            250 + 20 + 20)]
        [InlineData(true, true, true, true, Size.Small, Crust.Original,
            (uint)(0.75 * (250 + 30 + 20 + 20 + 20)))]

        public void CaloriesPerEachTest(bool sausage, bool ham, bool bacon,
                                bool pepperoni, Size s, Crust c, uint cals)
        {
            MeatsPizza p = new MeatsPizza(sausage,ham, bacon, pepperoni) 
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
        [InlineData(Size.Medium, Crust.Original, 15.99)]
        [InlineData(Size.Small, Crust.Original, 15.99 - 2.00)]
        [InlineData(Size.Large, Crust.Original, 15.99 + 2.00)]
        [InlineData(Size.Small, Crust.DeepDish, 15.99 - 2.00 + 1.00)]
        [InlineData(Size.Medium, Crust.DeepDish, 15.99 + 1.00)]
        [InlineData(Size.Large, Crust.DeepDish, 15.99 + 2.00 + 1.00)]
        [InlineData(Size.Medium, Crust.Thin, 15.99)]
        [InlineData(Size.Small, Crust.Thin, 15.99 - 2.00)]
        public void PriceChangesWhenPizzaUpdates(Size s, Crust c, decimal price)
        {
            MeatsPizza p = new MeatsPizza
            {
                PizzaSize = s,
                PizzaCrust = c
            };
            Assert.Equal(price, p.Price);
        }


        /// <summary>
        /// Tests that the special instructions is correct
        /// </summary>
        /// <param name="sausage">Whether this MeatsPizza instance contains sausage</param>
        /// <param name="ham">Whether this MeatsPizza instance contains ham</param>
        /// <param name="bacon">Whether this MeatsPizza instance contains bacon</param>
        /// <param name="pepperoni">Whether this MeatsPizza instance contains pepperoni</param>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The crust of the pizza</param>
        /// <param name="instructions">expected instructions</param>
        [Theory]
        [InlineData(true, true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Sausage", "Add Ham", "Add Bacon", "Add Pepperoni" })]
        [InlineData(false, false, false, false, Size.Large, Crust.DeepDish, new string[] { "Large", "DeepDish"})]
        [InlineData(true, true, true, true, Size.Small, Crust.DeepDish, new string[] { "Small", "DeepDish", "Add Sausage", "Add Ham", "Add Bacon", "Add Pepperoni" })]
        [InlineData(true, true, true, true, Size.Medium, Crust.Thin, new string[] { "Medium", "Thin", "Add Sausage", "Add Ham", "Add Bacon", "Add Pepperoni" })]
        [InlineData(false, true, true, true, Size.Large, Crust.Thin, new string[] { "Large", "Thin", "Add Ham", "Add Bacon", "Add Pepperoni" })]
        [InlineData(true, false, true, true, Size.Small, Crust.Original, new string[] { "Small", "Original", "Add Sausage", "Add Bacon", "Add Pepperoni" })]
        [InlineData(true, true, false, true, Size.Medium, Crust.Thin, new string[] { "Medium", "Thin", "Add Sausage", "Add Ham", "Add Pepperoni" })]
        [InlineData(true, true, true, false, Size.Large, Crust.DeepDish, new string[] { "Large", "DeepDish", "Add Sausage", "Add Ham", "Add Bacon" })]
        public void SpecialInstructionsAreCorrect(bool sausage, bool ham, bool bacon,
                                bool pepperoni, Size s, Crust c, string[] instructions)
        {
            MeatsPizza p = new MeatsPizza (sausage, ham, bacon, pepperoni)
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
            MeatsPizza b = new() { };
            Assert.IsAssignableFrom<Pizza>(b);
        }
        #endregion
    }
}
