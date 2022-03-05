namespace RpgSaga.Tests
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using Xunit;

    public class HeroGeneratorTest
    {
        [Fact]
        public void GenerateHeroesIsCorrect()
        {
            HeroGenerator heroGenerator = new HeroGenerator();
            _ = new List<Hero>();
            int heroesNumber = 104;

            List<Hero> heroesList = heroGenerator.Generate(heroesNumber);

            Assert.Equal(heroesNumber, heroesList.Count);
        }
    }
}
