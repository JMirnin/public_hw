using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_Homework
{
    class Program
    {
        static void Main(string[] args)
        {

            //Анатолий Толстых.

            //Задание 1.
//            а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры.
//            б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
//            в) Добавить диалог с использованием switch демонстрирующий работу класса.



            Complex complex1 = new Complex(2, 3);
            Complex complex2 = new Complex(-1, 1);

            Console.WriteLine($"Имеются комплексные числа {complex1.Print()} и {complex2.Print()}. \n" +
                $"Нажмите '+', чтобы сложить их, '-' чтобы вычесть и '*' чтобы перемножить.");
            var userKey = Console.ReadLine();

            switch (userKey)
            {
                case "+": Console.WriteLine($"({complex1.Print()}) + ({complex2.Print()}) = {Complex.Sum(complex1, complex2).Print()}");
                    break;
                case "-": Console.WriteLine($"({complex1.Print()}) - ({complex2.Print()}) = {Complex.Minus(complex1, complex2).Print()}");
                    break;
                case "*": Console.WriteLine($"({complex1.Print()}) * ({complex2.Print()}) = {Complex.Mult(complex1, complex2).Print()}");
                    break;
                default: Console.WriteLine("Вы нажали какую-то ерунду");
                    break;
            }

            Console.ReadKey();


        }
    }
}
