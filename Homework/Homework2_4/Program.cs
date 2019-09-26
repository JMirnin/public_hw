using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    class Program
    {
        //Анатолий Толстых
        //
        //4.
        //Реализовать метод проверки логина и пароля.
        //На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
        //Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
        //С помощью цикла do while ограничить ввод пароля тремя попытками.

        static void Main(string[] args)
        {

            byte maxtryCount = 3; 
            bool autorized = false;
            for (byte i = 1; i <= maxtryCount; i++)
            {
                Console.Write("Логин: ");
                string login = Console.ReadLine();
                Console.Write("Пароль: ");
                string pass = Console.ReadLine();

                autorized = CheckLogin(login, pass);
                if (!autorized) {
                    Console.WriteLine($"Введены неверные данные.");
                    if (i < maxtryCount) {
                        Console.WriteLine($"Осталось попыток: {maxtryCount - i} \n");
                    }
                }
                else
                {
                    break;
                }
            }

            if (!autorized) 
            {
                Console.WriteLine("Доступ запрещен.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Успешно авторизован.");
            Console.ReadKey();

            //далее 
            //много всякого кода
            //доступного только для авторизованных

        }

        static bool CheckLogin(string login, string pass)
        {

            return (login == "root" && pass == "GeekBrains");
            
        }
    }
}
