using aoc_day1;

var elves = Elf.LoadElvesFromFile();

var elfUtils = new ElfUtils(elves);

var topElves = elfUtils.GetElvesWithMostCalories(3);
Console.WriteLine($"Elf {topElves[0].Index} has most calories - {topElves[0].TotalCalories}");

Console.WriteLine($"Top 3 Elves total calories - {topElves.Sum(x => x.TotalCalories)}");
