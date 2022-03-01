namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class ArgsConfig : IInputConfig
    {
        private readonly HeroGenerator heroGenerator;
        private readonly int heroesNumber;
        private readonly FileService fileService;

        public ArgsConfig(int heroesNumber, string fileNameToSave = null)
        {
            this.heroesNumber = heroesNumber;
            heroGenerator = new HeroGenerator();
            fileService = new FileService(fileNameToSave);
        }

        public List<Hero> GetHeroes()
        {
            return heroGenerator.Generate(heroesNumber);
        }

        public void SaveHeroes(List<Hero> heroes)
        {
            fileService.SaveFile(heroes);
        }
    }
}
