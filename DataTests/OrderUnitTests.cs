using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Tests for the OrderUnitTests
    /// </summary>
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

        /// <summary>
        /// Tests that the order number is unique
        /// </summary>
        [Fact]
        public void OrderNumberIsUnique()
        {
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();

            Assert.NotEqual(order1.Number, order2.Number);
            Assert.NotEqual(order2.Number, order3.Number);
            Assert.NotEqual(order3.Number, order1.Number);
        }

        /// <summary>
        /// Date time records the Date
        /// </summary>
        [Fact]
        public void PlacedAtWorks()
        {
            DateTime lower = DateTime.Now;
            Order order = new Order();
            DateTime upper = DateTime.Now;
            Assert.True((order.PlacedAt >= lower) && (order.PlacedAt <= upper));
        }

        /// <summary>
        /// Checks there is a propertyChange when changing the TaxRate
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Tax", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Checks there is a propertyChange when adding an item
        /// </summary>
        [Fact]
        public void AddingItemsShouldNotifyOfPropertyChanged()
        {
            Order order = new Order();
            MockMenuItem a = new MockMenuItem();
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Add(a);
            });
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Add(a);
            });
            Assert.PropertyChanged(order, "Tax", () =>
            {
                order.Add(a);
            });
        }

        /// <summary>
        /// Checks there is a propertyChange when removing an item
        /// </summary>
        [Fact]
        public void RemovingItemsShouldNotifyOfPropertyChanged()
        {
            Order order = new Order();
            MockMenuItem a = new MockMenuItem();
            order.Add(a);
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Remove(a);
            });
            order.Add(a);
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Remove(a);
            });
            order.Add(a);
            Assert.PropertyChanged(order, "Tax", () =>
            {
                order.Remove(a);
            });
        }

        /// <summary>
        /// Checks there is a propertyChange when Clearing an item
        /// </summary>
        [Fact]
        public void ClearingItemsShouldNotifyOfPropertyChanged()
        {
            Order order = new Order();
            MockMenuItem a = new MockMenuItem();
            order.Add(a);
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Clear();
            });
            order.Add(a);
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Clear();
            });
            order.Add(a);
            Assert.PropertyChanged(order, "Tax", () =>
            {
                order.Clear();
            });
        }

        /// <summary>
        /// Checks that INotifyChanged is implemented correctly
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// Checking that Collection Change does the correct action
        /// </summary>
        [Fact]
        public void AddingItemShouldRaiseCollectionChangedEvent()
        {
            ObservableCollection<IMenuItem> o = new ObservableCollection<IMenuItem>();
            var a = new MockMenuItem();

            bool notifySucceeded = false;

            o.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    notifySucceeded = true;
                }
            };

            o.Add(a);

            Assert.True(notifySucceeded);

        }

        /// <summary>
        /// Checking that Collection Change does the correct action
        /// </summary>
        [Fact]
        public void RemovingItemShouldRaiseCollectionChangedEvent()
        {
            ObservableCollection<IMenuItem> o = new ObservableCollection<IMenuItem>();
            var a = new MockMenuItem();

            bool notifySucceeded = false;

            o.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    notifySucceeded = true;
                }
            };

            o.Add(a);
            o.Remove(a);

            Assert.True(notifySucceeded);

        }

        /// <summary>
        /// Checking that Collection Change does the correct action
        /// </summary>
        [Fact]
        public void ClearingItemsShouldRaiseCollectionChangedEvent()
        {
            ObservableCollection<IMenuItem> o = new ObservableCollection<IMenuItem>();
            var a = new MockMenuItem();

            bool notifySucceeded = false;

            o.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    notifySucceeded = true;
                }
            };

            o.Add(a);
            o.Clear();

            Assert.True(notifySucceeded);

        }
    }
}
