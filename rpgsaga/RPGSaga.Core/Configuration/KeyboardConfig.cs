namespace RpgSaga.Configuration
{
    using System;
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;
    using RpgSaga.Serialization;

    public class KeyboardConfig : IInputConfig
    {
        private readonly HeroGenerator heroGenerator;
        private readonly FileService fileService;

        public KeyboardConfig()
        {
            heroGenerator = new HeroGenerator();
        }

        public KeyboardConfig(string fileNameToSave)
        {
            fileService = new FileService(fileNameToSave);
        }

        public List<Hero> GetHeroes()
        {
            return heroGenerator.Generate(GetHeroesNumber());
        }

        public void SaveHeroes(List<Hero> heroes)
        {
            fileService.SaveFile(heroes);
        }

        private int GetHeroesNumber()
        {
            int heroesNumber;
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

            return heroesNumber;
        }
    }
}
