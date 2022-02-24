namespace RpgSaga.Tests.Entities
{
    using RPGSaga.Core;

    public class HeroWithoutAbilities : Hero
    {
        public HeroWithoutAbilities(string name, int healthPoint, int damage)
            : base(name, healthPoint, damage)
        {
        }
    }
}
