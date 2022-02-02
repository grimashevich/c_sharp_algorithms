using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    internal class Lesson1
    {
        public static void Task1()
        {
            int number, d, i;
            string userAnswer;

            Console.WriteLine("Требуется реализовать на C# функцию согласно блок-схеме." +
                "Блок-схема описывает алгоритм проверки, простое число или нет.\n");
            while (true)
            {
                Console.WriteLine("Введите целове число или exit для выхода: \n");
                userAnswer = Console.ReadLine();
                if (int.TryParse(userAnswer, out number))
                    break;
                if (userAnswer.Trim(' ') == "exit")
                    return;
            }
            d = 0;
            i = 2;
            while (i< number)
            {
                if (number % i == 0)
                    d++;
                i++;
            }
            if (d == 0)
                Console.WriteLine($"Число {number} является простым");
            else
                Console.WriteLine($"Число {number} не является простым");
        }
        
        public static void Task2()
        {
            Console.WriteLine("Посчитайте сложность функции");
            Console.WriteLine("Ответ: Сложность алгоритма O(N^3)");
        }

        public static void Task3(int number)
        {
            FiboRecursion(number);
            Console.WriteLine();
        }

        public static long[] FiboRecursion(int n)
        {
            long[] result = new long[2];

            if (n == 2)
            {
                Console.Write("0 1");
                result[0] = 0;
                result[1] = 1;
                return (result);
            }
            result = FiboRecursion(n - 1);
            result[1] += result[0];
            result[0] = result[1] - result[0];
            Console.Write($" {result[1]}");
            return (result);
        }
/*
        public static void FiboLoop(int n)
        {

        }
*/
    }
}
