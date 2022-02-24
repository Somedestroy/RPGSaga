namespace RpgSaga.Tests
{
    using RPGSaga.Core;
    using Xunit;

    public class RoundTest
    {
        [Theory]
        [InlineData(5)]
        [InlineData(100)]
        public void GeneratedPairsIsCorrect(int numberOfHeroes)
        {
            // Arange
            Round round = new Round();
            var listOfHeroes = Game.CreateRandomHeroes(numberOfHeroes);

            // Act
            round.CreatePairs(listOfHeroes);

            // Assert
            Assert.True(listOfHeroes.Count == 0);
        }
    }
}
