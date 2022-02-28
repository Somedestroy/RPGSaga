namespace RpgSaga.Configuration
{
    using System;
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;

    public class KeyboardConfig : IGameConfig
    {
        private readonly HeroGenerator heroGenerator;
        private int heroesNumber;

        public KeyboardConfig()
        {
            heroGenerator = new HeroGenerator();
        }

        public List<Hero> GetHeroes()
        {
            GetHeroesNumber();
            return heroGenerator.Generate(heroesNumber);
        }

        private void GetHeroesNumber()
        {
            Logger.Info("Enter the number of heroes. Number must be non-zero");
            string inputString = Console.ReadLine();
            while (!int.TryParse(inputString, out heroesNumber))
            {
                Logger.Error("This is not a number! Please try again");
                inputString = Console.ReadLine();
            }

            while (heroesNumber <= 0)
            {
                Logger.Error("You must enter a positive number");
                inputString = Console.ReadLine();
                heroesNumber = Convert.ToInt32(inputString);
            }

            heroesNumber = Convert.ToInt32(inputString);
        }
    }
}
