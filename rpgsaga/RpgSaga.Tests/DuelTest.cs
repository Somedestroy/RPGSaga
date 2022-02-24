namespace RpgSaga.Tests
{
    using RPGSaga.Core;
    using Xunit;

    public class DuelTest
    {
        [Fact]
        public void GetWinner()
        {
            // Arrange
            Hero hero1 = new Knight("Brad Pitt", 140, 15);
            Hero hero2 = new Wizard("Russel Crowl", 0, 20);
            Duel duel = new Duel();

            // Act
            var result = duel.StartDuel(hero1, hero2);

            // Assert
            Assert.True(result == hero1);
        }
    }
}
