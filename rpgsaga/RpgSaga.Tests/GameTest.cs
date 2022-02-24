namespace RpgSaga.Tests
{
    using RPGSaga.Core;
    using Xunit;

    public class GameTest
    {
        [Fact]
        public void CreatedHeroesNumberIsValid()
        {
            int inputNumber = 115;

            var result = Game.CreateRandomHeroes(inputNumber);

            Assert.Equal(inputNumber, result.Count);
        }
    }
}
