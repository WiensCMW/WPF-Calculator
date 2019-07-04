using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCalculator.Classes
{
    public static class AppState
    {
        public static void ChangeAppStyleFontSize(double baseFont)
        {
            try
            {
                Application.Current.Resources["StandardLabelFontSize"] = baseFont + 45;
                Application.Current.Resources["StandardButtonFontSize"] = baseFont;
                Application.Current.Resources["StandardButtonMargin"] = new Thickness(GetStyleMargin(baseFont), GetStyleMargin(baseFont), GetStyleMargin(baseFont), GetStyleMargin(baseFont));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static double GetStyleMargin(double baseFont)
        {
            Dictionary<Tuple<double, double>, double> marginMap = new Dictionary<Tuple<double, double>, double>();
            marginMap.Add(new Tuple<double, double>(0, 10), 6);
            marginMap.Add(new Tuple<double, double>(10, 24), 5);
            marginMap.Add(new Tuple<double, double>(24, 100), 4);

            var marginResults = marginMap.FirstOrDefault(x => x.Key.Item1 <= baseFont && x.Key.Item2 >= baseFont);
            if (marginResults.Key != null)
            {
                return marginResults.Value;
            }

            return 5;
        }
    }
}
