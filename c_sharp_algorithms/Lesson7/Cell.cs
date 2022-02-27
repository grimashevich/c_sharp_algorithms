using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    internal class Cell
    {
        public int x { get; }
        public int y { get; }

        public Cell(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public override string ToString()
        {
            return $"x: {x} y: {y}";
        }
    }
}
