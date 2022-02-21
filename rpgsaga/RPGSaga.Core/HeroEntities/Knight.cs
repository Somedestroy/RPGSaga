namespace RPGSaga.Core
{
    using System.Collections.Generic;
    using RpgSaga.Abilities;
    using RpgSaga.Interfaces;

    public class Knight : Hero
    {
        public Knight(string name, int healthPoint, int damage)
            : base(name, healthPoint, damage)
        {
            ListOfAbilities = new List<IAbility>() { new Rupture("Rupture", 40, 100, 1) };
        }

    }
}
