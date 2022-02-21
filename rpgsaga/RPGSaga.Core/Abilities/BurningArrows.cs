namespace RpgSaga.Abilities
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;

    public class BurningArrows : IAbility
    {
        public string AbilityName { get; } = "Burning Arrows";

        public int Damage { get; } = 10;

        public int Probability { get; } = 40;

        public int NumberOfUse { get; set; } = 1;

        public List<IEffect> AvailableEffects { get; set; } = new List<IEffect> { new Burning() };

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
