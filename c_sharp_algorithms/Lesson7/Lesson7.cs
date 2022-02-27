using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    internal class L7Task1 : ITask
    {
        public string Name => "Задача о 8 ферзях";

        public string Description => "Расставить N ферзей на поле, размером NxN так, что бы " +
            "ни один из них не находился под боем другого";

        public void RunTask()
        {
            string useranswer;
            int n;
            bool result;
            EightQueens queens;

            while (true)
            {
                Console.WriteLine("Введите N >= 0 (размер шахматной доски и кол-во ферзей для расстановки) или 0 для выхода");
                useranswer = Console.ReadLine();
                if (!int.TryParse(useranswer, out n) || n < 0)
                    continue;
                if (n == 0)
                    return;
                break;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            queens = new EightQueens(n);
            result = queens.TryArrangeQueens(n);
            if (result)
                Console.WriteLine("Фигуры размещены успешно");
            else
                Console.WriteLine("Решение не найдено");
            sw.Stop();
            if (sw.ElapsedMilliseconds > 1000)
                Console.WriteLine($"Затрачено {sw.ElapsedMilliseconds / 1000.0} с.");
            else
                Console.WriteLine($"Затрачено {sw.ElapsedMilliseconds} мс.");
        }
    }
}
