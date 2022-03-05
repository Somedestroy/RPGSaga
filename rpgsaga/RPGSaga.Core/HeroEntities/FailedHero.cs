namespace RPGSaga.Core
{
    using RpgSaga.Exceptions;
    using RpgSaga.HeroEntities;

    public class FailedHero : Hero
    {
        public FailedHero()
        {
        }

        public FailedHero(string name, int healthPoint, int damage)
            : base(name, healthPoint, damage)
        {
            HeroType = HeroTypes.FailedHero.ToString();
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
