using System;
using System.Collections.Generic;

public interface LifeForm
{
    string Name { get; }
}

public class Human : LifeForm
{
    public string Name { get; }
    
    public Human()
    {
        Name = "Human";
    }
}

public class Alien : LifeForm
{
    public string Name { get; }

    public Alien() 
    {
    Name = "Alien";
    }
}

class Program
{
    static void Main()
    {
        //Variables
        int w, h;
        string[] dimensions;
        int lifeFormInt;
        LifeForm lifeForm = null;

        Console.Write("Enter map dimensions (w, h): ");
        dimensions = Console.ReadLine().Split(',');
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
        if (!int.TryParse(Console.ReadLine(), out lifeFormInt) || (lifeFormInt != 1 && lifeFormInt != 2))
        {
            Console.WriteLine("Invalid life form selection.");
            return;
        }

        if(lifeFormInt == 1)
        {
            lifeForm = new Human();
        }
        else if(lifeFormInt == 2) 
        {
            lifeForm = new Alien();
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

    static List<int[]> MoveLifeForm(int w, int h, int[] movements, LifeForm lifeForm)
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

            if (lifeForm.Name == "Human")
            {
                path.Add(new int[] { x, y });
            }
            else if (lifeForm.Name == "Alien")
            {
                path.Add(new int[] { y, x });
            }
        }

        return path;
    }
}
