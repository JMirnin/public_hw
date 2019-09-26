using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        //Анатолий Толстых
        //ДЗ к уроку №2

        //1. Написать метод, возвращающий минимальное из трёх чисел.
        static int GetMinNumber(int a, int b, int c)
        {
            int min = a < b ? a : b;
            min = b < c ? b : c;
            return min;
        }


        //2. Написать метод подсчета количества цифр числа.
        static int DigitCount(int number)
        {

            //вариант решения через преобразование в строку
            string numString = Convert.ToString(number);
            return numString.Length;

            ////вариант решения через деление числа (тема же всё-таки про циклы):
            //      int count = 0;
            //      do
            //      {
            //          count++;
            //          number = number / 10;           //останется только целая часть, т.к. number - int
            //      } while (number > 0);
            //      return count;

        }


        //3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        static void Main(string[] args)
        {

            int sum = 0;
            int number = 0;   //объявляем здесь, а не внутри цикла, т.к. иначе пришлось бы реализовывать не через условие, а через break
            do
            {
                Console.Write("Введите число: ");
                number = Convert.ToInt32(Console.ReadLine());

                if (number > 0 && number % 2 != 0)
                {
                    sum += number;
                }
            } while (number != 0);

            Console.WriteLine($"Сумма нечетных положительных чисел равна: {sum}");
            Console.ReadKey();

        }
    }
}
