namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;

    public class ArgsConfig : IGameConfig
    {
        private readonly HeroGenerator heroGenerator;
        private readonly int heroesNumber;

        public ArgsConfig(int heroesNumber)
        {
            this.heroesNumber = heroesNumber;
            heroGenerator = new HeroGenerator();
        }

        public List<Hero> GetHeroes()
        {
            return heroGenerator.Generate(heroesNumber);
        }
    }
}
