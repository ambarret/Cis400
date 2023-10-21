namespace DataTests
{
    /// <summary>
    /// Unit tests for the CinnamonSicks class
    /// </summary>
    public class CinnamonSticksUnitTests
    {
        #region Defaults
        /// <summary>
        /// Tests that the name for CinnamonSticks
        /// </summary>
        [Fact]
        public void NameIsCinnamonSticks()
        {
            CinnamonSticks b = new();
            Assert.Equal("Cinnamon Sticks", b.Name);
        }

        /// <summary>
        /// Tests that the ToString for CinnamonSticks
        /// </summary>
        [Fact]
        public void ToStringWorks()
        {
            CinnamonSticks b = new();
            Assert.Equal("Cinnamon Sticks", b.ToString());
        }

        /// <summary>
        /// Tests the the Description is correct
        /// </summary>
        [Fact]
        public void DescriptionIsTheCorrectPhrase()
        {
            CinnamonSticks b = new();
            Assert.Equal("Like breadsticks but for dessert", b.Description);
        }

        /// <summary>
        /// Tests that the default for Frosting is true
        /// </summary>
        [Fact]
        public void FrostingsDefaultTrue()
        {
            CinnamonSticks b = new();
            Assert.True(b.Frosting);
        }

        /// <summary>
        /// Tests that the default is a SideCount of 8
        /// </summary>
        [Fact]
        public void DefaultSideCountIs8()
        {
            CinnamonSticks b = new();
            Assert.Equal((uint)8, b.SideCount);
        }

        /// <summary>
        /// Tests that the default calories is correct
        /// </summary>
        [Fact]
        public void DefaultCaloriesIs150()
        {
            CinnamonSticks b = new();
            Assert.Equal((uint)190, b.CaloriesPerEach);
            Assert.Equal((uint)8 * 190, b.CaloriesTotal);
        }

        /// <summary>
        /// Tests that the default price is correct
        /// </summary>
        [Fact]
        public void DefaultPriceIsCorrect()
        {
            CinnamonSticks b = new();
            Assert.Equal((decimal)0.90 * 8, b.Price);
        }

        #endregion
        #region State Changes

        /// <summary>
        /// This checks that CinnamonSticks is correctly within the bounds of 4 and 12, this also checks that it will keep the previous value
        /// if the current value is out of bounds
        /// </summary>
        /// <param name="f">First tested value</param>
        /// <param name="s">Second tested value</param>
        /// <param name="e">expected value</param>
        [Theory]
        [InlineData(4, 5, 5)]
        [InlineData(12, 11, 11)]
        [InlineData(7, 13, 7)]
        [InlineData(12, 15, 12)]
        [InlineData(7, 0, 7)]
        [InlineData(0, 15, 8)]
        [InlineData(1, 203, 8)]
        [InlineData(uint.MinValue, uint.MaxValue, 8)]
        public void SideCountIsCorrectlyBounded(uint f, uint s, uint e)
        {
            CinnamonSticks b = new()
            {
                SideCount = f
            };
            b.SideCount = s;
            Assert.Equal(e, b.SideCount);
        }

        /// <summary>
        /// Tests that the Price will change when SideCount and Frosting are changed
        /// </summary>
        /// <param name="c">The SideCount of CinnamonSticks</param>
        /// <param name="frosting">Whether the CinnamonSticks have Frosting</param>
        /// <param name="price">The expected price for the sticks</param>
        [Theory]
        [InlineData(4, false, 0.75 * 4)]
        [InlineData(4, true, 0.90 * 4)]
        [InlineData(12, false, 0.75 * 12)]
        [InlineData(12, true, 0.90 * 12)]
        [InlineData(8, false, 0.75 * 8)]
        [InlineData(8, true, 0.90 * 8)]
        [InlineData(5, false, 0.75 * 5)]
        [InlineData(5, true, 0.90 * 5)]
        public void PriceAdjustsCorrectly(uint c, bool frosting, decimal price)
        {
            CinnamonSticks b = new()
            {
                Frosting = frosting,
                SideCount = c
            };
            Assert.Equal(price, b.Price);
        }

        /// <summary>
        /// Tests that the total ammount of calories change with the change of Frosting and SideCount
        /// </summary>
        /// <param name="c">The SideCount of CinnamonSticks</param>
        /// <param name="frosting">Wheather The sticks have Frosting on them</param>
        /// <param name="cals">The expected Calories</param>
        [Theory]
        [InlineData(4, true, 4 * (160 + 30))]
        [InlineData(4, false, 4 * (160))]
        [InlineData(12, true, 12 * (160 + 30))]
        [InlineData(12, false, 12 * (160))]
        [InlineData(8, true, 8 * (160 + 30))]
        [InlineData(8, false, 8 * (160))]
        [InlineData(5, true, 5 * (160 + 30))]
        [InlineData(6, true, 6 * (160 + 30))]
        public void CaloriesAdjustsCorrectly(uint c, bool frosting, uint cals)
        {
            CinnamonSticks b = new()
            {
                Frosting = frosting,
                SideCount = c
            };
            Assert.Equal(cals, b.CaloriesTotal);
        }

        /// <summary>
        /// Tests that the special instructions are correct
        /// </summary>
        /// <param name="c">The SideCount of CinnamonSticks</param>
        /// <param name="frosting">Wheather The sticks have Frosting on them</param>
        /// <param name="instructions">The expected instructions for the CinnamonSticks</param>
        [Theory]
        [InlineData(8, false, new string[] { "8 CinnamonSticks", "Hold Frosting" })]
        [InlineData(8, true, new string[] { "8 CinnamonSticks" })]
        [InlineData(12, false, new string[] { "12 CinnamonSticks", "Hold Frosting" })]
        [InlineData(12, true, new string[] { "12 CinnamonSticks" })]
        [InlineData(4, false, new string[] { "4 CinnamonSticks", "Hold Frosting" })]
        [InlineData(4, true, new string[] { "4 CinnamonSticks" })]
        [InlineData(5, false, new string[] { "5 CinnamonSticks", "Hold Frosting" })]
        [InlineData(5, true, new string[] { "5 CinnamonSticks" })]

        public void SpecialInstructionsAreCorrect(uint c, bool frosting, string[] instructions)
        {
            CinnamonSticks b = new()
            {
                Frosting = frosting,
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
            CinnamonSticks b = new() { };
            Assert.IsAssignableFrom<Sides>(b);
        }
        #endregion
    }
}
