namespace RpgSaga.Tests.Entities
{
    using System.Collections.Generic;
    using RpgSaga.Abilities;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;

    public class PermanentDamage : Hero
    {
        public PermanentDamage(string name, int healthPoint, int damage)
          : base(name, healthPoint, damage)
        {
            ListOfAbilities = new List<IAbility>() { new Rupture("Nothing", 25, 100, 1) };
        }
    }
}
