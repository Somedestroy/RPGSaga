namespace RpgSaga.Abilities
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;

    public abstract class BaseAbility : IAbility
    {
        public BaseAbility(string abilityName, int damage, int probablity, int numberOfUse)
        {
            AbilityName = abilityName;
            Damage = damage;
            Probability = probablity;
            NumberOfUse = numberOfUse;
        }

        public string AbilityName { get; }

        public int Damage { get; }

        public int Probability { get; }

        public int NumberOfUse { get; set; }

        public List<IEffect> AvailableEffects { get; set; }

        public virtual bool UseAbility()
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
