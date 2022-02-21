namespace RpgSaga.Abilities
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;

    public class Rupture : IAbility
    {
        public string AbilityName { get; } = "Rupture";

        public int Damage { get; } = 14;

        public int Probability { get; } = 40;

        public int NumberOfUse { get; set; } = 1;

        public List<IEffect> AvailableEffects { get; set; } = new List<IEffect> { new Bleeding() };

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
