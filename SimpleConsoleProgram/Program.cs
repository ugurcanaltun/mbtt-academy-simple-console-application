using SimpleConsoleProgram;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //Variables
        Map map;
        int width, height;
        string[] dimensions;
        int lifeFormInt;
        LifeForm lifeForm;

        // User Input Part START

        Console.Write("Enter map dimensions (w, h): ");
        dimensions = Console.ReadLine().Split(',');
        if (!int.TryParse(dimensions[0], out width) || 
            !int.TryParse(dimensions[1], out height) || 
            height <= 0 || width <= 0)
        {
            Console.WriteLine("Invalid map dimensions.");
            return;
        }

        Console.Write("Enter movement coordinates: ");
        string[] movementsInput = Console.ReadLine().Split(',');
        List<int> movements = new List<int>();
        foreach (string movement in movementsInput)
        {
            if (!int.TryParse(movement, out int move))
            {
                Console.WriteLine("Invalid movement coordinates.");
                return;
            }
            movements.Add(move);
        }

        Console.Write("Select life form (1 for Human, 2 for Alien): ");
        if (!int.TryParse(Console.ReadLine(), out lifeFormInt) || (lifeFormInt != 1 && lifeFormInt != 2))
        {
            Console.WriteLine("Invalid life form selection.");
            return;
        }

        if(lifeFormInt == 1)
        {
            lifeForm = new Human();
        }
        else 
        {
            lifeForm = new Alien();
        }

        // User Input Part END

        map = new Map(width, height, lifeForm, movements);

        map.MoveLifeForm();

        map.ReportPath();
    }

}
