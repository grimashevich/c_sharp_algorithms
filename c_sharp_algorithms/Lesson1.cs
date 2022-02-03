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
                Console.WriteLine("Введите целове число или exit для выхода:");
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

        public static void Task3()
        {
            int number;

            while (true)
            {
                Console.WriteLine("Введите число > 0 для вывода ряда фибоначчи:");
                if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                    break;
            }

            if (number == 1)
            {
                Console.WriteLine("Рекурсия: \t0\nЦикл:\t\t0");
                return;
            }
            Console.Write("Рекурсия: \t");
            FiboRecursion(number);
            Console.WriteLine();
            Console.Write("Цикл:\t\t");
            FiboLoop(number);
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

        public static void FiboLoop(int n)
        {
            int[] fibo = new int[2] {0, 1};

            Console.Write("0 1");
            for (int i = 3; i <= n; i++)
            {
                fibo[1] += fibo[0];
                fibo[0] = fibo[1] - fibo[0];
                Console.Write($" {fibo[1]}");
            }
        }
        
        public static void RunLesson1()
        {
            while (true)
            {
                Console.WriteLine("Введите номер задачи (1-3) или 0 для выхода:");
                if (!int.TryParse(Console.ReadLine(), out int taskNum) || taskNum < 0 || taskNum > 3)
                    continue;
                if (taskNum == 0)
                    break;
                if (taskNum == 1)
                    Task1();
                else if (taskNum == 2)
                    Task2();
                else if (taskNum == 3)
                    Task3();
                Console.WriteLine();
            }
        }

    }
}
