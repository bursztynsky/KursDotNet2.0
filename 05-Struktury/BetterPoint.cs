using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Struktury
{
    internal struct BetterPoint
    {
        public int X;
        public int Y;

        // Robie konstuktor ktory przyjmuje x i y i jest ustawia
        // W ten sposob ZMUSZCZAM programiste do tego, ze musi zawsze
        // tworzac strukture slowem 'new' podac ten x i y ZAWSZE
        public BetterPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double GetDistance(BetterPoint point)
        {
            return Math.Sqrt(
                Math.Pow(point.X - X, 2) +
                Math.Pow(point.Y - Y, 2)
                );
        }
        public void Print()
        {
            Console.WriteLine("Moj punkt ma: X=" + X + " Y=" + Y);
        }
    }
}
