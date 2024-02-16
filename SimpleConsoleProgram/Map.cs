using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleProgram
{
    public class Map
    {
        private LifeForm lifeForm;
        private int width;
        private int height;
        private int[] movements;
        List<int[]> path;
        private const int HUMAN = 1;
        private const int ALIEN = 2;

        public Map(int width, int height, int lifeForm, List<int> movements) 
        {
            this.width = width;
            this.height = height;
            this.movements = movements.ToArray();
            path = new List<int[]>();
            if (lifeForm == HUMAN)
            {
                this.lifeForm = new Human();
            }
            else if(lifeForm == ALIEN) 
            {
                this.lifeForm = new Alien();
            }
            else
            {
                throw new Exception("Invalid life form integer!");
            }
        }

        public void moveLifeForm()
        {
            int x = 0, y = 0;

            for (int i = 0; i < movements.Length; i += 2)
            {
                x += movements[i];
                y += movements[i + 1];

                // Wrap around if the coordinates exceed the map boundaries
                x = (x + width) % width;
                y = (y + height) % height;

                path.Add(lifeForm.move(x, y));
            }
        }

        public void reportPath()
        {
            Console.WriteLine("Report Path:");
            foreach (var coord in path)
            {
                Console.WriteLine($"[{coord[0]}, {coord[1]}]");
            }

            Console.WriteLine("Report Actual Coordinate");
            Console.WriteLine($"[{path[path.Count - 1][0]}, {path[path.Count - 1][1]}]");
        }

    }
}
