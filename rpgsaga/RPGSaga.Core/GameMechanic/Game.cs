namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;

    public static class Game
    {
        public static Random Rand;

        public static NamesGenerator namesGenerator;

        private static List<Hero> heroesList;

        public static Round round;

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

        public static List<Hero> CreateRandomHeroes(int heroesNumber)
        {
            for (int index = 0; index < heroesNumber; index++)
            {
                switch (Rand.Next(1, 3))
                {

                    case 1:
                        heroesList.Add(new Knight(namesGenerator.GetHeroName(), Rand.Next(150, 180), Rand.Next(30, 40)));
                        break;
                    case 2:
                        heroesList.Add(new Wizard(namesGenerator.GetHeroName(), Rand.Next(90, 120), Rand.Next(15, 25)));
                        break;
                    case 3:
                        heroesList.Add(new Archer(namesGenerator.GetHeroName(), Rand.Next(120, 140), Rand.Next(20, 35)));
                        break;
                }
            }

            Console.WriteLine("Heroes was successfully created");
            return heroesList;
        }
    }
}
