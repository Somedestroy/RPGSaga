namespace RpgSaga.Tests
{
    using System;
    using RPGSaga.Core;
    using Xunit;

    public class GameTest
    {
        [Fact]
        public void CreatedHeroesNumberIsValid()
        {
            Random rand = new Random();
            int inputNumber = rand.Next(1, 500);

            var result = Game.CreateRandomHeroes(inputNumber);

            Assert.Equal(inputNumber, result.Count);
        }
    }
}
