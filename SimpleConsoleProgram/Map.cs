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
        private LifeForm _lifeForm;
        private int _width;
        private int _height;
        private int[] _movements;
        private List<int[]> _path;

        public Map(int width, int height, LifeForm lifeForm, List<int> movements) 
        {
            _width = width;
            _height = height;
            _movements = movements.ToArray();
            _path = new List<int[]>();
            _lifeForm = lifeForm;
        }

        public void MoveLifeForm()
        {
            int x = 0, y = 0;

            for (int i = 0; i < _movements.Length; i += 2)
            {
                x += _movements[i];
                y += _movements[i + 1];

                // Wrap around if the coordinates exceed the map boundaries
                x = (x + _width) % _width;
                y = (y + _height) % _height;

                _path.Add(_lifeForm.Move(x, y));
            }
        }

        public void ReportPath()
        {
            Console.WriteLine("Report Path:");
            foreach (var coord in _path)
            {
                Console.WriteLine($"[{coord[0]}, {coord[1]}]");
            }

            Console.WriteLine("Report Actual Coordinate");
            Console.WriteLine($"[{_path[_path.Count - 1][0]}, {_path[_path.Count - 1][1]}]");
        }

    }
}
