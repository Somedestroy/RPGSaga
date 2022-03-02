namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;

    public class ArgsHeroSource : IHeroSource
    {
        private readonly HeroGenerator heroGenerator;
        private readonly int heroesNumber;

        public ArgsHeroSource(int heroesNumber)
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
