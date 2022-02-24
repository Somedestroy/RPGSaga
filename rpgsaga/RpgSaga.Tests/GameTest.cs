namespace RpgSaga.Tests
{
    using RPGSaga.Core;
    using Xunit;

    public class GameTest
    {
        [Theory]
        [InlineData(100)]
        public void CreatedHeroesNumberIsValid(int heroesNumber)
        {
            var result = Game.CreateRandomHeroes(heroesNumber);
            Assert.Equal(result.Count, heroesNumber);
        }
    }
}
