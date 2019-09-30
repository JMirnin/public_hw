using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{

    //  Анатолий Толстых

    //    Задание 2.

    //    а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел.Сами числа и сумму вывести на экран, используя tryParse.

    class Program
    {
        static void Main(string[] args)
        {
            int number;
            int summ = 0;
            string result = "Сумма нечетных положительных чисел (";
 
            do
            {
                Console.Write("Введите число для сложения или 0 чтобы прекратить ввод: ");
               
                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    if (number % 2 > 0)   //проверку на положительное можно не делать, т.к. у отрицательных и остаток от деления будет меньше нуля
                    {
                        result += $"{number}, ";
                        summ += number;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Введены некорректные данные.");
                    number = -1;      //переназначаем возвращенный в TryParse 0, чтобы не прерывать цикл
                }

            } while (number != 0);

            result = result.Substring(0, result.Length - 2) + $") равна {summ}";  //немного причесываем строку результата, убирая последнюю запятую в перечислении чисел и заканчивая предложение

            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
