using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Project
{
    public class Statistics
    {
        public int Intelligence { get; set; }
        public int Endurance { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        public Statistics(int intelligence, int endurance, int strength, int agility)
        {
            Intelligence = intelligence;
            Endurance = endurance;
            Strength = strength;
            Agility = agility;
        }

        public Dictionary<string, int> UpgradeStatistics()
        {
            Console.WriteLine();
            Console.WriteLine(
                "===================================================================================================================================");
            Console.WriteLine();
            Console.WriteLine("Now you gain 10 extra points. Use them to improve your character's abilities.");

            int extraPoints = 10;

            Dictionary<string, int> pointsIncrements = new Dictionary<string, int>()
            {
                {nameof(Agility), 0},
                {nameof(Endurance), 0},
                {nameof(Intelligence), 0},
                {nameof(Strength), 0}
            };

            while (extraPoints > 0)
            {
                for (int i = 0; i < pointsIncrements.Keys.Count; i++)
                {
                    string statisticName = pointsIncrements.ElementAt(i).Key;

                    if (extraPoints > 0)
                    {
                        Console.WriteLine($"You have {extraPoints} points to upgrade your abilities.");

                        int pointsAdded = 0;

                        switch (statisticName)
                        {
                            case nameof(Intelligence):
                                pointsAdded = IncreaseIntelligence(extraPoints);
                                break;
                            case nameof(Endurance):
                                pointsAdded = IncreaseEndurance(extraPoints);
                                break;
                            case nameof(Agility):
                                pointsAdded = IncreaseAgility(extraPoints);
                                break;
                            case nameof(Strength):
                                pointsAdded = IncreaseStrength(extraPoints);
                                break;
                            default:
                                break;
                        }

                        pointsIncrements[statisticName] += pointsAdded;
                        extraPoints -= pointsAdded;
                    }
                }
            }

            string mostUpgradedStatistic = pointsIncrements.OrderByDescending(p => p.Value).First().ToString();

            Console.WriteLine(nameof(mostUpgradedStatistic));

            Console.WriteLine();
            Console.WriteLine(
                $"You spent all your extra points. Ability of {mostUpgradedStatistic} was given the most of points. Your character is now much more powerful.");
            Console.WriteLine();
            ConsolePrinter.PrintSeparator();
            Console.WriteLine();

            return pointsIncrements;
        }

        private int IncreaseIntelligence(int points)
        {
            var pointsAdded = UpgradeStatistic(points, nameof(Intelligence).ToLower());

            Intelligence += pointsAdded;

            Console.WriteLine($"Level of your {nameof(Intelligence)}: {Intelligence}");

            return pointsAdded;
        }

        private int IncreaseEndurance(int points)
        {
            var pointsAdded = UpgradeStatistic(points, nameof(Endurance).ToLower());

            Endurance += pointsAdded;

            Console.WriteLine($"Level of your {nameof(Endurance)}: {Endurance}");

            return pointsAdded;
        }

        private int IncreaseStrength(int points)
        {
            var pointsAdded = UpgradeStatistic(points, nameof(Strength).ToLower());

            Strength += pointsAdded;

            Console.WriteLine($"Level of your {nameof(Strength)}: {Strength}");

            return pointsAdded;
        }

        private int IncreaseAgility(int points)
        {
            var pointsAdded = UpgradeStatistic(points, nameof(Agility).ToLower());

            Agility += pointsAdded;

            Console.WriteLine($"Level of your {nameof(Agility)}: {Agility}");

            return pointsAdded;
        }

        private static int UpgradeStatistic(int points, string statisticName)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"How many points would you like to add to your {statisticName} (0 is minimum, {points} is maximum)");

            var number = Program.AskForNumber(10);

            return number > points ? points : number;
        }

    }
}
