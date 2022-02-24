namespace RPGSaga.Core
{
    using RpgSaga.Exceptions;

    public class FailedHero : Hero
    {
        public FailedHero(string name, int healthPoint, int damage)
            : base(name, healthPoint, damage)
        {
            HeroType = Game.HeroTypes.FailedHero.ToString();
        }

        public override void Attacked(Hero enemyHero)
        {
            throw new FailedHeroException("Faild hero has immunity to damage!");
        }

        public override bool UsedAbility(Hero enemyHero)
        {
            throw new FailedHeroException("Faild hero has immunity to damage!");
        }
    }
}
