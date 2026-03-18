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
using Практическая4_Русаков_Худайбердин;

namespace Практическая4_Русаков_Худайбердин
{
    /// <summary>
    /// Страница 2: Выбор функции (Вариант 2)
    /// </summary>
    public partial class Page2 : Page
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса Page2
        /// </summary>
        public Page2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Вычислить"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
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

            // Определение типа функции
            int type = 0;
            if (RadioSh.IsChecked == true) type = 1;
            else if (RadioPow.IsChecked == true) type = 2;
            else if (RadioExp.IsChecked == true) type = 3;

            if (type == 0)
            {
                MessageBox.Show("Выберите функцию.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Вызов метода из класса Functions
                double result = Functions.CalculatePage2(x, type);
                TextBoxResult.Text = result.ToString("F4");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Очистить"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
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