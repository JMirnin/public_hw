using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Points_distance
{
    class Program
    {
        //Анатолий Толстых.

        //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
        //Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
        //б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.

        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты первой точки:");
            Console.Write("x: ");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            int y1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите координаты второй точки:");
            Console.Write("x: ");
            int x2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            int y2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nРасстояние между точками равно: {0}", String.Format("{0:f2}", GetDistance(x1, y1, x2, y2)));

            Console.ReadLine();
        }
        static double GetDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
