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

namespace PizzaParlor.PointOfSale.IMenuItemControls
{
    /// <summary>
    /// Interaction logic for PizzaControl.xaml
    /// </summary>
    public partial class PizzaControl : UserControl
    {
        public PizzaControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the topping checkbox
        /// </summary>
        public void LoadToppings()
        {
            if(DataContext is Pizza p)
            {
                ToppingDock.Children.Clear();
                TextBlock startText = new TextBlock()
;               startText.Text = "Toppings";
                ToppingDock.Children.Add(startText);
                StackPanel stack = new StackPanel();
                foreach(PizzaTopping top in p.PossibleToppings)
                {
                    CheckBox box = new CheckBox();
                    box.DataContext = top;
                    Binding bind = new Binding();
                    bind.Path = new PropertyPath(nameof(top.OnPizza));
                    bind.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, bind);
                    TextBlock text = new TextBlock();
                    text.Text = top.Name;
                    box.Content = text;
                    stack.Children.Add(box);
                }

                ToppingDock.Children.Add(stack);
            }
        }

    }
}
