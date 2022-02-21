using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    public class Lesson: ILesson
    {
        public List<ITask> TaskList { get; set; }

        public int Id { get; }

        public string Name { get; }

        public Lesson(string name, int id, params ITask[] tasks)
        {
            Name = name;
            Id = id;
            TaskList = new List<ITask>();
            foreach (ITask task in tasks)
                this.TaskList.Add(task);
        }
        void ILesson.RunLesson()
        {
            RunLesson();
        }

        void ShowLessonMenu()
        {
            int i = 1;
            Console.WriteLine(Name);
            foreach (ITask task in TaskList)
            {
                Console.WriteLine($"\t{i++}.{task.Name}" );
            }
        }

        void RunLesson()
        {
            int lessonNumber;

            while (true)
            {
                Console.Clear();
                ShowLessonMenu();
                Console.WriteLine("\nВведите номер задачи или 0 для выхода:");
                if (int.TryParse(Console.ReadLine(), out lessonNumber) == false ||
                    lessonNumber < 0 || lessonNumber > TaskList.Count)
                    continue;
                if (lessonNumber <= 0)
                    break;
                else
                {
                    Console.Clear();
                    Console.WriteLine(TaskList[lessonNumber - 1].Name);
                    Console.WriteLine(TaskList[lessonNumber - 1].Description + "\n");
                    TaskList[lessonNumber - 1].RunTask();
                    Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
                    
        }
    }
}
