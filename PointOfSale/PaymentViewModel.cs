using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaParlor.Data;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// ViewModel for the payment control.
    /// </summary>
    public class PaymentViewModel : INotifyPropertyChanged
    {
        private Order order;

        /// <summary>
        /// Initializes a new instance of the PaymentViewModel class with an Order.
        /// </summary>
        /// <param name="order">The order to calculate payments for.</param>
        public PaymentViewModel(Order order)
        {
            this.order = order;
            Paid = Total;
        }

        /// <summary>
        /// Gets the order number
        /// </summary>
        public int Ordernum
        {
            get { return order.Number; }
        }

        /// <summary>
        /// Gets the Time
        /// </summary>
        public DateTime Time
        {
            get { return order.PlacedAt; }
        }


        /// <summary>
        /// Gets the menuitems in an array
        /// </summary>
        public IMenuItem[] menuItems
        { 
            get 
            {
                IMenuItem[] item = new IMenuItem[order.Count];
                int i = 0;
                foreach (var itemItem in order) 
                {
                    item[i] = itemItem;
                    i++;
                }
                return item;
            }
        }

      

        /// <summary>
        /// Gets the total cost of the order.
        /// </summary>
        public decimal Total
        {
            get { return order.Total; }
        }

        /// <summary>
        /// Gets the subtotal cost of the order.
        /// </summary>
        public decimal Subtotal
        {
            get { return order.Subtotal; }
        }

        /// <summary>
        /// Gets the tax cost of the order.
        /// </summary>
        public decimal Tax
        {
            get { return order.Tax; }
        }

        private decimal _paid;

        /// <summary>
        /// Gets or sets the amount paid by the user. It enforces that it is never set below the total cost.
        /// </summary>
        public decimal Paid
        {
            get { return _paid; }
            set
            {
                if (value >= Total)
                {
                    _paid = value;
                }
                else
                {
                    _paid = Total;
                }

                NotifyPropertyChanged(nameof(Paid));
                NotifyPropertyChanged(nameof(Change));
            }
        }

        /// <summary>
        /// Gets the change to be returned to the user.
        /// </summary>
        public decimal Change
        {
            get { return Paid - Total; }
        }

        /// <summary>
        /// Gets a string representation of the receipt for the order.
        /// </summary>
        public string Receipt
        {
            get
            {
                string receipt = $"Total: {Total:C}\n";
                receipt += $"Paid: {Paid:C}\n";
                receipt += $"Change: {Change:C}\n";
                return receipt;
            }
        }

        /// <summary>
        /// Event raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Notifies that a property value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
