using System;
using System.Linq;


namespace _2_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter.PrintCharacterCreator();
            ConsolePrinter.PrintSeparator();
            Console.WriteLine();

            string name = AskForString("Choose your character name.");
            Console.WriteLine();

            RaceType race = GetRace();

            Hero hero = GetHero(race, name);

            hero.ShowStatistics();

            hero.UpgradeStatisticsAndGetReward();

            hero.PrintInventory();

            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to choose your class.");
            Console.ReadLine();

            hero.DescribeClasses();

            Console.WriteLine();
            ConsolePrinter.PrintSeparator();
            Console.WriteLine();
            Console.WriteLine("Now it is time, to choose your class. Every class has its own benefits and weaknesses and is more or less suitable for your race. Choose wisely.");

            ClassType heroClass = GetClass();
            hero.ClassType = heroClass;

            ConsolePrinter.PrintClass(heroClass);

            Console.WriteLine();
            hero.EndCreator();

            Console.ReadLine();
        }

        public static Hero GetHero(RaceType race, string name)
        {
            switch (race)
            {
                case RaceType.Elf:
                    return new Elf(name);
                case RaceType.Orsimer:
                    return new Orsimer(name);
                case RaceType.Man:
                    return new Man(name);
                default:
                    return null;
            }
        }

        public static RaceType GetRace()
        {
            string[] raceOptions = Enum.GetNames(typeof(RaceType));
            TryAskForOneOption(@"Who would you like to become? 

Elf? The Elves are extremely proficient with magic ........ write: elf
Orsimer? Courageous and rough warrior ..................... write: orsimer
Man? Strikes your enemy from afar ......................... write: man
Choose wisely...", raceOptions, out string race);

            Console.WriteLine();

            while (true)
            {
                ConsolePrinter.PrintPreferredPlayStyle((RaceType)Enum.Parse(typeof(RaceType), race, true));

                Console.WriteLine();

                if (TryAskForOneOption(
                    $"Are you sure you want to be an '{race}' ? If so, confirm it by writing 'done'. If not, choose other race.",
                    raceOptions, out string newRace, isFinal: true))
                {
                    race = newRace;
                }
                else
                {
                    break;
                }
            }

            return (RaceType)Enum.Parse(typeof(RaceType), race, true);
        }

        public static ClassType GetClass()
        {
            string[] classOptions = Enum.GetNames(typeof(ClassType));
            TryAskForOneOption(@"Who would you like to become? 

Mage..........write: mage
Warrior ....... write: warrior
Rogue ......... write: rogue", classOptions, out string heroClass);

            Console.WriteLine();

            while (true)
            {
                
                Console.WriteLine();

                if (TryAskForOneOption(
                    $"Are you sure you want to be an '{heroClass}' ? If so, confirm it by writing 'done'. If not, choose other class.",
                    classOptions, out string newRace, isFinal: true))
                {
                    heroClass = newRace;
                }
                else
                {
                    break;
                }
            }

            return (ClassType)Enum.Parse(typeof(ClassType), heroClass, true);
        }

        public static string AskForString(string question)
        {
            Console.WriteLine(question);
            string result = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("Try it one more time.");
                result = Console.ReadLine();
            }
            return result;
        }

        public static bool TryAskForOneOption(string question, string[] options, out string answer, bool isFinal = false)
        {
            const string final = "done";

            Console.WriteLine(question);

            answer = Console.ReadLine();
            bool isAnswered = !(isFinal && string.Equals(answer, final));
            bool isValidOption = options.Contains(answer, StringComparer.OrdinalIgnoreCase) || !isAnswered;

            while (!isValidOption)
            {
                Console.WriteLine($"Try it one more time. {question}");
                answer = Console.ReadLine();
                isValidOption = options.Contains(answer, StringComparer.OrdinalIgnoreCase);
            }

            return isAnswered;
        }

        public static int AskForNumber()
        {
            int number = 0;
            bool isNumber = false;

            while (!isNumber)
            {
                string numberText = Console.ReadLine();
                isNumber = int.TryParse(numberText, out number);
            }

            return number;
        }

        public static int AskForNumber(int max, int min = 0)
        {
            Console.WriteLine($"Select a number. Selected number has to be in the range from {min} to {max}.");

            int number = AskForNumber();

            while (number < 0 || number > 10)
            {
                if (number < 0)
                {
                    Console.WriteLine($"Choose bigger number. Selected number has to be in the range from {min} to {max}.");
                }
                else
                {
                    Console.WriteLine($"Choose smaller number. Selected number has to be in the range from {min} to {max}.");
                }

                number = AskForNumber();
            }

            return number;
        }


    }
}
