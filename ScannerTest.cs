using DeviceManagement;
using Xunit;
using System;
using System.IO;

namespace DeviceManagement.Tests
{
    public class ScannerTests
    {
        [Fact]
        public void Scanner_Constructor_CreatesObjectWithCorrectValues()
        {
            // Arrange & Act
            var scanner = new Scanner("Canon", "CanoScan", 149.99f, 2023, 50.5f);

            // Assert
            Assert.Equal("Canon", scanner.Brand);
            Assert.Equal("CanoScan", scanner.Model);
            Assert.Equal(149.99f, scanner.Price);
            Assert.Equal(2023, scanner.Year);
            Assert.Equal(50.5f, scanner.PaperCapacity);
        }

        [Fact]
        public void Scanner_PaperCapacityProperty_SetAndGetCorrectValue()
        {
            // Arrange
            var scanner = new Scanner("Epson", "Perfection", 129.99f, 2022, 30.0f);

            // Act
            scanner.PaperCapacity = 75.5f;

            // Assert
            Assert.Equal(75.5f, scanner.PaperCapacity);
        }

        [Fact]
        public void Scanner_PrintInfo_OutputsCorrectInformationInRussian()
        {
            // Arrange
            var scanner = new Scanner("Fujitsu", "ScanSnap", 299.99f, 2024, 100.0f);

            using var output = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(output);

            // Act
            scanner.PrintInfo();
            Console.SetOut(originalOut);

            // Assert
            var result = output.ToString();
            Assert.Contains("Производитель: Fujitsu", result);
            Assert.Contains("Модель: ScanSnap", result);
            Assert.Contains("Цена: 299", result);  // Ищем часть числа
            Assert.Contains("Год: 2024", result);
            Assert.Contains("Кол-во листов: 100 штук", result);
        }

        [Fact]
        public void Scanner_IsSubclassOfDevice_ReturnsTrue()
        {
            // Arrange
            var scanner = new Scanner("Brother", "ADS-2700W", 199.99f, 2023, 50.0f);

            // Act & Assert
            Assert.IsAssignableFrom<Device>(scanner);
        }
    }
}