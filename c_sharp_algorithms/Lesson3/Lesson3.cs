using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    struct PointStructDouble: IPointDouble
    {
        public double X1 { get; }
        public double Y1 { get; }
        public double X2 { get; }
        public double Y2 { get; }

        public PointStructDouble(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

    }
    internal class PointClassDouble : IPointDouble
    {

        public PointClassDouble(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public double X1 { get; }
        public double Y1 { get; }
        public double X2 { get; }
        public double Y2 { get; }
    }

    internal class L3Task1: ITask
    {
        public string Name => "Сравнение производительности обработки массивов разных типов данных";

        public string Description => "Создать массивы объектов класса и объектов структуры. Заполнить их " +
            "случайными числами. Сравнить производтельность их обработки, используя формулу вычисления " +
            "расстояния между двумя точками.";

        static double GetDistance(IPointDouble item)
        {
            double leg1 = item.X2 - item.X1;
            double leg2 = item.Y2 - item.Y1;

            return Math.Sqrt((leg1 * leg1) + (leg2 * leg2));
        }

        static void GetRandomCoordinates(Random random, out double x1, out double y1, out double x2, out double y2)
        {
            x1 = random.NextDouble() * random.Next();
            x2 = random.NextDouble() * random.Next();
            y1 = random.NextDouble() * random.Next();
            y2 = random.NextDouble() * random.Next();
        }

        public static void GetPointArray(int size, out PointClassDouble[] PointClassArray, out PointStructDouble[] pointStructArray)
        {
            PointClassArray = new PointClassDouble[size];
            pointStructArray = new PointStructDouble[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                GetRandomCoordinates(random, out double x1, out double y1, out double x2, out double y2);
                PointClassArray[i] = new PointClassDouble(x1, y1, x2, y2);
                pointStructArray[i] = new PointStructDouble(x1, y1, x2, y2);
            }
        }

        public void RunTask()
        {
            double distance;
            long elapsedTime;

            Stopwatch sw = new Stopwatch();
            PointClassDouble[] pointClassArray;
            PointStructDouble[] pointStructArray;

            Console.WriteLine("|Кол-во записей\t|t Class (мс.)\t|t Struct (мс.)\t| Ratio\t|");
            for (int size = 100000; size <= 500000; size += 50000)
            {
                GetPointArray(size, out pointClassArray, out pointStructArray);
                sw.Restart();
                for (int i = 0; i < size; i++)
                    distance = GetDistance(pointClassArray[i]);
                sw.Stop();
                elapsedTime = sw.ElapsedMilliseconds;

                sw.Restart();
                for (int i = 0; i < size; i++)
                    distance = GetDistance(pointStructArray[i]);
                sw.Stop();
                Console.WriteLine($"|{size}\t\t|{elapsedTime} \t\t|{sw.ElapsedMilliseconds}\t\t| " +
                    $"{Math.Round((double)elapsedTime / sw.ElapsedMilliseconds, 3)}\t|");
            }
            Console.WriteLine();
        }
    }
}
