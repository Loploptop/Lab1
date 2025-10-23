using System;
using System.Collections.Generic;
using System.Reflection;

namespace DeviceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Установка локализации для русского языка
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Список для хранения устройств (в C# используется List вместо std::list)
            List<Device> devices = new List<Device>();

            int mainChoice, deviceChoice;
            string brand, model;
            float price, paperCapacity;
            int year, consumption;

            while (true)
            {
                Console.WriteLine("1 - Добавить новое устройство");
                Console.WriteLine("2 - Вывести список устройств");
                Console.WriteLine("3 - Завершить работу программы");
                Console.Write("Выберите действие: ");

                // Безопасный ввод числа
                if (!int.TryParse(Console.ReadLine(), out mainChoice))
                {
                    Console.WriteLine("Ошибка ввода! Пожалуйста, введите число.");
                    continue;
                }

                if (mainChoice == 3)
                {
                    break; // Выход из программы
                }

                Device newDevice = null; // Инициализация перед switch

                if (mainChoice == 1)
                {
                    Console.Write("Выберите тип объекта для создания (1 - Устройство, 2 - Принтер, 3 - Сканер): ");

                    if (!int.TryParse(Console.ReadLine(), out deviceChoice))
                    {
                        Console.WriteLine("Ошибка ввода! Пожалуйста, введите число.");
                        continue;
                    }

                    Console.Write("Введите бренд: ");
                    brand = Console.ReadLine();

                    Console.Write("Введите модель: ");
                    model = Console.ReadLine();

                    Console.Write("Введите цену: ");
                    if (!float.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Ошибка ввода цены!");
                        continue;
                    }

                    Console.Write("Введите год: ");
                    if (!int.TryParse(Console.ReadLine(), out year))
                    {
                        Console.WriteLine("Ошибка ввода года!");
                        continue;
                    }

                    // Создание объекта в зависимости от выбора пользователя
                    switch (deviceChoice)
                    {
                        case 1:
                            newDevice = new Device(brand, model, price, year);
                            break;
                        case 2:
                            Console.Write("Введите потребляемую энергию: ");
                            if (!int.TryParse(Console.ReadLine(), out consumption))
                            {
                                Console.WriteLine("Ошибка ввода потребляемой энергии!");
                                continue;
                            }
                            newDevice = new Printer(brand, model, price, year, consumption);
                            break;
                        case 3:
                            Console.Write("Введите кол-во бумаги: ");
                            if (!float.TryParse(Console.ReadLine(), out paperCapacity))
                            {
                                Console.WriteLine("Ошибка ввода количества бумаги!");
                                continue;
                            }
                            newDevice = new Scanner(brand, model, price, year, paperCapacity);
                            break;
                        default:
                            Console.WriteLine("Неверный выбор типа устройства!");
                            continue;
                    }

                    if (newDevice != null)
                    {
                        devices.Add(newDevice);
                        Console.WriteLine("Устройство успешно добавлено!\n");
                    }
                }
                else if (mainChoice == 2)
                {
                    // Вывод списка устройств
                    Console.WriteLine("\nСписок устройств:");
                    if (devices.Count == 0)
                    {
                        Console.WriteLine("Список устройств пуст.\n");
                    }
                    else
                    {
                        foreach (Device device in devices)
                        {
                            device.PrintInfo();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Неверный выбор! Пожалуйста, выберите 1, 2 или 3.\n");
                }
            }

            // В C# сборка мусора автоматическая, но для демонстрации очищаем список
            devices.Clear();
            Console.WriteLine("Программа завершена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}