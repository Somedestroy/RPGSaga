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
            List<Hero> heroesList = new List<Hero>();
            int heroesNumber = 104;

            heroesList = heroGenerator.Generate(heroesNumber);

            Assert.Equal(heroesNumber, heroesList.Count);
        }
    }
}
