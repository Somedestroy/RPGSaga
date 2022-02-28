namespace RPGSaga.Core
{
    using System.Collections.Generic;
    using RpgSaga.Abilities;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;

    public class Knight : Hero
    {
        public Knight()
        {
        }

        public Knight(string name, int healthPoint, int damage)
            : base(name, healthPoint, damage)
        {
            ListOfAbilities = new List<IAbility>() { new Rupture("Rupture", 40, 55, 1) };
            HeroType = HeroTypes.Knight.ToString();
        }
    }
}
