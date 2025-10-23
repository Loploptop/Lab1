using DeviceManagement;
using Xunit;
using System;
using System.IO;

namespace DeviceManagement.Tests
{
    public class DeviceTests
    {
        [Fact]
        public void Device_Constructor_DefaultParameters_CreatesObject()
        {
            // Arrange & Act
            var device = new Device();

            // Assert
            Assert.NotNull(device);
            Assert.Equal("", device.Brand);
            Assert.Equal("", device.Model);
            Assert.Equal(0.0f, device.Price);
            Assert.Equal(2020, device.Year);
        }

        [Fact]
        public void Device_Constructor_WithParameters_CreatesObjectWithCorrectValues()
        {
            // Arrange & Act
            var device = new Device("Samsung", "Galaxy", 999.99f, 2023);

            // Assert
            Assert.Equal("Samsung", device.Brand);
            Assert.Equal("Galaxy", device.Model);
            Assert.Equal(999.99f, device.Price);
            Assert.Equal(2023, device.Year);
        }

        [Theory]
        [InlineData("Apple", "iPhone", 1200.50f, 2024)]
        [InlineData("Xiaomi", "Redmi", 300.75f, 2022)]
        [InlineData("", "", 0f, 2020)]
        public void Device_Properties_SetAndGetCorrectValues(string brand, string model, float price, int year)
        {
            // Arrange
            var device = new Device();

            // Act
            device.Brand = brand;
            device.Model = model;
            device.Price = price;
            device.Year = year;

            // Assert
            Assert.Equal(brand, device.Brand);
            Assert.Equal(model, device.Model);
            Assert.Equal(price, device.Price);
            Assert.Equal(year, device.Year);
        }

        [Fact]
        public void Device_PrintInfo_OutputsCorrectInformation()
        {
            // Arrange
            var device = new Device("Dell", "XPS 13", 1500.00f, 2023);

            using var output = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(output);

            // Act
            device.PrintInfo();
            Console.SetOut(originalOut);

            // Assert
            var result = output.ToString();
            Assert.Contains("Производитель: Dell", result);
            Assert.Contains("Модель: XPS 13", result);
            Assert.Contains("Цена: 1500", result);  // Ищем часть числа
            Assert.Contains("Год: 2023", result);
        }
    }
}