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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxX.Text))
            {
                MessageBox.Show("Введите значение X.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double x;
            if (!double.TryParse(TextBoxX.Text, out x))
            {
                MessageBox.Show("Неверный формат числа.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result = 0;
            if (RadioSh.IsChecked == true)
            {
                result = Math.Sinh(x);
            }
            else if (RadioPow.IsChecked == true)
            {
                result = x * x;
            }
            else if (RadioExp.IsChecked == true)
            {
                result = Math.Exp(x);
            }
            else
            {
                MessageBox.Show("Выберите функцию.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TextBoxResult.Text = result.ToString("F4");
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxX.Clear();
            TextBoxResult.Clear();
            RadioSh.IsChecked = false;
            RadioPow.IsChecked = false;
            RadioExp.IsChecked = false;
            TextBoxX.Focus();
        }
    }
}
