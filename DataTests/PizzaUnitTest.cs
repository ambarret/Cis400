using System;
using System.Collections.Generic;
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
    }
}
