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
    /// Interaction logic for CountBox.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        public CountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Count
        /// </summary>
        public uint Count
        {
            get
            {
                return (uint)GetValue(CountProperty);
            }
            set
            {
                SetValue(CountProperty, value);
            }
        }

        /// <summary>
        /// Dependency property for uint Count
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(uint), typeof(CountBox));

        /// <summary>
        /// Handles Increments
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The Argument</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count < uint.MaxValue)
            {
                Count++;
            }
        }

        /// <summary>
        /// Handles Decrements
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The Argument</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count > 0)
            {
                Count--;
            }
        }
    }
}
