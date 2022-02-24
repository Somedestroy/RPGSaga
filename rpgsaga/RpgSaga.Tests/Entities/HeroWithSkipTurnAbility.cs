namespace RpgSaga.Tests.Entities
{
    using System.Collections.Generic;
    using RpgSaga.Abilities;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;

    public class HeroWithSkipTurnAbility : Hero
    {
        public HeroWithSkipTurnAbility(string name, int healthPoint, int damage)
           : base(name, healthPoint, damage)
        {
            ListOfAbilities = new List<IAbility>() { new ColdEmbrace("Nothing", 25, 100, 1) };
        }
    }
}
