using System;

namespace DeviceManagement
{
    public class Scanner : Device
    {
        private float paperCapacity;

        public Scanner(string b, string m, float p, int y, float ss)
            : base(b, m, p, y)
        {
            paperCapacity = ss;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Кол-во листов: {paperCapacity} штук");
            Console.WriteLine();
        }

        public float PaperCapacity
        {
            get { return paperCapacity; }
            set { paperCapacity = value; }
        }
    }
}