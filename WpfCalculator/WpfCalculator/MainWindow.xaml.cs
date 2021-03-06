﻿using System;
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
using WpfCalculator.Classes;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber;
        private double result;
        private SelectedOperator selectedOperator;

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
            double newNumber;
            if (double.TryParse(labelResults.Content?.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        {
                            result = SimpleMath.Add(lastNumber, newNumber);
                            break;
                        }
                    case SelectedOperator.Subtraction:
                        {
                            result = SimpleMath.Subtraction(lastNumber, newNumber);
                            break;
                        }
                    case SelectedOperator.Multiplication:
                        {
                            result = SimpleMath.Multiply(lastNumber, newNumber);
                            break;
                        }
                    case SelectedOperator.Division:
                        {
                            result = SimpleMath.Divide(lastNumber, newNumber);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                labelResults.Content = result.ToString();
            }
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResults.Content?.ToString(), out double percNumber))
            {
                // Calculate percentage of entered number
                percNumber = percNumber / 100;

                // If lastNumber != 0, we set the percNumber to itself multiplied by the last number
                if (lastNumber != 0)
                    percNumber *= lastNumber;

                // Pass the calculate percentage to the result label.
                labelResults.Content = percNumber.ToString();
            }
        }

        private void ButtonNegative_Click(object sender, RoutedEventArgs e)
        {
            // Flip existing value into either positive or negative
            if (double.TryParse(labelResults.Content?.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                labelResults.Content = lastNumber.ToString();
            }
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            labelResults.Content = "0";
            lastNumber = 0;
            result = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // Parse label results to lastNumber variable
            if (double.TryParse(labelResults.Content?.ToString(), out lastNumber))
            {
                // Zero out the result label in preparation of the operation which is run when the equals button is clicked.
                labelResults.Content = "0";
            }

            // Assign correct selected operator based on button clicked.
            if (sender == buttonMultiply)
                selectedOperator = SelectedOperator.Multiplication;
            else if (sender == buttonDivide)
                selectedOperator = SelectedOperator.Division;
            else if (sender == buttonPlus)
                selectedOperator = SelectedOperator.Addition;
            else if (sender == buttonMinus)
                selectedOperator = SelectedOperator.Subtraction;
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

        private void ButtonPeriod_Click(object sender, RoutedEventArgs e)
        {
            if (labelResults.Content != null 
                && !labelResults.Content.ToString().Contains("."))
                labelResults.Content = $"{labelResults.Content}.";
        }

        private void ButtonEquals_Click_1(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResults.Content.ToString(), out double value))
            {
                AppState.ChangeAppStyleFontSize(value);
            }
        }
    }
}
