namespace DataTests
{
    /// <summary>
    /// Testing class for Hawaiian Pizza
    /// </summary>
    public class HawaiianPizzaUnitTests
    {
        #region Defaults
        /// <summary>
        /// Tests that the name for Hawaiian Pizza
        /// </summary>
        [Fact]
        public void NameIsHawaiianPizza()
        {
            HawaiianPizza p = new HawaiianPizza();
            Assert.Equal("Hawaiian Pizza", p.Name);
        }

        /// <summary>
        /// Tests that the ToSting for Hawaiian Pizza
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            HawaiianPizza p = new HawaiianPizza();
            Assert.Equal("Hawaiian Pizza", p.ToString());
        }

        /// <summary>
        /// Tests the the Description is correct
        /// </summary>
        [Fact]
        public void DescriptionIsTheCorrectPhrase()
        {
            HawaiianPizza p = new();
            Assert.Equal("The pizza with pineapple", p.Description);
        }

        /// <summary>
        /// Tests that the default value is true
        /// </summary>
        [Fact]
        public void DefaultSizeIsMedium()
        {
            HawaiianPizza p = new();
            Assert.Equal(Size.Medium, p.PizzaSize);
        }

        /// <summary>
        /// Tests that the crust is original
        /// </summary>
        [Fact]
        public void DefaultCrustIsOriginal()
        {
            HawaiianPizza p = new();
            Assert.Equal(Crust.Original, p.PizzaCrust);
        }

        /// <summary>
        /// Tests that the number of slices is eight
        /// </summary>
        [Fact]
        public void DefaultSizeIsEight()
        {
            HawaiianPizza p = new();
            Assert.Equal((uint)8, p.Slices);
        }

        /// <summary>
        /// Tests that the default calorieseach is 285
        /// </summary>
        [Fact]
        public void CaloriesPerEachIs285()
        {
            HawaiianPizza p = new();
            Assert.Equal((uint)285, p.CaloriesPerEach);
        }

        /// <summary>
        /// Tests that the whole pizza is 2280
        /// </summary>
        [Fact]
        public void TotalCaloriesIs2280()
        {
            HawaiianPizza p = new();
            Assert.Equal((uint)2280, p.CaloriesTotal);
        }

        #endregion
        #region StateChanges

        /// <summary>
        /// Tests that Calories per each is correct when values are changed
        /// </summary>
        /// <param name="pineapple">Whether this HawaiianPizza instance contains pineapple</param>
        /// <param name="ham">Whether this HawaiianPizza instance contains ham</param>
        /// <param name="onions">Whether this HawaiianPizza instance contains onions</param>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The crust of the pizza</param>
        /// <param name="cals">The ammount of calories expected</param>
        [Theory]
        [InlineData(true, true, true, Size.Medium, Crust.Original,
            250 + 20 + 10 + 5)]
        [InlineData(true, true, false, Size.Small, Crust.Thin,
            (uint)(0.75 * (150 + 20 + 10)))]
        [InlineData(false, true, false,  Size.Large, Crust.DeepDish,
            (uint)(1.3 * (300 + 20)))]
        [InlineData(false, false, false, Size.Medium, Crust.Original,
            250)]
        [InlineData(false, false, false, Size.Medium, Crust.Thin,
            150)]
        [InlineData(false, false, false, Size.Medium, Crust.DeepDish,
            300)]
        [InlineData(false, true, false, Size.Medium, Crust.Original,
            250 + 20)]
        [InlineData(true, true, true, Size.Small, Crust.Original,
            (uint)(0.75 * (250 + 20 + 10 + 5)))]

        public void CaloriesPerEachTest(bool pineapple, bool ham, bool onions,
                                 Size s, Crust c, uint cals)
        {
            HawaiianPizza p = new HawaiianPizza(pineapple, onions, ham);

            p.PizzaSize = s;
            p.PizzaCrust = c;
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
        [InlineData(Size.Small, Crust.Original, 13.99 - 2.00)]
        [InlineData(Size.Large, Crust.Original, 13.99 + 2.00)]
        [InlineData(Size.Small, Crust.DeepDish, 13.99 - 2.00 + 1.00)]
        [InlineData(Size.Medium, Crust.DeepDish, 13.99 + 1.00)]
        [InlineData(Size.Large, Crust.DeepDish, 13.99 + 2.00 + 1.00)]
        [InlineData(Size.Medium, Crust.Thin, 13.99)]
        [InlineData(Size.Small, Crust.Thin, 13.99 - 2.00)]
        public void PriceChangesWhenPizzaUpdates(Size s, Crust c, decimal price)
        {
            HawaiianPizza p = new HawaiianPizza
            {
                PizzaSize = s,
                PizzaCrust = c
            };
            Assert.Equal(price, p.Price);
        }


        /// <summary>
        /// Tests that the special instructions is correct
        /// </summary>
        /// <param name="pineapple">Whether this HawaiianPizza instance contains pineapple</param>
        /// <param name="ham">Whether this HawaiianPizza instance contains ham</param>
        /// <param name="onions">Whether this HawaiianPizza instance contains onions</param>
        /// <param name="s">The size of the pizza</param>
        /// <param name="c">The crust of the pizza</param>
        /// <param name="instructions">expected instructions</param>
        [Theory]
        [InlineData(true, true, true, Size.Medium, Crust.Original, new string[] { "Medium", "Original", "Add Pineapple", "Add Ham", "Add Onions" })]
        [InlineData(false, false, false, Size.Large, Crust.DeepDish, new string[] { "Large", "DeepDish" })]
        [InlineData(true, true, true, Size.Small, Crust.DeepDish, new string[] { "Small", "DeepDish", "Add Pineapple", "Add Ham", "Add Onions" })]
        [InlineData(true, true, true, Size.Medium, Crust.Thin, new string[] { "Medium", "Thin", "Add Pineapple", "Add Ham", "Add Onions" })]
        [InlineData(false, true, true, Size.Large, Crust.Thin, new string[] { "Large", "Thin", "Add Ham", "Add Onions" })]
        [InlineData(true, false, true, Size.Small, Crust.Original, new string[] { "Small", "Original", "Add Pineapple", "Add Onions" })]
        [InlineData(true, true, false, Size.Medium, Crust.Thin, new string[] { "Medium", "Thin", "Add Pineapple", "Add Ham" })]
        [InlineData(true, true, true, Size.Large, Crust.DeepDish, new string[] { "Large", "DeepDish", "Add Pineapple", "Add Ham", "Add Onions" })]
        public void SpecialInstructionsAreCorrect(bool pineapple, bool ham, bool onions,
                                 Size s, Crust c, string[] instructions)
        {
            HawaiianPizza p = new HawaiianPizza(pineapple, onions, ham)
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
            HawaiianPizza b = new() { };
            Assert.IsAssignableFrom<Pizza>(b);
        }
        #endregion
    }
}
