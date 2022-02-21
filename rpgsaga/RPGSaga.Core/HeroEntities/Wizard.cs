namespace RPGSaga.Core
{
    using System.Collections.Generic;
    using RpgSaga.Abilities;
    using RpgSaga.Interfaces;

    public class Wizard : Hero
    {
        public Wizard(string name, int healthPoint, int damage)
            : base(name, healthPoint, damage)
        {
            ListOfAbilities = new List<IAbility>() { new ColdEmbrace("Cold Embrace", 24, 100, 1) };
        }

    }
}
