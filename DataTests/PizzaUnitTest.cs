using PizzaParlor.Data.Drinks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Unit test for the pizza interface
    /// </summary>
    public class PizzaUnitTest
    {
        /// <summary>
        /// Check name is correct
        /// </summary>
        [Fact]
        public void NameIsCorrect()
        {
            Pizza p = new();
            Assert.Equal("Build-Your-Own Pizza", p.Name);
        }

        /// <summary>
        /// Check ToString is correct
        /// </summary>
        [Fact]
        public void ToStringIsCorrect()
        {
            Pizza p = new();
            Assert.Equal("Build-Your-Own Pizza", p.ToString());
        }

        [Fact]
        public void DescIsCorrect()
        {
            Pizza p = new();
            Assert.Equal("A pizza you get to build", p.Description);
        }

        /// <summary>
        /// Tests that the default value is true
        /// </summary>
        [Fact]
        public void DefaultSizeIsMedium()
        {
            Pizza p = new();
            Assert.Equal(Size.Medium, p.PizzaSize);
        }

        /// <summary>
        /// Tests that the crust is original
        /// </summary>
        [Fact]
        public void DefaultCrustIsOriginal()
        {
            Pizza p = new();
            Assert.Equal(Crust.Original, p.PizzaCrust);
        }

        /// <summary>
        /// Tests that the number of slices is eight
        /// </summary>
        [Fact]
        public void DefaultSizeIsEight()
        {
            Pizza p = new();
            Assert.Equal((uint)8, p.Slices);
        }

        /// <summary>
        /// Tests that the default calorieseach is 340
        /// </summary>
        [Fact]
        public void CaloriesPerEachIs340()
        {
            Pizza p = new();
            Assert.Equal((uint)250, p.CaloriesPerEach);
        }

        /// <summary>
        /// Checks the NotifyPropertyChanges
        /// </summary>
        /// <param name="crust">The crust of the Pizza</param>
        /// <param name="propertyName">The propertyName</param>
        [Theory]
        [InlineData(Crust.DeepDish, "Price")]
        [InlineData(Crust.DeepDish, "CaloriesPerEach")]
        [InlineData(Crust.DeepDish, "CaloriesTotal")]
        [InlineData(Crust.DeepDish, "SpecialInstructions")]
        [InlineData(Crust.Thin, "Price")]
        [InlineData(Crust.Thin, "CaloriesPerEach")]
        [InlineData(Crust.Thin, "CaloriesTotal")]
        [InlineData(Crust.Thin, "SpecialInstructions")]
        [InlineData(Crust.Original, "Price")]
        [InlineData(Crust.Original, "CaloriesPerEach")]
        [InlineData(Crust.Original, "CaloriesTotal")]
        [InlineData(Crust.Original, "SpecialInstructions")]
        public void ChangingCrustShouldNotifyOfPropertyChanges(Crust crust, string propertyName)
        {
            Pizza p = new();
            Assert.PropertyChanged(p, propertyName, () => {
                p.PizzaCrust = crust;
            });
        }

        /// <summary>
        /// Checks the NotifyPropertyChanges
        /// </summary>
        /// <param name="size">The size of the Pizza</param>
        /// <param name="propertyName">The propertyName</param>
        [Theory]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Medium, "CaloriesPerEach")]
        [InlineData(Size.Medium, "CaloriesTotal")]
        [InlineData(Size.Medium, "SpecialInstructions")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Small, "CaloriesPerEach")]
        [InlineData(Size.Small, "CaloriesTotal")]
        [InlineData(Size.Small, "SpecialInstructions")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Large, "CaloriesPerEach")]
        [InlineData(Size.Large, "CaloriesTotal")]
        [InlineData(Size.Large, "SpecialInstructions")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(Size size, string propertyName)
        {
            Pizza p = new();
            Assert.PropertyChanged(p, propertyName, () => {
                p.PizzaSize = size;
            });
        }
        /// <summary>
        /// Checks the INotify chenge
        /// </summary>
        /// <param name="t">The Topping</param>
        [Theory]
        [InlineData(Topping.Onions)]
        [InlineData(Topping.Pepperoni)]
        [InlineData(Topping.Sausage)]
        [InlineData(Topping.Ham)]
        [InlineData(Topping.Bacon)]
        [InlineData(Topping.Peppers)]
        [InlineData(Topping.Olives)]
        [InlineData(Topping.Mushrooms)]
        public void ChangingToppingsShouldNotifyPropertyChange(Topping t)
        {
            PizzaTopping p = new PizzaTopping(t, true);
            Assert.PropertyChanged(p, "OnPizza", () =>
            {
                p.OnPizza = false;
            });
        }

        /// <summary>
        /// Checks the INotifyChanged is Implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Pizza pizza = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(pizza);
        }
    }
}
