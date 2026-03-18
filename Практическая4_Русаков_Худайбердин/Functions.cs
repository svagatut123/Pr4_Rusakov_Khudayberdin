using System;

namespace Практическая4_Русаков_Худайбердин
{
    /// <summary>
    /// Класс для хранения математических функций варианта 2
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Сообщение об ошибке: деление на ноль
        /// </summary>
        public const string DivideByZeroMessage = "Деление на ноль";

        /// <summary>
        /// Сообщение об ошибке: неверный шаг
        /// </summary>
        public const string InvalidStepMessage = "Шаг должен быть больше нуля";

        /// <summary>
        /// Вычисляет формулу для Страницы 1 (Вариант 2)
        /// υ = √(8+|x−y|²+1)/(3x²+y²+2) − e^|x−y|(tg²z+1)x
        /// </summary>
        /// <param name="x">Значение X</param>
        /// <param name="y">Значение Y</param>
        /// <param name="z">Значение Z</param>
        /// <returns>Результат вычисления</returns>
        /// <exception cref="DivideByZeroException">
        /// Выбрасывается при делении на ноль
        /// </exception>
        public static double CalculatePage1(double x, double y, double z)
        {
            double absXY = Math.Abs(x - y);
            double denominator = 3 * x * x + y * y + 2;

            if (denominator == 0)
            {
                throw new DivideByZeroException(DivideByZeroMessage);
            }

            double numerator = Math.Sqrt(8 + Math.Pow(absXY, 2) + 1);
            double tanZ = Math.Tan(z);
            double term2 = Math.Exp(absXY) * (Math.Pow(tanZ, 2) + 1) * x;

            return (numerator / denominator) - term2;
        }

        /// <summary>
        /// Вычисляет формулу для Страницы 2 (Выбор функции)
        /// </summary>
        /// <param name="x">Значение X</param>
        /// <param name="type">Тип функции (1-sh, 2-pow, 3-exp)</param>
        /// <returns>Результат вычисления</returns>
        public static double CalculatePage2(double x, int type)
        {
            if (type == 1) return Math.Sinh(x);
            if (type == 2) return x * x;
            if (type == 3) return Math.Exp(x);
            return 0;
        }

        /// <summary>
        /// Вычисляет формулу для Страницы 3 (Цикл)
        /// y = 1.2(a − b)³e^(x²) + x
        /// </summary>
        /// <param name="x">Значение X</param>
        /// <param name="a">Параметр a</param>
        /// <param name="b">Параметр b</param>
        /// <returns>Результат вычисления</returns>
        public static double CalculatePage3(double x, double a, double b)
        {
            return 1.2 * Math.Pow(a - b, 3) * Math.Exp(x * x) + x;
        }

        /// <summary>
        /// Проверяет шаг функции
        /// </summary>
        /// <param name="dx">Шаг</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается если шаг меньше или равен нулю
        /// </exception>
        public static void CheckStep(double dx)
        {
            if (dx <= 0)
            {
                throw new ArgumentException(InvalidStepMessage);
            }
        }
    }
}