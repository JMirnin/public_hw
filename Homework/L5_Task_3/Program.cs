using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace L5_Task_3
{

    //  Анатолий Толстых

    //  Задание 3.
    //  * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
    //  Например:
    //  badc являются перестановкой abcd.


    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите первую строку: ");
            string string1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string string2 = Console.ReadLine();

            bool ident = CheckSymbols(string1, string2);

            if (ident)
            {
                Console.WriteLine("Строки являются перестановкой друг друга.");
            }
            else
            {
                Console.WriteLine("Строки не переставлены, они разные.");
            }

            Console.ReadKey();
        }

        static bool CheckSymbols(string string1, string string2)
        {
            Regex regex = new Regex(@"(.)"); //разбиваем на массив символов
            string[] array1 = regex.Split(string1);
            string[] array2 = regex.Split(string2);

            //сортируем массив
            Array.Sort(array1);
            Array.Sort(array2);

            //составляем в новые строки и сравниваем
            return (String.Join("", array1) == String.Join("", array2));

        }
    }
}
