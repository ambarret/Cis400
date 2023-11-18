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

        [Theory]
        [InlineData(null, 45)]
        [InlineData("", 45)]
        [InlineData("Supreme", 9)]
        [InlineData("Supreme Pizza", 9)]
        [InlineData("Pizza Supreme", 9)]
        [InlineData("SuPrEME", 9)]
        [InlineData("Veggie", 9)]
        [InlineData("wING", 0)]
        public void TestingPizzaSearch(string term, int count)
        {
            IEnumerable<IMenuItem> items = Menu.PizzaSearch(term);
            Assert.Equal(count, items.Count());
        }

        [Theory]
        [InlineData(null, 7)]
        [InlineData("", 7)]
        [InlineData("Sticks", 2)]
        [InlineData("Bread Sticks", 1)]
        [InlineData("Sticks Bread", 1)]
        [InlineData("BreAd STIcks", 1)]
        [InlineData("Cinnamon", 1)]
        [InlineData("wING", 4)]
        public void TestingSidesSearch(string term, int count)
        {
            IEnumerable<IMenuItem> items = Menu.SideSearch(term);
            Assert.Equal(count, items.Count());
        }

        [Theory]
        [InlineData(null, 18)]
        [InlineData("", 18)]
        [InlineData("Soda", 15)]
        [InlineData("Tea", 3)]
        [InlineData("TeA", 3)]
        [InlineData("SODA", 15)]
        public void TestingDrinksSearch(string term, int count)
        {
            IEnumerable<IMenuItem> items = Menu.DrinkSearch(term);
            Assert.Equal(count, items.Count());
        }

        [Theory]
        [InlineData(null, 507, 70)]
        [InlineData(507, null, 0)]
        [InlineData(0, 0, 3)]
        [InlineData(0, 100, 3)]
        [InlineData(100, 200, 26)]
        [InlineData(200, 300, 29)]
        [InlineData(300, 400, 12)]
        [InlineData(400, 507, 6)]
        public void CaloriesSearchWorks(uint min, uint max, int count)
        {
            IEnumerable<IMenuItem> pizza = Menu.PizzaSearch("");
            IEnumerable<IMenuItem> drink = Menu.DrinkSearch("");
            IEnumerable<IMenuItem> side = Menu.SideSearch("");
            List<IMenuItem> result = (List<IMenuItem>) Menu.Calories(pizza, min, max);
            IEnumerable<IMenuItem> drinkres = Menu.Calories(drink, min, max);
            IEnumerable <IMenuItem> sideres = Menu.Calories(side, min, max);
            foreach (IMenuItem item in drinkres) { result.Add(item); }
            foreach (IMenuItem item in sideres) { result.Add(item); }
            Assert.Equal(count, result.Count());
        }

        [Theory]
        [InlineData(null, 21.99, 70)]
        [InlineData(21.99, null, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 5, 18)]
        [InlineData(5, 10, 7)]
        [InlineData(10, 15, 23)]
        [InlineData(15, 20, 19)]
        [InlineData(20, 25, 3)]
        public void PriceSearchWorks(decimal min, decimal max, int count)
        {
            IEnumerable<IMenuItem> pizza = Menu.PizzaSearch("");
            IEnumerable<IMenuItem> drink = Menu.DrinkSearch("");
            IEnumerable<IMenuItem> side = Menu.SideSearch("");
            List<IMenuItem> result = (List<IMenuItem>)Menu.Price(pizza, min, max);
            IEnumerable<IMenuItem> drinkres = Menu.Price(drink, min, max);
            IEnumerable<IMenuItem> sideres = Menu.Price(side, min, max);
            foreach (IMenuItem item in drinkres) { result.Add(item); }
            foreach (IMenuItem item in sideres) { result.Add(item); }
            Assert.Equal(count, result.Count());
        }
    }
}
