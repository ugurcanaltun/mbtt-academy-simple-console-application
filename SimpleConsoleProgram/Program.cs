using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter map dimensions (w, h): ");
        string[] dimensions = Console.ReadLine().Split(',');
        int w, h;
        if (!int.TryParse(dimensions[0], out w) || !int.TryParse(dimensions[1], out h) || h <= 0 || w <= 0)
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
        if (!int.TryParse(Console.ReadLine(), out int lifeForm) || (lifeForm != 1 && lifeForm != 2))
        {
            Console.WriteLine("Invalid life form selection.");
            return;
        }

        var result = MoveLifeForm(w, h, movements.ToArray(), lifeForm);

        Console.WriteLine("Report Path:");
        foreach (var coord in result)
        {
            Console.WriteLine($"[{coord[0]}, {coord[1]}]");
        }

        Console.WriteLine("Report Actual Coordinate");
        Console.WriteLine($"[{result[result.Count - 1][0]}, {result[result.Count - 1][1]}]");
    }

    static List<int[]> MoveLifeForm(int w, int h, int[] movements, int lifeForm)
    {
        int x = 0, y = 0;
        List<int[]> path = new List<int[]>();

        for (int i = 0; i < movements.Length; i += 2)
        {
            x += movements[i];
            y += movements[i + 1];

            // Wrap around if the coordinates exceed the map boundaries
            x = (x + w) % w;
            y = (y + h) % h;

            if (lifeForm == 1)
            {
                path.Add(new int[] { x, y });
            }
            else if (lifeForm == 2)
            {
                path.Add(new int[] { y, x });
            }
        }

        return path;
    }
}

public class Human : LifeForm { }

public class LifeForm
{ }
