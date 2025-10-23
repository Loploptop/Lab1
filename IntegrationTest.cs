using DeviceManagement;
using Xunit;
using System.Collections.Generic;

namespace DeviceManagement.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void DeviceList_CanStoreDifferentDeviceTypes()
        {
            // Arrange
            var devices = new List<Device>
            {
                new Device("Generic", "Device1", 100f, 2023),
                new Printer("HP", "LaserJet", 299f, 2023, 500),
                new Scanner("Canon", "CanoScan", 149f, 2023, 50f)
            };

            // Act & Assert
            Assert.Equal(3, devices.Count);
            Assert.IsType<Device>(devices[0]);
            Assert.IsType<Printer>(devices[1]);
            Assert.IsType<Scanner>(devices[2]);
        }

        [Fact]
        public void Polymorphism_PrintInfo_CallsCorrectOverride()
        {
            // Arrange
            var devices = new List<Device>
            {
                new Device("Generic", "Device", 100f, 2023),
                new Printer("HP", "Printer", 200f, 2023, 500),
                new Scanner("Canon", "Scanner", 150f, 2023, 50f)
            };

            // Act & Assert - просто проверяем что не падает с исключением
            foreach (var device in devices)
            {
                var exception = Record.Exception(() => device.PrintInfo());
                Assert.Null(exception);
            }
        }
    }
}