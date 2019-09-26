using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Mass_index
{
    class Program
    {

        //Анатолий Толстых.

        //a) Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I = m / (h * h); где m — масса тела в килограммах, h — рост в метрах.
        //б) Оформить вычисление расстояния между точками в виде метода.



        static void Main(string[] args)
        {
            Console.Write("Укажите Ваш рост в метрах: ");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.Write("Укажите Ваш вес в килограммах: ");
            double m = Convert.ToDouble(Console.ReadLine());

            //выводим на экран с точностью до сотых
            Console.WriteLine("\n Индекс массы тела равен: {0}", String.Format("{0:f2}", GetMassIndex(h, m)));

            Console.ReadLine();

        }

        static double GetMassIndex(double h, double m)
        {
            return m / (h * h);
        }
    }
}
