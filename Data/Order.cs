using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The list of the order
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        /// <summary>
        /// The list of menu items
        /// </summary>
        private readonly List<IMenuItem> _items = new List<IMenuItem>();

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The count of items 
        /// </summary>
        public int Count => (_items).Count;

        /// <summary>
        /// Checks if list is read only
        /// </summary>
        public bool IsReadOnly => true;

        /// <summary>
        /// Adds items to the list
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(IMenuItem item)
        {
            _items.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Clears the list
        /// </summary>
        public void Clear()
        {
            _items.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Finds if the items exists in the list
        /// </summary>
        /// <param name="item">The item to Search</param>
        /// <returns>Bool if the item was found</returns>
        public bool Contains(IMenuItem item)
        {
            return _items.Contains(item);
        }

        /// <summary>
        /// Coppies list into an array
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="arrayIndex">The index</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the Enumerator
        /// </summary>
        /// <returns>The Enumerator</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Removes an item on the list
        /// </summary>
        /// <param name="item">the item to remove</param>
        /// <returns>bool whether or not it completed</returns>
        public bool Remove(IMenuItem item)
        {
            int index = _items.IndexOf(item);

            if(index > 0)
            {
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                _items.RemoveAt(index);
                return true;
            }
            return false;

        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return   _items.GetEnumerator();
        }

        /// <summary>
        /// gets the total of the price of the items without tax
        /// </summary>
        public decimal Subtotal 
        {
            get
            {
                decimal result = 0;
                foreach (IMenuItem item in _items)
                {
                    result += item.Price;
                }
                return result;
            }
        }

        /// <summary>
        /// private backing field for taxrate
        /// </summary>
        private decimal _taxRate = 9.15m;

        /// <summary>
        /// a getter and setter for tax rate it is initialized to 9.15 percent
        /// </summary>
        public decimal TaxRate
        {
            get { return _taxRate; }
            set
            {
                _taxRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            }
        }

        /// <summary>
        /// The total tax
        /// </summary>
        public decimal Tax
        {
            get
            {
                return Math.Round(Subtotal * (TaxRate/100), 2);
            }
        }

        /// <summary>
        /// The price of the total transaction
        /// </summary>
        public decimal Total
        {
            get
            {
                return Tax + Subtotal;
            }
        }

        /// <summary>
        /// The previous order number
        /// </summary>
        private static int _lastNumber = 0;

        /// <summary>
        /// private backing field for the order number
        /// </summary>
        private int _number;


        /// <summary>
        /// The order Number
        /// </summary>
        public int Number { get { return _number; } }

        /// <summary>
        /// private backing field for the Time the order was made
        /// </summary>
        private DateTime _placedAt;

        /// <summary>
        /// The Time the order was made
        /// </summary>
        public DateTime PlacedAt { get { return _placedAt; } }

        public Order()
        {
            _number = ++_lastNumber;
            _placedAt = DateTime.Now;
        }
    }
}
