using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
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
using PizzaParlor.PointOfSale;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl, INotifyPropertyChanged
    {
        public PaymentControl()
        {
            InitializeComponent();
            if (DataContext is Order order)
            {
                PaymentViewModel paymentViewModel = new PaymentViewModel(order);
                DataContext = paymentViewModel;
            }

            Input.LostFocus += Input_LostFocus;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string FormatReceipt(PaymentViewModel paymentViewModel)
        {
            string receipt = $"Order Number: {paymentViewModel.Ordernum}\n";
            receipt += $"Date: {paymentViewModel.Time}\n";
            receipt += "Items Ordered:\n";

            foreach (IMenuItem item in paymentViewModel.menuItems)
            {
                receipt += $"  - {item.Name} - Price: {item.Price:C} - Special Instructions: \n";
                foreach (string instruction in item.SpecialInstructions)
                {
                    receipt += instruction + "\n";
                }
                receipt += "\n";
            }
            receipt += $"\nSubtotal: {paymentViewModel.Subtotal:C}\n";
            receipt += $"Tax: {paymentViewModel.Tax:C}\n";
            receipt += $"Total: {paymentViewModel.Total:C}\n";
            receipt += $"Amount Paid: {paymentViewModel.Paid:C}\n";
            receipt += $"Change: {paymentViewModel.Change:C}\n";
            receipt += "-----------------\n";
            return receipt;
        }

        private void SaveReceiptToFile(string receiptText)
        {
            string filePath = "receipts.txt";

            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(receiptText);
                }

                MessageBox.Show("Receipt saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void FinalizePaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is PaymentViewModel paymentViewModel)
            {
                string receiptText = FormatReceipt(paymentViewModel);
                SaveReceiptToFile(receiptText);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));
            }
        }

        private void Input_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            Input.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }
    }
}
