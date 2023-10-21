using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PizzaParlor.Data;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// Initializer
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        public event EventHandler<AddItemEventArgs> MenuItemAdded;

        /// <summary>
        /// Click event to edit the listview
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The Argument</param>
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list && listView.SelectedItem is IMenuItem item)
            {
                MenuItemAdded?.Invoke(this, new AddItemEventArgs(item));
            }
        }
    }
}
