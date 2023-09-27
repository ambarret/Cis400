using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    public class OrderUnitTests
    {
        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockMenuItem : IMenuItem
        {
            /// <summary>
            /// The name
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// The Description
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// The price
            /// </summary>
            public decimal Price { get; set; }
            /// <summary>
            /// The calories per each
            /// </summary>
            public uint CaloriesPerEach { get; set; }

            /// <summary>
            /// The total calories
            /// </summary>
            public uint CaloriesTotal { get; set; }
            /// <summary>
            /// The special instructions
            /// </summary>
            public IEnumerable<string> SpecialInstructions { get; set; }
        }

        /// <summary>
        /// Checks that the subtotal is correct
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        /// <summary>
        /// Checks that tax rate can be changed
        /// </summary>
        [Fact]
        public void TaxRateCanChange()
        { 
            Order order = new Order();
            order.TaxRate = 1;
            Assert.Equal(1, order.TaxRate);
        }

        /// <summary>
        /// Checks the tax is correct
        /// </summary>
        [Fact]
        public void TaxesAreCorrect()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(0.59m, order.Tax);
        }

        /// <summary>
        /// Checks that the total is correct
        /// </summary>
        [Fact]
        public void TotalIsCorrect()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(7.09m, order.Total);
        }

        /// <summary>
        /// Checks that clear works
        /// </summary>
        [Fact]
        public void ClearWorks()
        {
                Order order = new Order();
                order.Add(new MockMenuItem() { Price = 1.00m });
                order.Add(new MockMenuItem() { Price = 2.50m });
                order.Add(new MockMenuItem() { Price = 3.00m });
                order.Clear();
                Assert.Empty(order);
        }

        /// <summary>
        /// Checks that find works
        /// </summary>
        [Fact]
        public void FindWorks()
        {
            Order order = new Order();
            MockMenuItem menuItem = new MockMenuItem();
            order.Add(menuItem);
            Assert.True(order.Contains(menuItem));
        }

        /// <summary>
        /// Checks that remove works
        /// </summary>
        [Fact]
        public void RemoveWorks()
        {
            Order order = new Order();
            MockMenuItem menuItem = new MockMenuItem();
            order.Add(menuItem);
            Assert.True(order.Remove(menuItem));
        }
    }
}
