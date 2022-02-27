using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    internal class EightQueens
    {
        public int DeskSize { get; }

        private int[,] Desk;
        private int QueensOnTheDesk;
        public List<Cell> Queens = new List<Cell>();
        public List<Cell> AllCells;

        public EightQueens(int deskSize)
        {
            DeskSize = deskSize;
            Desk = new int[deskSize, deskSize];
            AllCells = GetFullRows();
        }
        public bool PutQueen(int x, int y, int[,] desk)
        {
            if (desk[x, y] != 0)
                return false;
            desk[x, y] = 1;
            QueensOnTheDesk++;
            return true;
        }

        private bool IsPointInDiagonal(int x, int y, int queenX, int queenY)
        {
            return (x - queenX == y - queenY || x - queenX == (y - queenY) * -1);
        }

        List<Cell> GetFullRows()
        {
            List<Cell> result = new List<Cell>();
            for (int i = 0; i < DeskSize; i++)
            {
                for (int j = 0; j < DeskSize; j++)
                    result.Add(new Cell(i, j));
            }
            return result;
        }

        List<Cell> GetFreeRows(int queenX, int queenY, List<Cell> freeCells = null)
        {
            List<Cell> result = new List<Cell> ();
            foreach (Cell cell in freeCells)
            {
                if (cell.x == queenX || cell.y == queenY ||
                    IsPointInDiagonal(cell.x, cell.y, queenX, queenY))
                        continue;
                result.Add(cell);
            }
            return result;
        }

        public bool PutSomeQueens(int count, List<Cell> freeRows)
        {
            int skipCells = 0;
            if (freeRows.Count == DeskSize * DeskSize)
            {
                var rand = new Random();
                skipCells = rand.Next(freeRows.Count - 1);
            }
            if (count == 0)
                return true;
            foreach (Cell cell in freeRows)
            {
                if (skipCells-- > 0)
                    continue;
                if (PutSomeQueens(count - 1, GetFreeRows(cell.x, cell.y, freeRows)))
                {
                    Queens.Add(cell);
                    return true;
                }
            }
            return false;
        }

        private void PrintCell(int x, int y)
        {
           if (Desk[x, y] == 0)
            {
                if ((x + y) % 2 == 0)
                    Console.Write("░░");
                else
                    Console.Write("  ");
            }
            else
                Console.Write("▓▓");    
        }

        public void PrintDesk()
        {
            int leftBorder = DeskSize.ToString().Length + 3;
            for (int i = 0; i < DeskSize; i++)
            {
                for (int j = 0; j < DeskSize; j++)
                {
                    Console.SetCursorPosition(i * 2 + leftBorder, j + 1);
                    PrintCell(j, i);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, DeskSize + 4);
        }

        public bool TryArrangeQueens(int count)
        {
            Console.Clear();
            if (PutSomeQueens(count, AllCells))
            {
                foreach (Cell cell in Queens)
                    PutQueen(cell.x, cell.y, Desk);
                PrintBorder();
                PrintDesk();
                return true;
            }
            return false;
        }

        private void PrintBorder()
        {
            int leftBorder = DeskSize.ToString().Length + 2;
            char letter = 'A';
            for (int i = 0; i < DeskSize; i++)
            {
                Console.SetCursorPosition(1 + leftBorder + i * 2, 0);
                Console.Write("══");
                Console.SetCursorPosition(1 + leftBorder + i * 2, DeskSize + 1);
                Console.Write("══");
                Console.SetCursorPosition(leftBorder, i + 1);
                Console.Write('║');
                Console.SetCursorPosition(leftBorder + DeskSize * 2 + 1, i + 1);
                Console.Write('║');
                Console.SetCursorPosition(1, i + 1);
                Console.Write(DeskSize - i);
                Console.SetCursorPosition(1 + leftBorder + i * 2, DeskSize + 2);
                Console.Write(letter++);
            }
            Console.SetCursorPosition(leftBorder, 0);
            Console.Write('╔');
            Console.SetCursorPosition(leftBorder + DeskSize * 2 + 1, 0);
            Console.Write('╗');
            Console.SetCursorPosition(leftBorder, DeskSize + 1);
            Console.Write('╚');
            Console.SetCursorPosition(leftBorder + DeskSize * 2 + 1, DeskSize + 1);
            Console.Write('╝');
        }

    }
}
