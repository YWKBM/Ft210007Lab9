using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;

namespace Ft210007Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("Logger.txt");


            try //обработка ошибок ввода
            {
                int n;
                Console.WriteLine("Enter the range digit generation: ");
                n = int.Parse(Console.ReadLine());
                sw.WriteLine("Пользователь задал диапазон чисел: " + n);
                Generator g = new Generator(n);

                Console.WriteLine("Enter the quantity of trials: ");

                int k = int.Parse(Console.ReadLine());
                sw.WriteLine("Пользователь ввел количество попыток равное {0}", k);
                int numberToGuess = g.Generate();


                while (k > 0)
                {
                    Console.WriteLine("Try to guess the number: ");
                    int guess = int.Parse(Console.ReadLine());

                    //проверка попадания
                    if (guess > numberToGuess)
                    {
                        Console.WriteLine("Try less number");
                        sw.WriteLine("Пользователь ввел меньшее число");
                    }
                    else if (guess < numberToGuess)
                    {
                        Console.WriteLine("Try bigger number");
                        sw.WriteLine("Пользователь ввел большее число");
                    }
                    else
                    {
                        Console.WriteLine("You guessed!!!");
                        sw.WriteLine("Пользователь угадал число");
                        Console.ReadLine();
                        return;
                    }

                    k--;
                }
                Console.WriteLine("All trials left");
                sw.WriteLine("Пользователь израсходовал все попытки");

                sw.WriteLine("Список сгенерированных чисел: ");
                for (int i = 0; i < g.response.Count; i++)
                {
                    sw.WriteLine(g.response[i]);
                }
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Incorect format, enter digit");
                sw.WriteLine("Пользователь допустил ошибку при вводе числа");
            }
            sw.Close();


        }
    }
}