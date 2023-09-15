using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Unit Tests for the Garlic Knots class
    /// </summary>
    public class GarlicKnotsUnitTests
    {
        #region Defaults
            /// <summary>
            /// Tests that the name for GarlicKnots
            /// </summary>
            [Fact]
            public void NameIsGarlicKnots()
            {
                GarlicKnots b = new();
                Assert.Equal("Garlic Knots", b.Name);
            }

            /// <summary>
            /// Tests the the Description is correct
            /// </summary>
            [Fact]
            public void DescriptionIsTheCorrectPhrase()
            {
                GarlicKnots b = new();
                Assert.Equal("Twisted rolls with garlic and butter", b.Description);
            }

            /// <summary>
            /// Tests that the default is a count of 8
            /// </summary>
            [Fact]
            public void DefaultCountIs8()
            {
                GarlicKnots b = new();
                Assert.Equal((uint)8, b.Count);
            }

            /// <summary>
            /// Tests that the default calories is correct
            /// </summary>
            [Fact]
            public void DefaultCaloriesIs150()
            {
                GarlicKnots b = new();
                Assert.Equal((uint)175, b.CaloriesPerEach);
                Assert.Equal((uint)8 * 175, b.CaloriesTotal);
            }

            /// <summary>
            /// Tests that the default price is correct
            /// </summary>
            [Fact]
            public void DefaultPriceIsCorrect()
            {
                GarlicKnots b = new();
                Assert.Equal((decimal)0.75 * 8, b.Price);
            }

            #endregion
            #region State Changes

            /// <summary>
            /// This checks that GarlicKnots is correctly within the bounds of 4 and 12, this also checks that it will keep the previous value
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
            public void CountIsCorrectlyBounded(uint f, uint s, uint e)
            {
                GarlicKnots b = new()
                {
                    Count = f
                };
                b.Count = s;
                Assert.Equal(e, b.Count);
            }

            /// <summary>
            /// Tests that the Price will change when count and cheese are changed
            /// </summary>
            /// <param name="c">The count of GarlicKnots</param>
            /// <param name="price">The expected price for the sticks</param>
            [Theory]
            [InlineData(4, 0.75 * 4)]
            [InlineData(12, 0.75 * 12)]
            [InlineData(8,  0.75 * 8)]
            [InlineData(5, 0.75 * 5)]
            [InlineData(6, 0.75 * 6)]
            [InlineData(7, 0.75 * 7)]
            [InlineData(9, 0.75 * 9)]
            [InlineData(11, 0.75 * 11)]

            public void PriceAdjustsCorrectly(uint c, decimal price)
            {
                GarlicKnots b = new()
                {
                    Count = c
                };
                Assert.Equal(price, b.Price);
            }

            /// <summary>
            /// Tests that the total ammount of calories change with the change of cheese and count
            /// </summary>
            /// <param name="c">The count of GarlicKnots</param>
            /// <param name="cals">The expected Calories</param>
            [Theory]
            [InlineData(4, 175 * 4)]
            [InlineData(12, 175 * 12)]
            [InlineData(8, 175 * 8)]
            [InlineData(5, 175 * 5)]
            [InlineData(6, 175 * 6)]
            [InlineData(7, 175 * 7)]
            [InlineData(9, 175 * 9)]
            [InlineData(11, 175 * 11)]
            public void CaloriesAdjustsCorrectly(uint c, uint cals)
            {
                GarlicKnots b = new()
                {
                    Count = c
                };
                Assert.Equal(cals, b.CaloriesTotal);
            }

            /// <summary>
            /// Tests that the special instructions are correct
            /// </summary>
            /// <param name="c">The count of GarlicKnots</param>
            /// <param name="cheese">Wheather The sticks have cheese on them</param>
            /// <param name="instructions">The expected instructions for the GarlicKnots</param>
            [Theory]
            [InlineData(8, new string[] { "8 Garlic Knots" })]
            [InlineData(9, new string[] { "9 Garlic Knots" })]
            [InlineData(12, new string[] { "12 Garlic Knots" })]
            [InlineData(11, new string[] { "11 Garlic Knots" })]
            [InlineData(4, new string[] { "4 Garlic Knots" })]
            [InlineData(5, new string[] { "5 Garlic Knots" })]
            [InlineData(6, new string[] { "6 Garlic Knots" })]
            [InlineData(7, new string[] { "7 Garlic Knots" })]

            public void SpecialInstructionsAreCorrect(uint c, string[] instructions)
            {
                GarlicKnots b = new()
                {
                    Count = c
                };

                foreach (string instruction in instructions)
                {
                    Assert.Contains(instruction, b.SpecialInstructions);
                }
                Assert.Equal(instructions.Length, b.SpecialInstructions.Count());
            }
          #endregion

    }
}
