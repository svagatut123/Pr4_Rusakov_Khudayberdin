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
    /// Страница 3: Циклический расчёт и график (Вариант 2)
    /// </summary>
    public partial class Page3 : Page
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса Page3
        /// </summary>
        public Page3()
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
            if (!ValidateInputs(TextBoxX0, TextBoxXk, TextBoxDx, TextBoxA, TextBoxB))
                return;

            double x0 = double.Parse(TextBoxX0.Text);
            double xk = double.Parse(TextBoxXk.Text);
            double dx = double.Parse(TextBoxDx.Text);
            double a = double.Parse(TextBoxA.Text);
            double b = double.Parse(TextBoxB.Text);

            if (dx <= 0)
            {
                MessageBox.Show("Шаг функции должен быть больше нуля.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Проверка шага через класс Functions
                Functions.CheckStep(dx);

                TextBoxResult.Clear();
                CanvasChart.Children.Clear();

                string output = "X\t\tY\n";

                for (double x = x0; x <= xk; x += dx)
                {
                    // Вызов метода из класса Functions
                    double y = Functions.CalculatePage3(x, a, b);
                    output += string.Format("{0:F2}\t{1:F4}\n", x, y);
                }

                TextBoxResult.Text = output;
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
            TextBoxX0.Clear();
            TextBoxXk.Clear();
            TextBoxDx.Clear();
            TextBoxA.Clear();
            TextBoxB.Clear();
            TextBoxResult.Clear();
            CanvasChart.Children.Clear();
            TextBoxX0.Focus();
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
