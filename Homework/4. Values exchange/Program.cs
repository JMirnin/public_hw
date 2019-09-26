using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Values_exchange
{
    class Program
    {

        //Анатолий Толстых.

        //Написать программу обмена значениями двух переменных:
        //б) *без использования третьей переменной.  (с третьей переменной решение есть в методичке)


        static void Main(string[] args)
        {

            int a = 10;     
            int b = 20;     
            a = a + b; //присваиваем переменой А значение суммы переменных
            b = a - b; //сумма минус B = старое значение А
            a = a - b; //сумма минус старое значение А = старое значение В

        }
    }
}
