using System.Diagnostics;
using System.Reflection;

namespace aoc_day1;

public class Elf
{
    public int Index { get; set; }
    public List<int> Items { get; set; }
    public int TotalCalories
    {
        get
        {
            return Items.Sum();
        }
    }

    public Elf(int index)
    {
        this.Index = index;
        this.Items = new List<int>();
    }

    public static List<Elf> LoadElvesFromFile()
    {
        var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var elves = new List<Elf>();
        Elf? currentElf = null;
        var index = 1;

        using (var reader = new StreamReader($"{currentDir}/input.txt"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (currentElf == null || string.IsNullOrWhiteSpace(line))
                {
                    currentElf = new Elf(index);
                    elves.Add(currentElf);
                    index++;
                }

                if (!string.IsNullOrWhiteSpace(line))
                {
                    var noCalories = Convert.ToInt32(line);
                    currentElf.Items.Add(noCalories);
                }
            }
        }

        return elves;
    }
}
