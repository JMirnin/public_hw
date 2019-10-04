using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_3_Homework

//      Анатолий Толстых.

//      Дан  целочисленный массив  из 20 элементов.Элементы массива  могут принимать  целые значения  от –10 000 до 10 000 включительно.
//      Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
//      В данной задаче под парой подразумевается два подряд идущих элемента массива.Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 

//      Реализуйте задачу в виде статического класса StaticClass;
//      а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
//      б) * Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
//      в)** Добавьте обработку ситуации отсутствия файла на диске.
 
{
    static class StaticClass
    {

        /// <summary>
        /// Получет количество пар стоящих рядом чисел массива, в которых одно число делится без остатка на указанный делитель
        /// </summary>
        /// <param name="numbers">Массив чисел</param>
        /// <param name="denominator">Делитель</param>
        /// <returns></returns>
        public static int GetCount(int[] numbers, int denominator)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {

                //сначала проверяем, делится ли само число без остатка, затем проверяем чтобы следующее за ним не делилось.
                //проверка на вхождение i + 1 нужна для того, чтобы исключить ошибку на последнем элементе 
                //проверка на вхождение происходит раньше, чем проверка на деление следующего члена массива, в случае неудачи дальнейшая проверка проходить не будет, т.е. можно указать условия в одну строку
                //    (можно использовать try, но в этом нет особого смысла, взаимодействия с пользователем всё равно нет, а быстродействие пострадает)
                if (numbers[i] % denominator == 0 && i + 1 < numbers.Length && numbers[i + 1] % denominator != 0)
                {
                    count++;
                }
                //если само число не делится, проверяем, делится ли следующее за ним
                else if (numbers[i] % denominator != 0 && i + 1 < numbers.Length && numbers[i + 1] % denominator == 0)
                {
                    count++;
                }
            }

            return count;

        }

        /// <summary>
        /// Возвращает массив чисел из текстового файла
        /// </summary>
        /// <param name="path">Путь к файлу с числами, разделенными запятыми.</param>
        /// <returns></returns>
        public static int[] ReadArray(string path)
        {

            //в случае ошибки вернём пустой массив
            int[] array = new int[0];

            try
            {
                StreamReader sr = new StreamReader("array.txt");
                string arrayString = sr.ReadLine();
                array = arrayString.Split(Convert.ToChar(",")).Select(int.Parse).ToArray(); //разбиваем строку и преобразовываем значения в числовые
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Ошибка FileNotFoundException {e.Message}");

            }
            catch (FormatException e)
            {
                Console.WriteLine($"Ошибка FormatException {e.Message}");
            }

            return array;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = StaticClass.ReadArray("array.txt");

            int count = StaticClass.GetCount(numbers, 3);

            Console.WriteLine($"Массив: {String.Join(", ", numbers)}");
            Console.WriteLine($"Пар чисел, соответствующих условию: {count}");
            Console.ReadLine();
        }
    }
}
