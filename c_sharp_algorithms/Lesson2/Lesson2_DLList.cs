using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    public class Lesson2_DLList : ILinkedList
    {
        Node FirstNode { get; set; } = null;
        Node LastNode { get; set;} = null;
        
        public Lesson2_DLList()
        {
            this.FirstNode = null;
            this.LastNode = null;
        }        

        private Node CreateNode(int value)
        {
            Node node = new Node();
            node.Value = value;
            node.NextNode = null;
            node.PrevNode = null;
            return node;
        }
        
        public void AddNode(int value)
        {
            Node newNode = CreateNode(value);
            if (FirstNode == null)
            {
                FirstNode = newNode;
                LastNode = newNode;
                return;
            }
            LastNode.NextNode = newNode;
            newNode.PrevNode = LastNode;
            LastNode = newNode;
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = CreateNode(value);
            node.NextNode.PrevNode = newNode;
            if (node.NextNode != null)
                newNode.NextNode = node.NextNode;
            node.NextNode = newNode;
            newNode.PrevNode = node;
        }

        public Node FindNode(int searchValue)
        {
            Node currentNode = FirstNode;
            if (currentNode == null)
                return null;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            int count = 0;
            Node currentNode = FirstNode;
            while (currentNode != null)
            {
                currentNode = currentNode.NextNode;
                count++;
            }
            return count;
        }

        public void RemoveNode(int index)
        {
            int n = 0;
            Node node = FirstNode;
            
            if (node == null)
                return;
            while (n++ < index && node != null)
                node = node.NextNode;
            RemoveNode(node);
        }

        public void RemoveNode(Node node)
        {
            if (node == null)
                return;
            if (node.PrevNode != null)
                node.PrevNode.NextNode = node.NextNode;
            if (node.NextNode != null)
                node.NextNode.PrevNode = node.PrevNode;
        }

        public void PrintList()
        {
            int i = 0;
            int v;
            Node node = FirstNode;
            Console.WriteLine("- - - - - - - ");
            while(node != null)
            {

                if (node.PrevNode != null)
                    v = node.PrevNode.Value;
                else
                    v = 0;
                Console.WriteLine($"{i++}:\t{node.Value}\t prev: {v}");
                node = node.NextNode;
            }
            Console.WriteLine($"---\nВ списке {GetCount()} элементов");
            Console.WriteLine("- - - - - - - ");
        }
    }

    public class L2Task1 : ITask
    {
        public string Name => "Реализация двусвязного списка.";

        public string Description => "Требуется реализовать класс двусвязного" +
            " списка и операции вставки, удаления и поиска элемента" +
            " в нём в соответствии с интерфейсом.";

        public void RunTask()
        {
            Lesson2_DLList list = new Lesson2_DLList();
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
