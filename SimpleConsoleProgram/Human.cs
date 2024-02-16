using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleProgram
{
    public class Human : LifeForm
    {
        public int[] move(int x, int y)
        {
            return [x, y];
        }
    }
}
