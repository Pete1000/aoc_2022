using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_day1
{
    public class ElfUtils
    {
        private List<Elf> _elves;

        public ElfUtils(List<Elf> elves)
        {
            if (elves is null || elves.Count == 0)
            {
                throw new ArgumentException("No Elves!!!");
            }

            _elves = elves;
        }

        public List<Elf> GetElvesWithMostCalories(int noElves)
        {
            if (noElves > _elves.Count)
            {
                throw new ArgumentException($"Top {noElves} requested, but there are only {_elves.Count} available");
            }

            var topElves = _elves.OrderByDescending(x => x.TotalCalories).Take(noElves).ToList();
            return topElves;
        }
    }
}
