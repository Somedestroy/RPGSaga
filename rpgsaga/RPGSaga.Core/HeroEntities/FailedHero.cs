namespace RPGSaga.Core
{
    using System;

    public class FailedHero : Hero
    {
        public FailedHero(string name, int healthPoint, int damage)
            : base(name, healthPoint, damage)
        {
            HeroType = Game.HeroTypes.FailedHero.ToString();
        }

        public override void Attacked(Hero enemyHero)
        {
            throw new Exception("Failed enemy have imunnity");
        }
    }
}
