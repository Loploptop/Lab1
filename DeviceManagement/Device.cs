using System;

namespace DeviceManagement
{
    public class Device
    {
        protected string brand;
        protected string model;
        protected float price;
        protected int year;

        public Device(string b = "", string m = "", float p = 0.0f, int y = 2020)
        {
            brand = b;
            model = m;
            price = p;
            year = y;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"\nПроизводитель: {brand}");
            Console.WriteLine($"Модель: {model}");
            Console.WriteLine($"Цена: {price}");
            Console.WriteLine($"Год: {year}");
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
    }
}