using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    internal class L5Task1: ITask
    {
        public BTree Tree { get; }
        public string Name => "Реализовать обход дерева BFS и DFS";

        public string Description => "Обход дерева в ширину";

        public void RunTask()
        {
            Tree.Root = null;
            AddSomeIntToTree(25);
            Tree.PrintTree();
            Console.WriteLine();
            Console.WriteLine("Обход в ширину:\t");
            BFSTree();
            Console.WriteLine("Обход в глубину:\t");
            DFSTree(Tree.Root);
            Console.WriteLine("");
        }

        public L5Task1()
        {
            Tree = new BTree(null);
        }

        public void AddSomeIntToTree(int count = 10)
        {
            int randomInt;
            int loopExit = 0;
            Random rand = new Random();

            while (count > 0)
            {
                randomInt = rand.Next(0, 99);
                if (Tree.Search(randomInt, Tree.Root) == null)
                {
                    Tree.AddNode(randomInt);
                    count--;
                }
                loopExit++;
                if (loopExit > 100)
                    break;
            }
        }

        public void BFSTree()
        {
            Queue<BTreeNode> bfsQueue = new Queue<BTreeNode>();
            BTreeNode currentNode;
            
            bfsQueue.Enqueue(Tree.Root);
            while (bfsQueue.Count > 0)
            {
                currentNode =  bfsQueue.Dequeue();
                if (currentNode.Left != null)
                    bfsQueue.Enqueue(currentNode.Left);
                if (currentNode.Right != null)
                    bfsQueue.Enqueue(currentNode.Right);
                Console.Write(currentNode.Value + " ");
            }
            Console.WriteLine();
        }

        public void DFSTree(BTreeNode currentNode)
        {
            if (currentNode == null)
                return;
            Console.Write(currentNode.Value + " ");
            DFSTree(currentNode?.Left);
            DFSTree(currentNode?.Right);
        }
    }

}
