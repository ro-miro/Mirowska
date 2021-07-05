using System;


namespace _2_Project
{
    public class Orsimer : Hero
    {
        public Orsimer(string name, int intelligence = 10, int endurance = 30, int strength = 40, int agility = 20) : base(name, intelligence, endurance, strength, agility)
        {
        }
        public override void ShowStatistics()
        {
            base.ShowStatistics();
            Console.WriteLine();
            Console.WriteLine("Orsimer, also known as Orcs, are a race that hail from Orsinium. They are best recognized by their dark green skin and large build.");
        }

        public override void DescribeClasses()
        {
            base.DescribeClasses();
            Console.WriteLine();
            Console.WriteLine("Preferred play-style for orsimer is Warrior.");
            Console.WriteLine();
            Console.WriteLine("* As Warrior, orsimer uses effectively heavy armor which is governed by the Endurance and provides protection.");
            Console.WriteLine("  To use this style of armor effectively, the wearer must be trained, conditioned, and skilled in its use.");
            Console.WriteLine("* As Rogue, orsimer can use weapons like bow, throwing star, and throwing knife in effective way, but is much more visible target than man, while sneaking." );
            Console.WriteLine("* As Mage, orsimer is less effective, due to his/her poor Intelligence. Orsimer can cast just simple healing spells and makes basic potions.");
        }
    }
}
