namespace RpgSaga.Abilities
{
    using System.Collections.Generic;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;

    public class Rupture : BaseAbility
    {
        public Rupture(string abilityName, int damage, int probablity, int numberOfUse)
            : base(abilityName, damage, probablity, numberOfUse)
        {
            AvailableEffects = new List<IEffect> { new Bleeding("Bleeding", 1, 24, false, false) };
        }
    }
}
