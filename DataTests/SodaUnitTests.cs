using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Unit Tests for the Soda Class
    /// </summary>
    public class SodaUnitTests
    {
        #region Defaults

        /// <summary>
        /// Tests that the name is Soda
        /// </summary>
        [Fact]
        public void DefaultNameIsSoda()
        {
            Soda s = new();
            Assert.Equal("Soda", s.Name);
        }

        /// <summary>
        /// Tests that the description is correct
        /// </summary>
        [Fact]
        public void DefaultDescriptionIsCorrect()
        {
            Soda s = new();
            Assert.Equal("Standard fountain drink", s.Description);
        }

        /// <summary>
        /// Tests that the Ice bool is true
        /// </summary>
        [Fact]
        public void DefaultIceIsTrue() 
        {
            Soda s = new();
            Assert.True(s.Ice);
        }

        /// <summary>
        /// Tests that the default size is medium
        /// </summary>
        [Fact]
        public void DefaultSizeIsMedium() 
        {
            Soda s = new();
            Assert.Equal(Size.Medium, s.DrinkSize);
        }

        /// <summary>
        /// Tests that the default flavor is coke
        /// </summary>
        [Fact]
        public void DefaultFlavorIsCoke()
        {
            Soda s = new();
            Assert.Equal(SodaFlavor.Coke, s.DrinkType);
        }
        #endregion
        #region State Changes

        /// <summary>
        /// Tests that the flavor can change
        /// </summary>
        /// <param name="flavor">The flavor to change</param>
        [Theory]
        [InlineData(SodaFlavor.Coke)]
        [InlineData(SodaFlavor.DrPepper)]
        [InlineData(SodaFlavor.DietCoke)]
        [InlineData(SodaFlavor.Sprite)]
        [InlineData(SodaFlavor.RootBeer)]
        public void FlavorCanChange(SodaFlavor flavor)
        {
            Soda s = new()
            {
                DrinkType = flavor,
            };
            Assert.Equal(flavor, s.DrinkType);
        }

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
            Soda s = new()
            {
                DrinkSize = size,
            };
            Assert.Equal(size, s.DrinkSize);
        }

        /// <summary>
        /// Tests that the price adjusts to the soda instance
        /// </summary>
        /// <param name="size">The size to change</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(Size.Medium, 2.00)]
        [InlineData(Size.Small, 1.50)]
        [InlineData(Size.Large, 2.50)]
        public void PriceCanChange(Size size, double price)
        {
            Soda s = new()
            {
                DrinkSize = size,
            };

            Assert.Equal( price, (double)s.Price);
        }

        /// <summary>
        /// Tests that the calories are correct
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="flavor">The flavor of the drink</param>
        /// <param name="cals">The expected ammount of calories</param>
        [Theory]
        [InlineData(Size.Medium, SodaFlavor.Coke, 200)]
        [InlineData(Size.Large, SodaFlavor.Coke, 250)]
        [InlineData(Size.Small, SodaFlavor.DrPepper, 150)]
        [InlineData(Size.Medium, SodaFlavor.DietCoke, 0)]
        [InlineData(Size.Large, SodaFlavor.DietCoke, 0)]
        [InlineData(Size.Small, SodaFlavor.DietCoke, 0)]
        [InlineData(Size.Medium, SodaFlavor.Sprite, 200)]
        [InlineData(Size.Large, SodaFlavor.RootBeer, 250)]

        public void CaloriesAdjustCorrectly(Size size, SodaFlavor flavor, uint cals)
        {
            Soda s = new()
            {
                DrinkSize = size,
                DrinkType = flavor
            };
            Assert.Equal(cals, s.CaloriesTotal);
        }

        /// <summary>
        /// Tests that the special instructions are correct
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="flavor">The flavor of the drink</param>
        /// <param name="ice">Whether the drink has ice</param>
        /// <param name="instructions">The expected instructions</param>
        [Theory]
        [InlineData(Size.Medium, SodaFlavor.Coke, true, new string[] {"Medium", "Coke"})]
        [InlineData(Size.Small, SodaFlavor.Coke, true, new string[] { "Small", "Coke" })]
        [InlineData(Size.Large, SodaFlavor.Coke, true, new string[] { "Large", "Coke" })]
        [InlineData(Size.Medium, SodaFlavor.DietCoke, true, new string[] { "Medium", "DietCoke" })]
        [InlineData(Size.Small, SodaFlavor.Sprite, false, new string[] { "Small", "Sprite", "Hold Ice" })]
        [InlineData(Size.Large, SodaFlavor.RootBeer, true, new string[] { "Large", "RootBeer" })]
        [InlineData(Size.Medium, SodaFlavor.DrPepper, true, new string[] { "Medium", "DrPepper" })]
        [InlineData(Size.Small, SodaFlavor.Coke, false, new string[] { "Small", "Coke", "Hold Ice" })]
        public void SpecialInstructionsIsCorrect(Size size, SodaFlavor flavor, bool ice, string[] instructions)
        {
            Soda s = new()
            {
                DrinkSize = size,
                DrinkType = flavor,
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
