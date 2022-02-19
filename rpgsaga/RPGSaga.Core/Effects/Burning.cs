namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;

    public class Burning : IEffect
    {
        public string EffectName { get; } = "Burning";

        public int Duration { get; set; } = 1;

        public int PermanentDamage { get; } = 15;

        public bool SkipTurn { get; } = false;

        public bool SelfEffect { get; } = false;

        public bool UseEffect()
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
