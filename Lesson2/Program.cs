using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            Console.WriteLine("Создадим список и добавим в него 5 элеменов...");
            list.AddNode(10);
            list.AddNode(20);
            list.AddNode(30);
            list.AddNode(40);
            list.AddNode(50);
            list.PrintList();
            
            Console.WriteLine("Найдем элемент со значением 30 и добавим после него " +
                "элемент со значением 35");
            list.AddNodeAfter(list.FindNode(30), 35);
            list.PrintList();
            
            Console.WriteLine("Удалим элемент с индексом № 4");
            list.RemoveNode(4);
            list.PrintList();

            Console.WriteLine("Надйем элемент со значенем 50 и удалим его");
            list.RemoveNode(list.FindNode(50));
            list.PrintList();

            Console.WriteLine("Попробуем удалить элемент с индексом 9");
            list.RemoveNode(9);
            list.PrintList();
        }
    }
}
