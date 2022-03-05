namespace RpgSaga.Abilities
{
    using System.Collections.Generic;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;

    public class BurningArrows : BaseAbility
    {
        public BurningArrows(string abilityName, int damage, int probablity, int numberOfUse)
            : base(abilityName, damage, probablity, numberOfUse)
        {
            AvailableEffects = new List<IEffect> { new Burning("Burning", 1, 15, false, false) };
        }
    }
}
