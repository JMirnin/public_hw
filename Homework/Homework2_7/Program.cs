using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7
{
    class Program
    {   

        //Анатолий Толстых
        //
        //7.
        //
        //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

        static void Main(string[] args)
        {
            Console.Write("Введите начальное число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите конечное число: ");
            int b = Convert.ToInt32(Console.ReadLine());

      
            int sum = GetSum(a, b);
            Console.WriteLine("Сумма чисел между указанными (включительно) равна " + sum);
            Console.ReadLine();
        }

        static int GetSum(int a, int b)
        {
            if (a < b)
            {
                return a + GetSum(a + 1, b);
            }
            else
            {
                return a;
            }
        }
    }
}
