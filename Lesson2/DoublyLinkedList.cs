using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class DoublyLinkedList : ILinkedList
    {
        Node FirstNode { get; set; } = null;
        Node LastNode { get; set;} = null;
        
        public DoublyLinkedList()
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
}
