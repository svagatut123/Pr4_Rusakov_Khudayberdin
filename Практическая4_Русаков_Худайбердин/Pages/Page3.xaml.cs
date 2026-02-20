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

        private double CalcY(double x, double a, double b)
        {
            return 1.2 * Math.Pow(a - b, 3) / Math.Exp(x / 2) + x;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = double.Parse(TbA.Text.Replace(",", "."));
                double b = double.Parse(TbB.Text.Replace(",", "."));
                double x0 = double.Parse(TbX0.Text.Replace(",", "."));
                double xk = double.Parse(TbXk.Text.Replace(",", "."));
                double dx = double.Parse(TbDx.Text.Replace(",", "."));

                TbResult.Clear();
                ChartCanvas.Children.Clear();

                double x = x0;
                double minY = double.MaxValue;
                double maxY = double.MinValue;
                string output = "";

                // Первый проход для поиска границ Y
                for (double i = x0; i <= xk; i += dx)
                {
                    double y = CalcY(i, a, b);
                    if (y < minY) minY = y;
                    if (y > maxY) maxY = y;
                }

                // Второй проход для вывода и рисования
                int pointIndex = 0;
                for (double i = x0; i <= xk; i += dx)
                {
                    double y = CalcY(i, a, b);
                    output += $"x={i:F2}, y={y:F6}\n";

                    // Рисование точек на Canvas
                    double canvasWidth = ChartCanvas.ActualWidth;
                    double canvasHeight = ChartCanvas.ActualHeight;

                    if (canvasWidth > 0 && canvasHeight > 0)
                    {
                        double rangeX = xk - x0;
                        double rangeY = maxY - minY;
                        if (rangeX == 0) rangeX = 1;
                        if (rangeY == 0) rangeY = 1;

                        double px = (i - x0) / rangeX * canvasWidth;
                        double py = canvasHeight - ((y - minY) / rangeY * canvasHeight);

                        Ellipse dot = new Ellipse
                        {
                            Width = 3,
                            Height = 3,
                            Fill = System.Windows.Media.Brushes.Blue
                        };
                        Canvas.SetLeft(dot, px);
                        Canvas.SetTop(dot, py);
                        ChartCanvas.Children.Add(dot);
                    }
                    pointIndex++;
                }

                TbResult.Text = output;
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbA.Clear();
            TbB.Clear();
            TbX0.Clear();
            TbXk.Clear();
            TbDx.Clear();
            TbResult.Clear();
            ChartCanvas.Children.Clear();
        }
    }
}
