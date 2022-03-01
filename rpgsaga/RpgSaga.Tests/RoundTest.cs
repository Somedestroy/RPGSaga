namespace RpgSaga.Tests
{
    using System;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using Xunit;

    public class RoundTest
    {
        [Fact]
        public void GeneratedPairsIsCorrect()
        {
            // Arange
            Round round = new Round();
            Random rand = new Random();
            HeroGenerator heroGenerator = new HeroGenerator();
            int numberOfHeroes = rand.Next(1, 100);
            var listOfHeroes = heroGenerator.Generate(numberOfHeroes);

            // Act
            round.StartRound(listOfHeroes);

            // Assert
            Assert.True(listOfHeroes.Count == 0);
        }
    }
}
