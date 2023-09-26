namespace DataTests
{
    public class IceTeaUnitTests
    {
        #region Defaults

        /// <summary>
        /// Tests that the name is IcedTea
        /// </summary>
        [Fact]
        public void DefaultNameIsIcedTea()
        {
            IcedTea s = new();
            Assert.Equal("Iced Tea", s.Name);
        }

        /// <summary>
        /// Tests that the description is correct
        /// </summary>
        [Fact]
        public void DefaultDescriptionIsCorrect()
        {
            IcedTea s = new();
            Assert.Equal("Freshly brewed sweet tea", s.Description);
        }

        /// <summary>
        /// Tests that the Ice bool is true
        /// </summary>
        [Fact]
        public void DefaultIceIsTrue()
        {
            IcedTea s = new();
            Assert.True(s.Ice);
        }

        /// <summary>
        /// Tests that the default size is medium
        /// </summary>
        [Fact]
        public void DefaultSizeIsMedium()
        {
            IcedTea s = new();
            Assert.Equal(Size.Medium, s.DrinkSize);
        }

        #endregion
        #region State Changes

        /// <summary>
        /// Tests that the size can change
        /// </summary>
        /// <param name="size">The size to change</param>
        [Theory]
        [InlineData(Size.Medium)]
        [InlineData(Size.Small)]
        [InlineData(Size.Large)]
        public void SizeCanChange(Size size)
        {
            IcedTea s = new()
            {
                DrinkSize = size,
            };
            Assert.Equal(size, s.DrinkSize);
        }

        /// <summary>
        /// Tests that the price adjusts to the Iced Tea instance
        /// </summary>
        /// <param name="size">The size to change</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(Size.Medium, 2.50)]
        [InlineData(Size.Small, 2.00)]
        [InlineData(Size.Large, 3.00)]
        public void PriceCanChange(Size size, double price)
        {
            IcedTea s = new()
            {
                DrinkSize = size,
            };

            Assert.Equal(price, (double)s.Price);
        }

        /// <summary>
        /// Tests that the price adjusts to the Iced Tea instance
        /// </summary>
        /// <param name="size">The size to change</param>
        /// <param name="calories">The expected Calories</param>
        [Theory]
        [InlineData(Size.Medium, 220)]
        [InlineData(Size.Small, 175)]
        [InlineData(Size.Large, 275)]
        public void CaloriesCanChange(Size size, uint calories)
        {
            IcedTea s = new()
            {
                DrinkSize = size,
            };
            Assert.Equal(calories, (uint)s.CaloriesTotal);
        }

        /// <summary>
        /// Tests that the special instructions are correct
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="ice">Whether the Tea has ice in it</param>
        /// <param name="instructions">The expected instructions</param>
        [Theory]
        [InlineData(Size.Medium, true, new string[] {"Medium"})]
        [InlineData(Size.Medium, false, new string[] { "Medium", "Hold Ice" })]
        [InlineData(Size.Large, true, new string[] { "Large" })]
        [InlineData(Size.Large, false, new string[] { "Large", "Hold Ice" })]
        [InlineData(Size.Small, false, new string[] { "Small" , "Hold Ice" })]
        [InlineData(Size.Small, true, new string[] { "Small" })]
        public void SpecialInstructionsAreCorrect(Size size, bool ice, string[] instructions)
        {
            IcedTea s = new()
            {
                DrinkSize = size,
                Ice = ice
            };
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, s.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, s.SpecialInstructions.Count());
        }
        #endregion
    }
}
