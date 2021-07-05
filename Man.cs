using System;

namespace _2_Project
{
    public class Man : Hero
    {
        public Man(string name, int intelligence = 30, int endurance = 10, int strength = 20, int agility = 40) : base(name, intelligence, endurance, strength, agility)
        {
        }

        public override void ShowStatistics()
        {
            base.ShowStatistics();
            Console.WriteLine();
            Console.WriteLine("Man are skilled in marksmanship and sneaking. Well educated, recognized by their athletic build.");
        }
        public override void DescribeClasses()
        {
            base.DescribeClasses();
            Console.WriteLine();
            Console.WriteLine("Preferred play-style for man is Rogue.");
            Console.WriteLine();
            Console.WriteLine("* As Rogue, man is more effective with ranged weapons like bow, throwing star, and throwing knife. Man also achieves better results while sneaking.");
            Console.WriteLine("* As Mage, man can cast powerful healling and destructive spells. On the other hand, potions made by man are always less powerful than elvish ones.");
            Console.WriteLine("* As Warrior, man is less effective, due to his/her poor Endurance. Man is not able to use heavy armor and heavy weapon like mace.");
            Console.WriteLine("  The most suitable weapon for man warrior is simple sword.");
        }
    }
}
