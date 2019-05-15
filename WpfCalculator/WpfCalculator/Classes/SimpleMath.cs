using System.Windows;

namespace WpfCalculator
{
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            // Check if user is dividing by 0, alert them and return 0.
            if (n2 == 0)
            {
                MessageBox.Show("Cannot divide by 0"
                    , "Invalid Operation"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Warning
                    , MessageBoxResult.OK);
                return 0;
            }

            return n1 / n2;
        }
    }
}
