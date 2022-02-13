using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    public class BTree
    {
        public BTreeNode Root { get; set; }
        private int MaxWidth { get; set; }

        public BTree(BTreeNode root) => Root = root;
        public void AddNode(int value)
        {
            BTreeNode node = new BTreeNode(value);
            BTreeNode currentNode;
            
            if (Root == null)
            {
                Root = node;
                this.UpdateMaxWidth();
                return ;
            }
            currentNode = Root;
            while (true)
            {
                if (node.Value < currentNode.Value)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue ;
                    }
                    currentNode.Left = node;
                    break;
                }
                else if (node.Value > currentNode.Value)
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        continue ;
                    }
                    currentNode.Right = node;
                    break;
                }
                else break ;
            }
        }


        public int GetMax()
        {
            BTreeNode node = this.Root;
            if (node == null)
                return 0;
            while (node.Right != null)
                node = node.Right;
            return (node.Value);
        }
        public int GetMin()
        {
            BTreeNode node = this.Root;
            if (node == null)
                return 0;
            while (node.Left != null)
                node = node.Left;
            return (node.Value);
        }

        private void UpdateMaxWidth()
        {
            int max = this.GetMax();
            int min = this.GetMin();
            int tmp;

            this.MaxWidth = 0;
            while (max > 0)
            {
                max /= 10;
                this.MaxWidth++;
            }
            if (min > 0 || Math.Abs(min) < max / 10)
                return;
            min = Math.Abs(min);
            tmp = 1;
            while (min > 0)
            {
                min /= 10;
                tmp++;
            }
            if (tmp > this.MaxWidth)
                this.MaxWidth = tmp;
        }

        private void PrintNode(BTreeNode node, int offsetX, int offsetY)
        {
            Console.SetCursorPosition(offsetX, offsetY);
            Console.Write(node.Value);
        }

        private void PrintSubTree(BTreeNode node, int treeHeight, int level,
            int prevOffset, int side, BTreeNode prevNode = null)
        {
            int subTreeCount;
            int offsetX;

            if (node == null)
                return;
            this.UpdateMaxWidth();
            if (side == -1)
                subTreeCount = GetCount(node.Right);
            else
                subTreeCount = GetCount(node.Left);
            offsetX = prevOffset + (subTreeCount + 1) * this.MaxWidth * side;
            if (offsetX + this.MaxWidth > Console.WindowWidth)
            {
                Console.SetCursorPosition(0, treeHeight + level + 5);
                Console.WriteLine("Милорд, ширины консоли не хватает для вывода дерева," +
                    "нужно что-то с этим делать!");
                return;
            }
            if (prevNode != null)
                PrintRelation(level++, offsetX, prevOffset, prevNode);
            PrintNode(node, offsetX, level);
            PrintSubTree(node.Left, treeHeight - 1, level + 1, offsetX, -1, node);
            PrintSubTree(node.Right, treeHeight - 1, level + 1, offsetX, 1, node);
        }

        
        private void PrintRelation(int line, int offset, int prevOffset,
            BTreeNode prevNode)
        {
            char startChar, finalChar, lineChar;
            int start, end;
            lineChar = '═';
            if (offset > prevOffset)
            {
                if (prevNode.Left != null)
                    startChar = '╩';
                else
                    startChar = '╚';
                finalChar = '╗';
                Console.SetCursorPosition(prevOffset, line);
                start = prevOffset + 1;
                end = offset - 1;
            }
            else
            {
                startChar= '╔';
                finalChar = '╝';
                Console.SetCursorPosition(offset, line);
                start = offset + 1;
                end = prevOffset - 1;
            }
            Console.Write(startChar);
            for (int i = start; i <= end; i++)
                Console.Write(lineChar);
            Console.Write(finalChar);
        }

        public void PrintTree()
        {
            int treeHeight;
            Console.Clear();
            if (this.Root == null)
                return;
            treeHeight = this.GetTreeHeight(this.Root);
            PrintSubTree(this.Root, treeHeight, 0, 0, 1);
            Console.SetCursorPosition(0, treeHeight * 2 - 1);
        }

        public int GetTreeHeight(BTreeNode currentNode, int currentDepth = 0)
        {
            int resultLeft;
            int resultRight;

            if (currentNode == null)
                return currentDepth;
            currentDepth++;
            resultLeft = GetTreeHeight(currentNode.Left, currentDepth);
            resultRight = GetTreeHeight(currentNode.Right, currentDepth);
            
            return resultLeft > resultRight ? resultLeft : resultRight;
        }

        public int GetCount(BTreeNode node)
        {
            if (node != null)
                return 1 + GetCount(node.Left) + GetCount(node.Right);
            return 0;
        }

        public BTreeNode Search(int value, BTreeNode node)
        {
            if (node == null)
                return null;
            if (value < node.Value)
            {
                if (node.Left == null)
                    return null;
                return (Search(value, node.Left));
            }
            else if (value > node.Value)
            {
                if (node.Right == null)
                    return null;
                return Search(value, node.Right);
            }
            else
                return node;
        }

        public BTreeNode SearhParent(int value, BTreeNode node)
        {
            if (node == null || node.Value == value)
                return null;
            if (node?.Left?.Value == value || node?.Right?.Value == value)
                return node;
            if (value < node.Value)
            {
                if (node.Left == null)
                    return null;
                return SearhParent(value, node.Left);
            }
            else
            {
                if (node.Right == null)
                    return null;
                return SearhParent(value, node.Right);
            }
        }

        private void UpdateParent(BTreeNode oldNode, BTreeNode parent,
            BTreeNode newNode)
        {
            if (parent.Left == oldNode)
                parent.Left = newNode;
            else
                parent.Right = newNode;
        }

        public void DeleteNode(int value)
        {
            BTreeNode node = this.Search(value, this.Root);
            BTreeNode parentNode = this.SearhParent(value, this.Root);

            if (node == null)
                return;
            if (node.Right == null && node.Left == null)
            {
                if (this.Root == node)
                {
                    this.Root = null;
                    return;
                }
                UpdateParent(node, parentNode, null);
            }
            else if (node.Right == null)
            {
                if (node == this.Root)
                {
                    this.Root = node.Left;
                    return;
                }
                UpdateParent(node, parentNode, node.Left);
            }
            else if (node.Left == null)
            {
                if (node == this.Root)
                {
                    this.Root = node.Right;
                    return;
                }
                UpdateParent(node, parentNode, node.Right);
            }
            else
            {
                int tmp;
                BTreeNode minRight;
                minRight = node.Right;
                while (minRight.Left != null)
                    minRight = minRight.Left;
                tmp = minRight.Value;
                DeleteNode(tmp);
                node.Value = tmp;
            }
        }
    }
}
