namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;

    public abstract class BaseEffect : IEffect
    {
        public string EffectName { get; }

        public int Duration { get; set; }

        public int PermanentDamage { get; }

        public bool SkipTurn { get; }

        public bool SelfEffect { get; }

        public BaseEffect(string effectName, int duration, int permanentDamage, bool skipTurn, bool selfEffect)
        {
            EffectName = effectName;
            Duration = duration;
            PermanentDamage = permanentDamage;
            SkipTurn = skipTurn;
            SelfEffect = selfEffect;
        }

        public virtual bool UseEffect()
        {
            if (Duration > 0)
            {
                Duration--;
                return true;
            }

            return false;
        }
    }
}
