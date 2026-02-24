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

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs(TextBoxX, TextBoxY, TextBoxZ))
                return;

            double x = double.Parse(TextBoxX.Text);
            double y = double.Parse(TextBoxY.Text);
            double z = double.Parse(TextBoxZ.Text);
            double result;

            try
            {
                double absXY = Math.Abs(x - y);
                double numerator = Math.Sqrt(8 + Math.Pow(absXY, 2) + 1);
                double denominator = 3 * x * x + y * y + 2;

                if (denominator == 0)
                    throw new DivideByZeroException("Деление на ноль в знаменателе.");

                double tanZ = Math.Tan(z);
                double term2 = Math.Exp(absXY) * (Math.Pow(tanZ, 2) + 1) * x;

                result = (numerator / denominator) - term2;

                TextBoxResult.Text = result.ToString("F4");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка вычисления: " + ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxX.Clear();
            TextBoxY.Clear();
            TextBoxZ.Clear();
            TextBoxResult.Clear();
            TextBoxX.Focus();
        }

        private bool ValidateInputs(params TextBox[] boxes)
        {
            foreach (var box in boxes)
            {
                if (string.IsNullOrEmpty(box.Text))
                {
                    MessageBox.Show("Заполните все поля ввода.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    box.Focus();
                    return false;
                }

                if (!double.TryParse(box.Text, out _))
                {
                    MessageBox.Show("Неверный формат числа.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    box.Focus();
                    return false;
                }
            }
            return true;
        }
    }
}
