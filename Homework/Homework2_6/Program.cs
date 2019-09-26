using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    class Program
    {

        //Анатолий Толстых
        //
        //6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
        //    «Хорошим» называется число, которое делится на сумму своих цифр.
        //    Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

        static int SumDigit(int n)
        {
            int sum = 0;
            do
            {
                sum += (n % 10);
                n /= 10;
            }
            while (n > 0);
            return sum;
        }

            static void Main(string[] args)
        {

            DateTime start = DateTime.Now;

            int count = 0;
            for (int n = 1; n <= 1000000000; n++)
            {
                if (n % SumDigit(n) == 0)
                {
                    count++;
                }
            }
               

            DateTime end = DateTime.Now;
            Console.WriteLine($"Найдено {count} 'хороших' чисел. Потребовалось {(end - start).TotalSeconds} секунд");
            Console.ReadLine();

        }
    }
}
