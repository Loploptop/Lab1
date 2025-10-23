using System;

namespace DeviceManagement
{
    public class Printer : Device
    {
        private int consumption;

        public Printer(string b, string m, float p, int y, int bc)
            : base(b, m, p, y)
        {
            consumption = bc;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Потребление: {consumption} Вт");
            Console.WriteLine();
        }

        public int Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }
    }
}