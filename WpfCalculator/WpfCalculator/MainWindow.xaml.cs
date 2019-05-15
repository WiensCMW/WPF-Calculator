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

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (labelResults.Content?.ToString() == "0")
            {
                labelResults.Content = "7";
            }
            else
            {
                labelResults.Content = $"{labelResults.Content}7";
            }
        }
    }
}
