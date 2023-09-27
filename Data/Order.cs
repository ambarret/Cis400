using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The list of the order
    /// </summary>
    public class Order : ICollection<IMenuItem>
    {
        /// <summary>
        /// The list of menu items
        /// </summary>
        private readonly List<IMenuItem> _items = new List<IMenuItem>();

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
        }

        /// <summary>
        /// Clears the list
        /// </summary>
        public void Clear()
        {
            _items.Clear();
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
            return _items.Remove(item);
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
        /// The TaxRate
        /// </summary>
        public decimal TaxRate { get; set; } = 9.15m;

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
    }
}
