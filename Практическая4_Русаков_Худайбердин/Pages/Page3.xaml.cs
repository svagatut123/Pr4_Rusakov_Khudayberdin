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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

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

            TextBoxResult.Clear();
            CanvasChart.Children.Clear();

            string output = "X\t\tY\n";
            double maxX = double.MinValue;
            double minX = double.MaxValue;
            double maxY = double.MinValue;
            double minY = double.MaxValue;

            List<Point> points = new List<Point>();

            for (double x = x0; x <= xk; x += dx)
            {
                double y = 1.2 * Math.Pow(a - b, 3) * Math.Exp(x * x) + x;

                output += string.Format("{0:F2}\t{1:F4}\n", x, y);

                if (x > maxX) maxX = x;
                if (x < minX) minX = x;
                if (y > maxY) maxY = y;
                if (y < minY) minY = y;

                points.Add(new Point(x, y));
            }

            TextBoxResult.Text = output;
            DrawChart(points, minX, maxX, minY, maxY);
        }

        private void DrawChart(List<Point> points, double minX, double maxX, double minY, double maxY)
        {
            if (points.Count < 2) return;

            double width = CanvasChart.ActualWidth;
            double height = CanvasChart.ActualHeight;
            double padding = 20;

            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            if (rangeX == 0) rangeX = 1;
            if (rangeY == 0) rangeY = 1;

            Polyline polyline = new Polyline();
            polyline.Stroke = Brushes.Blue;
            polyline.StrokeThickness = 2;

            for (int i = 0; i < points.Count; i++)
            {
                double x = points[i].X;
                double y = points[i].Y;

                double canvasX = padding + ((x - minX) / rangeX) * (width - 2 * padding);
                double canvasY = (height - padding) - ((y - minY) / rangeY) * (height - 2 * padding);

                polyline.Points.Add(new System.Windows.Point(canvasX, canvasY));
            }

            CanvasChart.Children.Add(polyline);
        }

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
