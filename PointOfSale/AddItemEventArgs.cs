using PizzaParlor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Argument for adding an IMenuItem To Order
    /// </summary>
    public class AddItemEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Private backing field for this args
        /// </summary>
        public IMenuItem Item {  get; private set; }

        public AddItemEventArgs(IMenuItem menuitem)
        {
            Item = menuitem;
        }
    }
}
