namespace RpgSaga.Tests
{
    using System;
    using RPGSaga.Core;
    using RpgSaga.Exceptions;
    using RpgSaga.Tests.Entities;
    using Xunit;

    public class HeroTest
    {
        [Fact]
        public void AttackedByEnemyHero()
        {
            // Arrange
            Hero hero = new Knight("Ilon Mask", 100, 15);
            int originalHP = hero.HealthPoints;
            Hero enemyHero = new Archer("Bill Gates", 90, 30);

            // Act
            hero.Attacked(enemyHero);

            // Assert
            Assert.Equal(hero.HealthPoints, originalHP - enemyHero.Damage);
        }

        [Fact]
        public void RegenerationHP()
        {
            // Arrange
            Hero hero = new Wizard("Vin Diesel", 90, 24);
            int newHP = 300;

            // Act
            hero.Regeneration(newHP);

            // Assert
            Assert.Equal(newHP, hero.HealthPoints);
        }

        [Fact]
        public void UsedAbilityFalseIfPullIsEmpty()
        {
            // Arrange
            Hero hero = new Knight("Tom Cruise", 110, 19);
            Hero enemyhero = new HeroWithoutAbilities("Leonardo DiCaprio", 110, 25);

            // Act
            hero.UsedAbility(enemyhero);

            // Assert
            Assert.False(enemyhero.ListOfAbilities != null);
        }

        [Fact]
        public void UsedAbilityFalseIfAbilityAlreadyUsed()
        {
            // Arrange
            Hero hero = new Knight("Tom Cruise", 110, 19);
            Hero enemyhero = new HeroAlreadyUsedAbility("Leonardo DiCaprio", 110, 25);
            hero.UsedAbility(enemyhero);

            // Act
            bool result = hero.UsedAbility(enemyhero);

            // Assert
            Assert.False(result);
        }

        [Fact]

        public void UsedAbilityTrueIfAbilityAvailable()
        {
            // Arrange
            Hero hero = new Archer("Tom Cruise", 110, 19);
            Hero enemyhero = new HeroWithAvailableAbility("Leonardo DiCaprio", 110, 25);

            // Act
            bool result = hero.UsedAbility(enemyhero);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UsedAbilityGetDamage()
        {
            // Arrange
            Hero hero = new Wizard("Quentin Tarantino", 90, 24);
            Hero enemyHero = new HeroWithAvailableAbility("Christopher Nolan", 120, 34);
            int initialHP = hero.HealthPoints;

            // Act
            hero.UsedAbility(enemyHero);

            // Assert
            Assert.Equal(hero.HealthPoints, initialHP - enemyHero.ListOfAbilities[0].Damage);
        }

        [Fact]

        public void ApplyEffectSkipTurn()
        {
            // Arrange
            Hero enemyHero = new HeroWithSkipTurnAbility("Martin Scorsese", 110, 22);
            Hero hero = new Knight("James Cameron", 120, 19);
            hero.UsedAbility(enemyHero);

            // Act
            hero.ApplyEffects();

            // Assert
            Assert.True(hero.SkipTurn);
        }

        [Fact]
        public void ApplyEffectPermanentDamage()
        {
            // Arrange
            Hero enemyHero = new PermanentDamage("Quentin Tarantino", 120, 24);
            Hero hero = new Wizard("Stiven Spilberg", 120, 19);
            int initialHP = hero.HealthPoints;
            hero.UsedAbility(enemyHero);

            // Act
            hero.ApplyEffects();

            // Assert
            Assert.False(initialHP == hero.HealthPoints);
        }

        [Fact]
        public void RefreshAbilitiesAfterWin()
        {
            // Arange
            Hero enemyHero = new PermanentDamage("Clint Eastwood", 120, 24);
            Hero hero = new Wizard("Woody Allen", 120, 19);
            hero.UsedAbility(enemyHero);

            // Act
            enemyHero.RefreshAbilities();

            // Assert
            Assert.True(enemyHero.ListOfAbilities[0].NumberOfUse == 1);
        }

        [Fact]
        public void HeroDoesntDealDamageIfSkipTurn()
        {
            // Arrange
            Hero enemyHero = new HeroWithSkipTurnAbility("George Lucas", 120, 23);
            Hero hero = new Knight("Tim Burton", 112, 27);
            int health = enemyHero.HealthPoints;

            // Act
            hero.UsedAbility(enemyHero);

            // Assert
            Assert.True(health == enemyHero.HealthPoints);
        }

        [Fact]

        public void EqualsTwoObjectTrue()
        {
            // Arange
            var firstHero = new Knight("Carlie Chaplin", 110, 5000);
            var secondHero = new Knight("Carlie Chaplin", 110, 5000);

            // Act
            bool result = firstHero.Equals(secondHero);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HeroIsDied()
        {
            // Arrange
            var hero = new Knight("Alfred Hitchcock", -5000, 45);

            // Act
            bool result = hero.IsAlive();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HeroIsAlive()
        {
            // Arrange
            var hero = new Knight("Akira Kurosawa", 5000, 45);

            // Act
            bool result = hero.IsAlive();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CatchFailedHero()
        {
            var hero = new FailedHero("Joe Baiden", 5000, 45);
            var enemyHero = new Archer("Vladimir Putin", 5000, 45);

            Action action = () => hero.Attacked(enemyHero);

            Assert.Throws<FailedHeroException>(action);
        }
    }
}
