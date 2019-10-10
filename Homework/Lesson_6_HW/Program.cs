using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_6_HW
{

    //Анатолий Толстых

    //Задание 1.
    //Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
    //Продемонстрировать работу на функции с функцией a* x^2 и функцией a* sin(x).


    //    Задание 2.
    //    Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    //      а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.
    //          Использовать массив(или список) делегатов, в котором хранятся различные функции.
    //      б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.
    //          Пусть она возвращает минимум через параметр(с использованием модификатора out). 

    public delegate double Fun(double x, double y);

    /// <summary>
    /// Класс для хранения функции и её текстового представления
    /// Используется в списке функций
    /// </summary>
    public class Function
    {
        public string functionString;
        public Fun func;

        public Function(string fstring, Fun function)
        {
            functionString = fstring;
            func = function;
        }
    }

    class Program
    {
        public static double F(double x, double y)
        {
            return y * x * x;
        }

        public static double FSin(double x, double y)
        {
            return y * Math.Sin(x);
        }

        public static double FMult(double x, double y)
        {
            return x * x * y * y;
        }

        public static double FSqrt(double x, double y)
        {
            return x * Math.Sqrt(y);
        }

        public static void SaveFunc(string fileName, Fun fun, double a, double b, double a1, double b1, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                double y = a1; //перезадаем начальное значение Y для  каждого X
                while (y <= b1)
                {
                    bw.Write(fun(x, y));
                    y += h;
                }
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double min)
        {
            
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);

            //массив тут выглядит не очень хорошо из-за постоянного resize
            //но по постановке задачи должен быть именно массив, хоть и напрашивается список
            double[] valuesArray = new double[0];
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                Array.Resize(ref valuesArray, valuesArray.Length + 1);
                valuesArray[valuesArray.Length - 1] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return valuesArray;
        }

        static void Main(string[] args)
        {

            //формируем список функций
            List<Function> funcs = new List<Function>();
            funcs.Add(new Function("x * x * y", new Fun(F)));
            funcs.Add(new Function("y * sin(x)", new Fun(FSin)));
            funcs.Add(new Function("x * x * y * y", new Fun(FMult)));
            funcs.Add(new Function("x * sqrt(y)", new Fun(FSqrt)));


            for (int i = 0; i < funcs.Count; i++)
            {
                Console.WriteLine($"Нажмите {i + 1} чтобы выбрать функцию {funcs[i].functionString}");
            }

            if (Int32.TryParse(Console.ReadLine(), out int userFunc) && userFunc > 0 && userFunc < funcs.Count)
            {

                //захотелось использовать словарь, чтобы не дублировать команды, а делегат тут кажется излишним
                Dictionary<string, double> dic = new Dictionary<string, double>();
                dic.Add("Нижняя граница X", Double.NaN);
                dic.Add("Верхняя граница Х", Double.NaN);
                dic.Add("Нижняя граница Y", Double.NaN);
                dic.Add("Верхняя граница Y", Double.NaN);

                //словарь нельзя изменить, перебирая values в цикле, поэтому выгрузим ключи в массив
                string[] keysArray = dic.Keys.ToArray();

                foreach (var key in keysArray)
                {
                    while (Double.IsNaN(dic[key]))
                    {
                        Console.Write($"{key}: ");
                        try
                        {
                            var userValue = Double.Parse(Console.ReadLine());
                            dic[key] = userValue;
                        }
                        catch
                        {
                            Console.WriteLine("Введены некорректные данные.");
                        }
                    }
                }

                SaveFunc("data.bin", funcs[userFunc - 1].func, dic["Нижняя граница X"], dic["Верхняя граница Х"], dic["Нижняя граница Y"], dic["Верхняя граница Y"], 0.5);

                double[] valuesArray = Load("data.bin", out double min);
                Console.WriteLine("Минимум для " + funcs[userFunc - 1].functionString + ": " + min );

            }
             Console.ReadKey();
        

        }
    }

}
