using System;

namespace _2_Project
{
    public class Elf : Hero
    {
        public Elf(string name, int intelligence = 40, int endurance = 20, int strength = 10, int agility = 30) : base(name, intelligence, endurance, strength, agility)
        {
        }

        public override void ShowStatistics()
        {
            base.ShowStatistics();
            Console.WriteLine();
            Console.WriteLine("The Elves, inhabit woods and consider themselves to be the most civilized culture in the world.The common tongue is based on Elvish speech and writing.");
        }

        public override void DescribeClasses()
        {
            base.DescribeClasses();
            Console.WriteLine();
            Console.WriteLine("Preferred play-style for elf is Mage.");
            Console.WriteLine();
            Console.WriteLine("* As Mage, elf study magic for its intellectual rewards, but is also well skilled in casting the most powerful spells and creating the best potions.");
            Console.WriteLine("* As Rogue, elf is good at sneaking and casting deafening and blinding spells. But marksman skills are limited.");
            Console.WriteLine("* As Warrior, elf is less effective, due to his/her poor Endurance. Elf is able to use a sword and simple shield, but is not as skilled as orsimer.");
        }
    }
}
