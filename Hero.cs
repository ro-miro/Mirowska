using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _2_Project
{
    public abstract class Hero
    {
        public string Name { get; protected set; }

        public ClassType ClassType { get; set; }

        public List<string> Inventory { get; set; }

        public Statistics Statistics { get; protected set; }

        protected Hero(string name, int intelligence, int endurance, int strength, int agility)
        {
            Name = name;
            Statistics = new Statistics(intelligence, endurance, strength, agility);
            Inventory = new List<string>();
        }

        public override string ToString()
        {
            return String.Format("{0}", Name);
        }

        public virtual void ShowStatistics()
        {
            Console.WriteLine();
            ConsolePrinter.PrintSeparator();
            Console.WriteLine();
            Console.WriteLine($"Your character's basic abilities: \nIntelligence: {Statistics.Intelligence} \nEndurance: {Statistics.Endurance} \nStrength: {Statistics.Strength} \nAgility: {Statistics.Agility}");
        }

        public void UpgradeStatisticsAndGetReward()
        {
            Dictionary<string, int>
                distributedPoints =
                    Statistics
                        .UpgradeStatistics();

            Console.WriteLine(
                "Thanks to upgrading your character, you have received these special items for your inventory.");
            Console.WriteLine("Press 'Enter' to check out new items in your inventory.");
            Console.ReadLine();

            ConsolePrinter.PrintChest();

            foreach (string statisticName in distributedPoints.Keys)
            {
                switch (statisticName)
                {
                    case nameof(Statistics.Intelligence):
                        AddExtraIntelligenceItemToInventory(distributedPoints[statisticName]);
                        break;
                    case nameof(Statistics.Agility):
                        AddExtraAgilityItemToInventory(distributedPoints[statisticName]);
                        break;
                    case nameof(Statistics.Endurance):
                        AddExtraEnduranceItemToInventory(distributedPoints[statisticName]);
                        break;
                    case nameof(Statistics.Strength):
                        AddExtraStrengthItemToInventory(distributedPoints[statisticName]);
                        break;
                    default:
                        break;
                }
            }
        }

        public void PrintInventory()
        {
            foreach (string item in Inventory)
            {
                Console.WriteLine(item);
            }
        }

        private void AddExtraIntelligenceItemToInventory(int points)
        {
            if (points >= 3)
            {
                Inventory.Add("* Scroll containing a healing spell");

                if (points >= 5)
                {
                    Inventory.Add("* Enchanted book containing a destructive spell");

                    if (points >= 7)
                    {
                        Inventory.Add("* Mage's robe restoring mana");
                    }
                }
            }
        }

        private void AddExtraEnduranceItemToInventory(int points)
        {
            if (points >= 3)
            {
                Inventory.Add("* Shoes restoring stamina 10 % faster  ");

                if (points >= 5)
                {
                    Inventory.Add("* Steel fists (heavy armor, light weight) ");

                    if (points >= 7)
                    {
                        Inventory.Add("* Jewel of stamina (attacks drain 20 % less stamina) ");
                    }
                }
            }
        }

        private void AddExtraStrengthItemToInventory(int points)
        {
            if (points >= 3)
            {
                Inventory.Add("* Necklace of strength (10 % bigger carry limit) ");

                if (points >= 5)
                {
                    Inventory.Add("* Shield of protection (10 % more efficient defensiveness ");

                    if (points >= 7)
                    {
                        Inventory.Add("* Dragon blade (sword with poisoned blade) ");
                    }
                }
            }
        }

        private void AddExtraAgilityItemToInventory(int points)
        {
            if (points >= 3)
            {
                Inventory.Add("* Extra fast throwing knife ");

                if (points >= 5)
                {
                    Inventory.Add("* Light bow of accuracy");

                    if (points >= 7)
                    {
                        Inventory.Add("* Shoes of silence (sneaking 20 % more efficient ");
                    }
                }
            }
        }

        public virtual void DescribeClasses()
        {
            ConsolePrinter.PrintSeparator();
            Console.WriteLine();
            Console.WriteLine("You can choose from 3 different classes: Mage, Warrior, Rogue.");
        }

        public void EndCreator()
        {
            Console.WriteLine($"Now {Name} is ready for a great adventure!" );
        }
    }
}