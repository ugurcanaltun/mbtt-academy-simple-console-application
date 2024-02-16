using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleProgram
{
    public class Alien : LifeForm
    {
        public override int[] Move(int x, int y)
        {
            return [y, x];
        }
    }
}
