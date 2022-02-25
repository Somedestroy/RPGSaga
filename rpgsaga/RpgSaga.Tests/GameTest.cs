namespace RpgSaga.Tests
{
    using System;
    using RPGSaga.Core;
    using Xunit;

    public class GameTest
    {
        [Fact]
        public void CreatedNumberOfHeroesIsCorrect()
        {
            Random rand = new Random();
            var inputNumber = rand.Next(1, 100);

            var result = Game.CreateRandomHeroes(inputNumber);

            Assert.Equal(inputNumber, result.Count);
        }
    }
}
