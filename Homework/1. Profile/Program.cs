using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Profile
{
    class Program
    {

        //    Анатолий Толстых.

        //    Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
        //    а) используя склеивание;
        //    б) используя форматированный вывод;
        //    в) используя вывод со знаком $.


        static void Main(string[] args)
        {
            Console.WriteLine("Давайте заполним анкету с данными о себе.");
            Console.WriteLine("\n Как Ваше имя?");
            string name = Console.ReadLine();

            Console.WriteLine("\n Как Ваша фамилия?");
            string surname = Console.ReadLine();

            //значения ниже не конвертируем в числовые, т.к. всё равно не будем производить с ними никаких вычислений.
            Console.WriteLine("\n Сколько Вам лет?");
            string age = Console.ReadLine();

            Console.WriteLine("\n Каков Ваш рост?");
            string height = Console.ReadLine();

            Console.WriteLine("\n Каков Ваш вес?");
            string weight = Console.ReadLine();

            Console.WriteLine("\n Давайте теперь выведем Ваши данные на экран разными методами.");

            Console.WriteLine("\n Вывод с использованием склеивания строк:" +
                            "\n Вас зовут " + name + " " + surname + ", Вам " + age + " лет. Ваш рост: " + height + ", вес: " + weight);

            Console.WriteLine("\n Форматированный вывод:" +
                           "\n Вас зовут {0} {1}, Вам {2} лет. Ваш рост: {3}, вес: {4}", name, surname, age, height, weight);

            Console.WriteLine("\n Вывод с интерполяцией строк:" +
                          $"\n Вас зовут {name} {surname}, Вам {age} лет. Ваш рост: {height}, вес: {weight}");

            

            Console.ReadLine();


        }
    }
}
