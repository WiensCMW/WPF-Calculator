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

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        double result;

        public MainWindow()
        {
            InitializeComponent();

            buttonAC.Click += ButtonAC_Click;
            buttonNegative.Click += ButtonNegative_Click;
            buttonPercent.Click += ButtonPercent_Click;
            buttonEquals.Click += ButtonEquals_Click;
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResults.Content?.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                labelResults.Content = lastNumber.ToString();
            }
        }

        private void ButtonNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResults.Content?.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                labelResults.Content = lastNumber.ToString();
            }
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            labelResults.Content = "0";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResults.Content?.ToString(), out lastNumber))
            {
                labelResults.Content = "0";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the value of the clicked button
            int selectedValue = 0;

            if (sender == button0)
                selectedValue = 0;
            else if (sender == button1)
                selectedValue = 1;
            else if (sender == button2)
                selectedValue = 2;
            else if (sender == button3)
                selectedValue = 3;
            else if (sender == button4)
                selectedValue = 4;
            else if (sender == button5)
                selectedValue = 5;
            else if (sender == button6)
                selectedValue = 6;
            else if (sender == button7)
                selectedValue = 7;
            else if (sender == button8)
                selectedValue = 8;
            else if (sender == button9)
                selectedValue = 9;

            /*  If label results is 0, we override it again with 0. This ensures that if the results is 0
                repeatedly pressing 0 won't add additional zeros. */
            if (labelResults.Content?.ToString() == "0")
            {
                labelResults.Content = $"{selectedValue}";
            }
            else
            {
                // Label results != 0, so we add the new clicked value to the end of the existing value.
                labelResults.Content = $"{labelResults.Content}{selectedValue}";
            }
        }
    }
}
