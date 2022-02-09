using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_algorithms
{
    public interface ILesson
    {
        int Id { get; }
        string Name { get; }

        void RunLesson();
    }
}
