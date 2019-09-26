using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Print_information
{
    class Program
    {

        //Анатолий Толстых.

        //а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
        //б) *Сделать задание, только вывод организовать в центре экрана.
        //в) **Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).

        static void Main(string[] args)
        {
            string name = "Анатолий";
            string surname = "Толстых";
            string city = "Москва";

            //вывод по центру окна консоли. Параметры - "текст", "по центру Х" и "по центру Y"
            Print($"{name} {surname}, {city}", true, true);

            //вывод с явным указанием координат
            Print($"{name} {surname}, {city}", 10, 20);

            Console.ReadLine();
    
        }

        static void Print(string ms, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(ms);
        }

        static void Print(string ms, bool centerX, bool centerY)
        {
            int x = 0;
            int y = 0;
            if (centerX) {
                x = (Console.WindowWidth - ms.Length) / 2;
            }
            if (centerY) {
                y = Console.WindowHeight / 2;
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine(ms);

        }
    }
}
