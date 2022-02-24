namespace RpgSaga.Tests.Entities
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;

    public class HeroAlreadyUsedAbility : Hero
    {
        public HeroAlreadyUsedAbility(string name, int healthPoint, int damage)
           : base(name, healthPoint, damage)
        {
            ListOfAbilities = new List<IAbility>() { new AlreadyUsedAbility("Nothing", 15, 100, 0) };
        }
    }
}
