using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_4
{
    //      Анатолий Толстых

    //      Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
    //      Создайте структуру Account, содержащую Login и Password.

    /// <summary>
    /// Структура, хранящая в себе данные авторизации пользователя
    /// </summary>
    struct Account
    {
        public string Login;
        public string Password;
        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Account account = new Account();
            
            byte maxtryCount = 3;
            bool autorized = false;
            for (byte i = 1; i <= maxtryCount; i++)
            {
                Console.Write("Логин: ");
                account.Login = Console.ReadLine();
                Console.Write("Пароль: ");
                account.Password = Console.ReadLine();

                autorized = CheckLogin(account);
                if (!autorized)
                {
                    Console.WriteLine($"Введены неверные данные.");
                    if (i < maxtryCount)
                    {
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

        /// <summary>
        /// Ищет данные в файле accounts.txt
        /// Структура файла: пары "login:password", по одной на строку
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        static bool CheckLogin(Account account)
        {
            

            string[] accounts = File.ReadAllLines("accounts.txt"); //помещаем все строки в массив

            return accounts.Contains($"{account.Login}:{account.Password}"); //возвращаем успех, если учетные данные присутствуют в массиве


        }
    }
    
}
