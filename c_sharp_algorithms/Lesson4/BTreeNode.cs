using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    public class BTreeNode
    {
        public int Value { get; set; }
        public BTreeNode Left { get; set; }
        public BTreeNode Right { get; set; }

        public BTreeNode(int value) => Value = value;
    }
}
