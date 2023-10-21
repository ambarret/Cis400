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
using PizzaParlor.PointOfSale.IMenuItemControls;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Order();
            MenuItem.MenuItemAdded += ItemWasAdded;
            OrderSummary.MenuItemAdded += ItemWasAdded;
        }

        /// <summary>
        /// Temporary Handler for the other two button
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The Argument</param>
        private void ClearOrder(object sender, EventArgs e)
        {
            DataContext = new Order();
        }

        /// <summary>
        /// Handler for the back button
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The Argument</param>
        private void BackButtonHandler(object sender, RoutedEventArgs e)
        {
            MenuItem.Visibility = Visibility.Visible;
            WingsControl.Visibility = Visibility.Hidden;
            BreadSticks.Visibility = Visibility.Hidden;
            GarlicSticks.Visibility = Visibility.Hidden;
            CinnamonSticks.Visibility = Visibility.Hidden;
            Pizza.Visibility = Visibility.Hidden;
            Soda.Visibility = Visibility.Hidden;
            IceTea.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Handles When an Item is added
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The argument</param>
        public void ItemWasAdded(object? sender, AddItemEventArgs e)
        {
            MenuItem.Visibility = Visibility.Hidden;
            WingsControl.Visibility = Visibility.Hidden;
            BreadSticks.Visibility = Visibility.Hidden;
            GarlicSticks.Visibility = Visibility.Hidden;
            CinnamonSticks.Visibility = Visibility.Hidden;
            Pizza.Visibility = Visibility.Hidden;
            Soda.Visibility = Visibility.Hidden;
            IceTea.Visibility = Visibility.Hidden;
            switch (e?.Item.Name)
            {
                case "Wings":
                    WingsControl.Visibility = Visibility.Visible;
                    WingsControl.DataContext = e.Item;
                    break;
                case "Breadsticks":
                    BreadSticks.Visibility = Visibility.Visible;
                    BreadSticks.DataContext = e.Item;
                    break;
                case "Garlic Knots":
                    GarlicSticks.Visibility = Visibility.Visible;
                    GarlicSticks.DataContext = e.Item;
                    break;
                case "Cinnamon Sticks":
                    CinnamonSticks.Visibility = Visibility.Visible;
                    CinnamonSticks.DataContext = e.Item;
                    break;
                case "Build-Your-Own Pizza":
                case "Hawaiian Pizza":
                case "Meats Pizza":
                case "Supreme Pizza":
                case "Veggie Pizza":
                    Pizza.Visibility = Visibility.Visible;
                    Pizza.DataContext = e.Item;
                    break;
                case "Iced Tea":
                    IceTea.Visibility = Visibility.Visible;
                    IceTea.DataContext = e.Item;
                    break;
                case "Soda":
                    Soda.Visibility = Visibility.Visible;
                    Soda.DataContext = e.Item;
                    break;
                default:
                    break;
            }
        }
    }
}
