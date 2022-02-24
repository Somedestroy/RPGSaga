namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;

    public static class Game
    {
        public static Random Rand;

        private static readonly NamesGenerator namesGenerator;

        private static List<Hero> heroesList;

        private static Round round;

        public static int RoundCounter { get; set; }

        static Game()
        {
            Rand = new Random();
            heroesList = new List<Hero>();
            namesGenerator = new NamesGenerator();
            round = new Round();
            RoundCounter = 1;
        }

        public static void Run()
        {
            round.CreatePairs(CreateRandomHeroes(GetHeroesNumber()));
        }

        public static int GetHeroesNumber()
        {
            Console.WriteLine("Enter the number of heroes. Number must be non-zero");
            int inputNumber;
            string inputString = Console.ReadLine();
            while (!int.TryParse(inputString, out inputNumber))
            {
                Console.WriteLine("This is not a number! Please try again");
                inputString = Console.ReadLine();
            }

            while (inputNumber <= 0)
            {
                Console.WriteLine("You must enter a positive number");
                inputString = Console.ReadLine();
                inputNumber = Convert.ToInt32(inputString);
            }

            return inputNumber;
        }

        public enum HeroTypes
        {
            Knight = 1,
            Wizard = 2,
            Archer = 3,
        }

        public static List<Hero> CreateRandomHeroes(int heroesNumber)
        {
            var values = Enum.GetValues(typeof(HeroTypes));
            for (int index = 0; index < heroesNumber; index++)
            {
                switch ((HeroTypes)Rand.Next(1, values.Length))
                {
                    case HeroTypes.Knight:
                        heroesList.Add(new Knight(namesGenerator.GetHeroName(), Rand.Next(150, 180), Rand.Next(15, 19)));
                        break;
                    case HeroTypes.Wizard:
                        heroesList.Add(new Wizard(namesGenerator.GetHeroName(), Rand.Next(90, 120), Rand.Next(10, 15)));
                        break;
                    case HeroTypes.Archer:
                        heroesList.Add(new Archer(namesGenerator.GetHeroName(), Rand.Next(120, 140), Rand.Next(13, 17)));
                        break;
                }
            }

            Console.WriteLine("Heroes were successfully created");
            return heroesList;
        }
    }
}
