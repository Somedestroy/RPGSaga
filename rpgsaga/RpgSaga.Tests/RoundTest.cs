namespace RpgSaga.Tests
{
    using System;
    using RPGSaga.Core;
    using Xunit;

    public class RoundTest
    {
        [Fact]
        public void GeneratedPairsIsCorrect()
        {
            // Arange
            Round round = new Round();
            Random rand = new Random();
            int numberOfHeroes = rand.Next(1, 100);
            var listOfHeroes = Game.CreateRandomHeroes(numberOfHeroes);

            // Act
            round.CreatePairs(listOfHeroes);

            // Assert
            Assert.True(listOfHeroes.Count == 0);
        }
    }
}
