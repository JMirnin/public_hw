using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    class Program
    {
        //Анатолий Толстых
        //
        //5.
        //а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
        //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

        static void Main(string[] args)
        {
            Console.Write("Укажите Ваш рост в метрах: ");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.Write("Укажите Ваш вес в килограммах: ");
            double m = Convert.ToDouble(Console.ReadLine());

            double massIndex = GetMassIndex(h, m);
            Console.WriteLine("\n Индекс массы тела равен: {0}", String.Format("{0:f2}", massIndex));

            if (massIndex < 18.5)
            {
                Console.WriteLine($"Дружище, тебе нужно набрать вес! Хотя бы ещё {Math.Round(18.5 * h * h - m)} кг.");
            } 
            else if (massIndex > 25)
            {
                Console.WriteLine($"Да ты толстяк! Сбрось хотя бы {Math.Round(m - 25 * h * h)} кг.");
            }
            else
            {
                Console.WriteLine("Всё в норме, так держать!");
            }
            Console.ReadLine();

        }

        static double GetMassIndex(double h, double m)
        {
            return m / (h * h);
        }
    }
 
}
