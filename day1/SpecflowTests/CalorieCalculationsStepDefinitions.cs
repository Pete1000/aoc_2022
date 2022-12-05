using aoc_day1;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTests
{
    [Binding]
    public class CalorieCalculationsStepDefinitions
    {
        private ElfUtils? _elfUtils;
        private List<Elf> _elves;
        private Exception _exception;

        [Given(@"a set of Elves with the following food items")]
        public void GivenASetOfElvesWithTheFollowingFoodItems(Table table)
        {
            var elves = new List<Elf>();
            foreach (var row in table.Rows)
            {
                var elf = new Elf(Convert.ToInt32(row[0]));
                elf.Items.AddRange(row[1].Split(',').Select(x => Convert.ToInt32(x.Trim())));
                elves.Add(elf);
            }
            
            try
            {
                _elfUtils = new ElfUtils(elves);
            } catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"I look for the (.*) Elves with the highest total number of calories")]
        public void WhenILookForTheElvesWithTheHighestTotalNumberOfCalories(int noElves)
        {
            try
            {
                _elves = _elfUtils!.GetElvesWithMostCalories(noElves);
            } catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"The Elves with the highest total number of calories will be")]
        public void ThenTheElvesWithTheHighestTotalNumberOfCaloriesWillBeElf(Table table)
        {
            var index = 0;
            foreach (var row in table.Rows)
            {
                _elves[index].Index.Should().Be(Convert.ToInt32(row[0]));
                index++;
            }
        }

        [Then(@"The total number of calories will be")]
        public void ThenTheTotalNumberOfCaloriesWillBe(Table table)
        {
            var index = 0;
            foreach (var row in table.Rows)
            {
                _elves[index].TotalCalories.Should().Be(Convert.ToInt32(row[0]));
                index++;
            }
        }

        [Then(@"an exception is thrown with message '([^']*)'")]
        public void ThenAnExceptionIsThrownWithMessage(string message)
        {
            _exception.Should().NotBeNull();
            _exception.Message.Should().Be(message);
        }
    }
}
