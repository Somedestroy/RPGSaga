namespace RpgSaga.Interfaces
{
    using System.Collections.Generic;

    public interface IAbility
    {
        string AbilityName { get; }

        int Damage { get; }

        int Probability { get; }

        int NumberOfUse { get; set; }

        List<IEffect> AvailableEffects { get; set; }

        bool UseAbility();
    }
}
