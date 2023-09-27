using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Unit test for the Wings class
    /// </summary>
    public class WingsUnitTest
    {
        #region Defaults

        /// <summary>
        /// Tests that the name is Wings
        /// </summary>
        [Fact]
        public void NameIsWings()
        {
            Wings w = new();
            Assert.Equal("Wings", w.Name);
        }

        /// <summary>
        /// Tests that the Description is correct
        /// </summary>
        [Fact]
        public void DescriptionIsWings()
        {
            Wings w = new();
            Assert.Equal("Chicken wings tossed in sauce", w.Description);
        }

        /// <summary>
        /// Tests the the count default is five
        /// </summary>
        [Fact]
        public void CountDefaultIsfive()
        {
            Wings w = new();
            Assert.Equal((uint)5, w.Count);
        }

        /// <summary>
        /// Tests the the Bone Boolean is True
        /// </summary>
        [Fact]
        public void DefaultBoneInIsTrue()
        { 
            Wings w = new();
            Assert.True(w.BoneIn);
        }

        /// <summary>
        /// Tests that the default Sauce is Medium
        /// </summary>
        [Fact]
        public void DefaultSauceIsMedium()
        {
            Wings w = new();
            Assert.Equal(WingSauce.Medium, w.Sauce);
        }

        #endregion
        #region State Changes
        /// <summary>
        /// Tests that the Sauces can be changed
        /// </summary>
        /// <param name="s">The sauce to change</param>
        [Theory]
        [InlineData(WingSauce.Medium)]
        [InlineData(WingSauce.Hot)]
        [InlineData(WingSauce.HoneyBBQ)]
        [InlineData(WingSauce.Mild)]
        public void SauceChanges(WingSauce s)
        {
            Wings w = new()
            {
                Sauce = s
            };
            Assert.Equal(s, w.Sauce);
        }

        /// <summary>
        /// This tests that Wings is correctly within the bounds of 4 and 12, this also tests that it will keep the previous value
        /// if the current value is out of bounds
        /// </summary>
        /// <param name="f">First tested value</param>
        /// <param name="s">Second tested value</param>
        /// <param name="e">expected value</param>
        [Theory]
        [InlineData(4,4,4)]
        [InlineData(3,5,5)]
        [InlineData(6,3,6)]
        [InlineData(7,14,7)]
        [InlineData(15,8,8)]
        [InlineData(9,0,9)]
        [InlineData(0,10,10)]
        [InlineData(uint.MaxValue,uint.MinValue,5)]
        public void CountIsBoundedBetween4and12(uint f, uint s, uint e)
        {
            Wings w = new()
            {
                Count = f
            };
            w.Count = s;
            Assert.Equal(e, w.Count);
        }

        /// <summary>
        /// This tests the price adjusts correctly
        /// </summary>
        /// <param name="c">The count of wings</param>
        /// <param name="b">Whether the wings are bone in</param>
        /// <param name="p">The expected price</param>
        [Theory]
        [InlineData(5,true, 1.50 * 5)]
        [InlineData(5, false, 1.75 * 5)]
        [InlineData(4, true, 1.50 * 4)]
        [InlineData(4, false, 1.75 * 4)]
        [InlineData(6, true, 1.50 * 6)]
        [InlineData(6, false, 1.75 * 6)]
        [InlineData(12, true, 1.50 * 12)]
        [InlineData(12, false, 1.75 * 12)]
        public void PriceAdjustsCorrectly(uint c, bool b, decimal p)
        {
            Wings w = new()
            {
                Count = c,
                BoneIn = b
            };
            Assert.Equal(p, w.Price);
        }

        /// <summary>
        /// Tests that the calories are calculated correctly
        /// </summary>
        /// <param name="c">The count of wings</param>
        /// <param name="b">Whether the wings are bone in</param>
        /// <param name="s">The Sauce for the wings</param>
        /// <param name="e">The expected value</param>
        [Theory]
        [InlineData(5, true, WingSauce.Medium,125 * 5)]
        [InlineData(5, true, WingSauce.HoneyBBQ, 145 * 5)]
        [InlineData(5, false, WingSauce.Medium, 175 * 5)]
        [InlineData(6, true, WingSauce.Medium, 125 * 6)]
        [InlineData(5, false, WingSauce.HoneyBBQ, 195 * 5)]
        [InlineData(12, true, WingSauce.Hot, 125 * 12)]
        [InlineData(8, false, WingSauce.Mild, 175 * 8)]
        public void CaloriesAdjustsCorrectly(uint c, bool b, WingSauce s, uint e)
        {
            Wings w = new()
            {
                Count = c,
                BoneIn = b,
                Sauce = s
            };
            Assert.Equal(e, w.CaloriesTotal);
        }

        /// <summary>
        /// Tests that the special instructions for Wings is correct
        /// </summary>
        /// <param name="c">The count of wings</param>
        /// <param name="b">Whether the wings are bone in</param>
        /// <param name="s">The Sauce for the wings</param>
        /// <param name="instructions">The expected instructions</param>
        [Theory]
        [InlineData(5, true, WingSauce.Medium, new string[] {"5 Bone-In Wings", "Medium"})]
        [InlineData(6, false, WingSauce.Hot, new string[] { "6 Boneless Wings", "Hot" })]
        [InlineData(7, true, WingSauce.HoneyBBQ, new string[] { "7 Bone-In Wings", "HoneyBBQ" })]
        [InlineData(8, false, WingSauce.Mild, new string[] { "8 Boneless Wings", "Mild" })]
        [InlineData(9, true, WingSauce.Mild, new string[] { "9 Bone-In Wings", "Mild" })]
        [InlineData(10, false, WingSauce.HoneyBBQ, new string[] { "10 Boneless Wings", "HoneyBBQ" })]
        [InlineData(11, true, WingSauce.Hot, new string[] { "11 Bone-In Wings", "Hot" })]
        [InlineData(12, false, WingSauce.Medium, new string[] { "12 Boneless Wings", "Medium" })]
        public void SpecialInstructionsAreCorrect(uint c, bool b,WingSauce s, string[] instructions)
        {
            Wings w = new()
            {
                Count = c,
                BoneIn = b,
                Sauce = s
            };
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, w.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, w.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that it is assignable to Side
        /// </summary>
        [Fact]
        public void IsASide()
        {
            Wings b = new() { };
            Assert.IsAssignableFrom<Sides>(b);
        }
        #endregion
    }
}
