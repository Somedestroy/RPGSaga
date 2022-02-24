namespace RpgSaga.Tests.Entities
{
    using System.Collections.Generic;
    using RpgSaga.Abilities;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;

    public class AlreadyUsedAbility : BaseAbility
    {
        public AlreadyUsedAbility(string abilityName, int damage, int probablity, int numberOfUse)
             : base(abilityName, damage, probablity, numberOfUse)
        {
            AvailableEffects = new List<IAbility> { new Freeze("Freeze", 1, 0, true, false) };
        }
    }
}
