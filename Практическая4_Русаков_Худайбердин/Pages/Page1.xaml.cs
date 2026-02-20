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

namespace Практическая4_Русаков_Худайбердин
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(TbX.Text.Replace(",", "."));
                double y = double.Parse(TbY.Text.Replace(",", "."));
                double z = double.Parse(TbZ.Text.Replace(",", "."));

                double absXY = Math.Abs(x - y);
                double num = Math.Sqrt(8 + Math.Pow(absXY, 2) + 1);
                double den = 3 * Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + 2);
                double part2 = Math.Exp(absXY) * (Math.Pow(Math.Tan(z), 2) + 1) * x;

                double result = (num / den) - part2;
                TbResult.Text = result.ToString("F6");
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbX.Clear();
            TbY.Clear();
            TbZ.Clear();
            TbResult.Clear();
        }
    }
}
