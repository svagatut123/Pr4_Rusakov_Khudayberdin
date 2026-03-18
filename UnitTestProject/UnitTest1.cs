using Microsoft.VisualStudio.TestTools.UnitTesting;
using Практическая4_Русаков_Худайбердин;
using System;

namespace UnitTestProject
{
    /// <summary>
    /// Класс модульных тестов для Практической работы 4
    /// Вариант 2 - Русаков, Худайбердин
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Тест 1: Проверка формулы Страницы 1 (Тренировочный)
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange (Подготовка)
            double x = 1.0;
            double y = 2.0;
            double z = 0.5;
            double expected = -3.1782; // Исправленное значение

            // Act (Действие)
            double actual = Functions.CalculatePage1(x, y, z);

            // Assert (Проверка)
            Assert.AreEqual(expected, actual, 0.0001, "Ошибка в формуле 1");
        }

        /// <summary>
        /// Тест 2: Проверка функции Страницы 2 (sh(x))
        /// </summary>
        [TestMethod]
        public void TestFunctionPage2()
        {
            // Arrange
            double x = 1.0;
            int type = 1; // sh(x)
            double expected = 1.1752;

            // Act
            double actual = Functions.CalculatePage2(x, type);

            // Assert
            Assert.AreEqual(expected, actual, 0.0001, "Ошибка в функции sh(x)");
        }

        /// <summary>
        /// Тест 3: Проверка формулы Страницы 3
        /// </summary>
        [TestMethod]
        public void TestFunctionPage3()
        {
            // Arrange
            double x = 1.0;
            double a = 2.0;
            double b = 1.0;
            double expected = 4.2619; // Исправленное значение

            // Act
            double actual = Functions.CalculatePage3(x, a, b);

            // Assert
            Assert.AreEqual(expected, actual, 0.0001, "Ошибка в формуле 3");
        }

        /// <summary>
        /// Тест 4: Проверка исключения (как в примере с BankAccount в Части 1)
        /// </summary>
        [TestMethod]
        public void TestExceptionStep()
        {
            // Arrange
            double dx = 0.0;

            // Act & Assert
            try
            {
                Functions.CheckStep(dx);
                Assert.Fail("Исключение не было выброшено");
            }
            catch (ArgumentException ex)
            {
                // Проверяем текст ошибки
                StringAssert.Contains(ex.Message, Functions.InvalidStepMessage);
                return;
            }
            Assert.Fail("Исключение не было выброшено");
        }
    }
}