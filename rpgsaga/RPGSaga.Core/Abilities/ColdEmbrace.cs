namespace RpgSaga.Abilities
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;

    public class ColdEmbrace : IAbility
    {
        public string AbilityName { get; } = "Cold Embrace";

        public int Damage { get; } = 40;

        public int Probability { get; } = 30;

        public int NumberOfUse { get; set; } = 1;

        public List<IEffect> AvailableEffects { get; set; } = new List<IEffect> { new Freeze() };

        public bool UseAbility()
        {
            if (NumberOfUse == 0)
            {
                return false;
            }

            if (Game.Rand.Next(0, 100) <= Probability)
            {
                NumberOfUse--;
                return true;
            }

            return false;
        }
    }
}
