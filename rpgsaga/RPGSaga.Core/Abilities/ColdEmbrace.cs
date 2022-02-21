namespace RpgSaga.Abilities
{
    using System.Collections.Generic;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;

    public class ColdEmbrace : BaseAbility
    {
        public ColdEmbrace(string abilityName, int damage, int probablity, int numberOfUse)
            : base(abilityName, damage, probablity, numberOfUse)
        {
            AvailableEffects = new List<IEffect> { new Freeze("Freeze", 1, 0, true, false) };
        }
    }
}
