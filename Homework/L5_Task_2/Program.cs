using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace L5_Task_2
{
    //Анатолий Толстых

    //    Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
    //    а) Вывести только те слова сообщения,  которые содержат не более n букв.
    //    б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    //    в) Найти самое длинное слово сообщения.
    //    г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    //    д) *** Создать метод, который производит частотный анализ текста.
    //      В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
    //      Здесь требуется использовать класс Dictionary.


    public static class Message
    {
        /// <summary>
        /// Оставляет в строке только слова с длиной не больше указанной.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string FilterLength(string message, int n)
        {

            Regex regex = new Regex(@"\b\S{1," + n + @"}\b");
            var matches = regex.Matches(message);

            var result = new StringBuilder();

            foreach (var item in matches)
            {
                result.Append(item + " ");
            }

            return result.ToString();
        }

        /// <summary>
        /// Удаляет из текста слова, заканчивающиеся на указанный символ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string RemoveWords(string message, char a)
        {

            Regex regex = new Regex(@"\b\S{1,}(" + a + @")\b");
            var matches = regex.Matches(message);

            var result = new StringBuilder(message);

            foreach (var item in matches)
            {
                result.Replace(item.ToString(), "");
            }

            return result.ToString();
        }

        /// <summary>
        /// Возвращает самое длинное слово из текста
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetLongestWord(string message)
        {

            Regex regex = new Regex(@"\b\S{1,}\b");
            var matches = regex.Matches(message);
            
            var result = new StringBuilder();

            string longestWord = "";
            foreach (var item in matches)
            {
                if (item.ToString().Length > longestWord.Length)
                {
                    longestWord = item.ToString();
                }
            }

            return longestWord;

        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            //в качестве строки взят отрывок из странноватой маркетинговой статьи на GB
            string message = @"Другой аспект, в котором проявляется нетерпеливость айтишников, — одержимость быстродействием компьютеров." 
                             + " Еще в 1965 году руководитель Intel Гордон Мур описал подмеченную им закономерность — и сделал предсказание: "
                             + "производительность процессоров возрастает в два раза каждые полтора года. " 
                             + "Закон Мура работает и сегодня, спустя полвека. И программистам все еще хочется быстрее, еще быстрее!";

            int wordLength = 5;
            var matches = Message.FilterLength(message, wordLength);
            Console.WriteLine($"Слова с длиной в {wordLength} и менее символов: \n" + matches + "\n");
            Console.ReadKey();

            char lastChar = 'а';
            var cutText = Message.RemoveWords(message, lastChar);

            Console.WriteLine($"Без слов, оканчивающихся на {lastChar}: \n" + cutText + "\n");
            Console.ReadKey();

            var longestWord = Message.GetLongestWord(message);
            Console.WriteLine($"Самое длинное слово: \n" + longestWord + "\n");
            Console.ReadKey();

       

        }
    }
}
