using DeviceManagement;
using Xunit;
using System;
using System.IO;

namespace DeviceManagement.Tests
{
    public class PrinterTests
    {
        [Fact]
        public void Printer_Constructor_CreatesObjectWithCorrectValues()
        {
            // Arrange & Act
            var printer = new Printer("HP", "LaserJet", 299.99f, 2023, 500);

            // Assert
            Assert.Equal("HP", printer.Brand);
            Assert.Equal("LaserJet", printer.Model);
            Assert.Equal(299.99f, printer.Price);
            Assert.Equal(2023, printer.Year);
            Assert.Equal(500, printer.Consumption);
        }

        [Fact]
        public void Printer_ConsumptionProperty_SetAndGetCorrectValue()
        {
            // Arrange
            var printer = new Printer("Canon", "PIXMA", 199.99f, 2022, 300);

            // Act
            printer.Consumption = 450;

            // Assert
            Assert.Equal(450, printer.Consumption);
        }
        [Fact]
        public void Printer_PrintInfo_OutputsCorrectInformation()
        {
            // Arrange
            var printer = new Printer("Epson", "WorkForce", 399.99f, 2024, 600);

            using var output = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(output);

            // Act
            printer.PrintInfo();
            Console.SetOut(originalOut);

            // Assert
            var result = output.ToString();
            Assert.Contains("Производитель: Epson", result);
            Assert.Contains("Модель: WorkForce", result);
            Assert.Contains("Цена: 399", result);  // Ищем часть числа
            Assert.Contains("Год: 2024", result);
            Assert.Contains("Потребление: 600 Вт", result);
        }

        [Fact]
        public void Printer_IsSubclassOfDevice_ReturnsTrue()
        {
            // Arrange
            var printer = new Printer("Brother", "HL-L2340DW", 149.99f, 2023, 350);

            // Act & Assert
            Assert.IsAssignableFrom<Device>(printer);
        }
    }
}