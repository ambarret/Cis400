using PizzaParlor.Data.Drinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Tests for the Menu class
    /// </summary>
    public class MenuUnitTests
    {
        [Fact]
        public void TestPizzasCountAndCombinations()
        {
            // Arrange
            var pizzas = Menu.Pizzas.ToList();

            // Act & Assert
            Assert.Equal(45, pizzas.Count);

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                foreach (Crust crust in Enum.GetValues(typeof(Crust)))
                {
                    Assert.Contains(pizzas, pizza =>
                        pizza is Pizza &&
                        ((Pizza)pizza).PizzaSize == size &&
                        ((Pizza)pizza).PizzaCrust == crust);
                }
            }
        }

        [Fact]
        public void TestSidesCountAndCombinations()
        {
            // Arrange
            var sides = Menu.Sides.ToList();

            // Act & Assert
            Assert.Equal(7, sides.Count); // Adjust the expected count based on your implementation

            // Add additional checks for specific combinations if needed
        }

        [Fact]
        public void TestDrinksCountAndCombinations()
        {
            // Arrange
            var drinks = Menu.Drinks.ToList();

            // Act & Assert
            Assert.Equal(18, drinks.Count);

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                foreach (SodaFlavor flavor in Enum.GetValues(typeof(SodaFlavor)))
                {
                    Assert.Contains(drinks, drink =>
                        drink is IcedTea && ((IcedTea)drink).DrinkSize == size ||
                        drink is Soda && ((Soda)drink).DrinkSize == size && ((Soda)drink).DrinkType == flavor);
                }
            }
        }

        [Fact]
        public void TestFullMenuCountAndCombinations()
        {

            var fullMenu = Menu.FullMenu.ToList();

            Assert.Equal(45+18+7, fullMenu.Count);

        }
    }
}
