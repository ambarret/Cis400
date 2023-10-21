namespace DataTests
{
    /// <summary>
    /// Unit Test for the BreadStick class
    /// </summary>
    public class BreadSticksUnitTests
    {
        #region Defaults
        /// <summary>
        /// Tests that the name for Breadsticks
        /// </summary>
        [Fact]
        public void NameIsBreadsticks()
        {
            BreadSticks b = new();
            Assert.Equal("Breadsticks", b.Name);
        }

        /// <summary>
        /// Tests that the ToString for Breadsticks
        /// </summary>
        [Fact]
        public void ToStringWorks()
        { 
            BreadSticks b = new();
            Assert.Equal("Breadsticks", b.ToString());
        }

        /// <summary>
        /// Tests the the Description is correct
        /// </summary>
        [Fact]
        public void DescriptionIsTheCorrectPhrase()
        {
            BreadSticks b = new();
            Assert.Equal("Soft buttery breadsticks", b.Description);
        }

        /// <summary>
        /// Tests that the default for cheese is false
        /// </summary>
        [Fact]
        public void CheesesDefaultFalse()
        {
            BreadSticks b  = new();
            Assert.False(b.Cheese);
        }

        /// <summary>
        /// Tests that the default is a SideCount of 8
        /// </summary>
        [Fact]
        public void DefaultSideCountIs8()
        {
            BreadSticks b = new();
            Assert.Equal((uint)8, b.SideCount);
        }

        /// <summary>
        /// Tests that the default calories is correct
        /// </summary>
        [Fact]
        public void DefaultCaloriesIs150()
        {
            BreadSticks b = new();
            Assert.Equal((uint)150, b.CaloriesPerEach);
            Assert.Equal((uint)8 * 150, b.CaloriesTotal);
        }

        /// <summary>
        /// Tests that the default price is correct
        /// </summary>
        [Fact]
        public void DefaultPriceIsCorrect()
        {
            BreadSticks b = new();
            Assert.Equal((decimal)0.75*8, b.Price);
        }

        #endregion
        #region State Changes

        /// <summary>
        /// This checks that breadsticks is correctly within the bounds of 4 and 12, this also checks that it will keep the previous value
        /// if the current value is out of bounds
        /// </summary>
        /// <param name="f">First tested value</param>
        /// <param name="s">Second tested value</param>
        /// <param name="e">expected value</param>
        [Theory]
        [InlineData(4,5,5)]
        [InlineData(12,11,11)]
        [InlineData(7,13,7)]
        [InlineData(12, 15, 12)]
        [InlineData(7,0,7)]
        [InlineData(0,15,8)]
        [InlineData(1,203,8)]
        [InlineData(uint.MinValue,uint.MaxValue, 8)]
        public void SideCountIsCorrectlyBounded(uint f,uint s, uint e)
        {
            BreadSticks b = new()
            {
                SideCount = f
            };
            b.SideCount = s;
            Assert.Equal(e, b.SideCount);
        }

        /// <summary>
        /// Tests that the Price will change when SideCount and cheese are changed
        /// </summary>
        /// <param name="c">The SideCount of breadsticks</param>
        /// <param name="cheese">Whether the breadsticks have cheese</param>
        /// <param name="price">The expected price for the sticks</param>
        [Theory]
        [InlineData(4,false,0.75 * 4)]
        [InlineData(4, true, 1 * 4)]
        [InlineData(12, false, 0.75 * 12)]
        [InlineData(12, true, 1 * 12)]
        [InlineData(8, false, 0.75 * 8)]
        [InlineData(8, true, 1 * 8)]
        [InlineData(5, false, 0.75 *5)]
        [InlineData(5, true, 1 * 5)]
        public void PriceAdjustsCorrectly(uint c, bool cheese, decimal price)
        {
            BreadSticks b = new()
            {
                Cheese = cheese,
                SideCount = c
            };
            Assert.Equal(price, b.Price);
        }

        /// <summary>
        /// Tests that the total ammount of calories change with the change of cheese and SideCount
        /// </summary>
        /// <param name="c">The SideCount of breadsticks</param>
        /// <param name="cheese">Wheather The sticks have cheese on them</param>
        /// <param name="cals">The expected Calories</param>
        [Theory]
        [InlineData(4,true, 4 * ( 150 + 50))]
        [InlineData(4, false, 4 * (150))]
        [InlineData(12, true, 12 * (150 + 50))]
        [InlineData(12, false, 12 * (150))]
        [InlineData(8, true, 8 * (150 + 50))]
        [InlineData(8, false, 8 * (150))]
        [InlineData(5, true, 5 * (150 + 50))]
        [InlineData(6, true, 6 * (150 + 50))]
        public void CaloriesAdjustsCorrectly(uint c, bool cheese, uint cals)
        {
            BreadSticks b = new()
            {
                Cheese = cheese,
                SideCount = c
            };
            Assert.Equal(cals, b.CaloriesTotal);
        }

        /// <summary>
        /// Tests that the special instructions are correct
        /// </summary>
        /// <param name="c">The SideCount of breadsticks</param>
        /// <param name="cheese">Wheather The sticks have cheese on them</param>
        /// <param name="instructions">The expected instructions for the breadsticks</param>
        [Theory]
        [InlineData(8,false,new string[] { "8 BreadSticks" })]
        [InlineData(8, true, new string[] { "8 CheeseSticks" })]
        [InlineData(12, false, new string[] { "12 BreadSticks" })]
        [InlineData(12, true, new string[] { "12 CheeseSticks" })]
        [InlineData(4, false, new string[] { "4 BreadSticks" })]
        [InlineData(4, true, new string[] { "4 CheeseSticks" })]
        [InlineData(5, false, new string[] { "5 BreadSticks" })]
        [InlineData(5, true, new string[] { "5 CheeseSticks" })]

        public void SpecialInstructionsAreCorrect(uint c, bool cheese, string[] instructions)
        {
            BreadSticks b = new()
            {
                Cheese = cheese,
                SideCount = c
            };

            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, b.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, b.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that it is assignable to side
        /// </summary>
        [Fact]
        public void IsASide()
        {
            BreadSticks b = new() { };
            Assert.IsAssignableFrom<Sides>(b);
        }
        #endregion

    }
}
