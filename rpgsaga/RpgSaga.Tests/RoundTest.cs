namespace RpgSaga.Tests
{
    using RPGSaga.Core;
    using Xunit;

    public class RoundTest
    {
        [Fact]
        public void GeneratedPairsIsCorrect()
        {
            // Arange
            Round round = new Round();
            int numberOfHeroes = 5;
            var listOfHeroes = Game.CreateRandomHeroes(numberOfHeroes);

            // Act
            round.CreatePairs(listOfHeroes);

            // Assert
            Assert.True(listOfHeroes.Count == 0);
        }
    }
}
