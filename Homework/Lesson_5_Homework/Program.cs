using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lesson_5_Homework
{
    //Анатолий Толстых

    //Задание 1.
    //    Создать программу, которая будет проверять корректность ввода логина.
    //    Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    //    б) ** с использованием регулярных выражений.

    class Program
    {
        static void Main(string[] args)
        {

            Regex logEx = new Regex(@"^[a-zA-Z]{1}[a-zA-Z0-9]{1,9}$");

            Console.Write("Введите логин: ");
            if (logEx.IsMatch(Console.ReadLine())) 
            {
                Console.WriteLine("Логин корректный");
            }
            else
            {
                Console.WriteLine("Логин некорретный");
            }

            Console.ReadKey();

        }
    }
}
