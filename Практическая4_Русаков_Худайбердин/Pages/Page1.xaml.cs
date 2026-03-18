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
    /// Страница 1: Расчёт математической функции (Вариант 2)
    /// </summary>
    public partial class Page1 : Page
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса Page1
        /// </summary>
        public Page1()
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
            if (!ValidateInputs(TextBoxX, TextBoxY, TextBoxZ))
                return;

            double x = double.Parse(TextBoxX.Text);
            double y = double.Parse(TextBoxY.Text);
            double z = double.Parse(TextBoxZ.Text);

            try
            {
                // Вызов метода из класса Functions
                double result = Functions.CalculatePage1(x, y, z);
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
            TextBoxY.Clear();
            TextBoxZ.Clear();
            TextBoxResult.Clear();
            TextBoxX.Focus();
        }

        /// <summary>
        /// Проверяет заполненность и корректность полей ввода
        /// </summary>
        /// <param name="boxes">Массив TextBox для проверки</param>
        /// <returns>True если все поля корректны, иначе False</returns>
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