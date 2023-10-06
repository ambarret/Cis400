using PizzaParlor.Data;
using PizzaParlor.Data.Breadsticks;
using PizzaParlor.Data.Drinks;
using PizzaParlor.Data.Pizzas;
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

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// adds the Pizza class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddBuildYourOwn(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new Pizza());
            }
        }

        /// <summary>
        /// adds the Meats pizza class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddMeats(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new MeatsPizza());
            }
        }

        /// <summary>
        /// adds the Veggie Pizza class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddVeggie(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new VeggiePizza());
            }
        }

        /// <summary>
        /// adds the Supreme Pizza class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddSupreme(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new SupremePizza());
            }
        }

        /// <summary>
        /// adds the Hawaiian Pizza class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddHawaiian(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new HawaiianPizza());
            }
        }

        /// <summary>
        /// adds the Bread Sticks class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddBread(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new BreadSticks());
            }
        }

        /// <summary>
        /// adds the Cinnamon Sticks class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddCinnamon(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new CinnamonSticks());
            }
        }

        /// <summary>
        /// adds the Garlic Sticks class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddGarlic(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new GarlicKnots());
            }
        }

        /// <summary>
        /// adds the Wings class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddWings(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new Wings());
            }
        }

        /// <summary>
        /// adds the Iced Tea class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddTea(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new IcedTea());
            }
        }

        /// <summary>
        /// adds the Soda class to the order
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The RoutedEvent</param>
        public void AddSoda(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(new Soda());
            }
        }


    }
}
