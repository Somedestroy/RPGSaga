namespace RPGSaga.Core
{
    using System.Collections.Generic;
    using RpgSaga.Abilities;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;

    public class Archer : Hero
    {
        public Archer()
        {
        }

        public Archer(string name, int healthPoint, int damage)
            : base(name, healthPoint, damage)
        {
            ListOfAbilities = new List<IAbility>() { new BurningArrows("Burning Arrows", 34, 45, 1) };
            HeroType = HeroTypes.Archer.ToString();
        }
    }
}
