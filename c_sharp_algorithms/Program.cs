using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int     lessonNumber;
            string  userAnswer;

            List<ILesson> lessons = BuildLessons();
            while (true)
            {
                Console.Clear();
                foreach (ILesson lesson in lessons)
                    Console.WriteLine(lesson.Name);
                Console.WriteLine("\nВведите номер урока или 0 для выхода:");
                userAnswer = Console.ReadLine();
                if (userAnswer == "0")
                    break;
                if (!int.TryParse(userAnswer, out lessonNumber))
                    continue;                
                foreach (ILesson lesson in lessons)
                {
                    if (lesson.Id == lessonNumber)
                    {
                        Console.Clear();
                        lesson.RunLesson();
                        Console.Clear();
                    }
                }
                
            }
        }

        static List<ILesson> BuildLessons()
        {
            List<ILesson> lessons = new List<ILesson>();
            lessons.Add(BuildLesson1());
            lessons.Add(BuildLesson2());
            return (lessons);
        }

        static ILesson BuildLesson1()
        {
            Lesson lesson1 = new Lesson("Урок 1. Блок-схемы," +
                " асимптотическая сложность, рекурсия", 1);
            L1Task1 task1 = new L1Task1();
            L1Task2 task2 = new L1Task2();
            L1Task3 task3 = new L1Task3();
            lesson1.TaskList.Add(task1);
            lesson1.TaskList.Add(task2);
            lesson1.TaskList.Add(task3);
            return (lesson1);
        }

        static ILesson BuildLesson2()
        {
            Lesson lesson2 = new Lesson("Урок 2. Массив, список, поиск", 2);
            L2Task1 task1 = new L2Task1();
            lesson2.TaskList.Add(task1);
            return (lesson2);
        }
    }
}