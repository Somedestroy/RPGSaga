namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;

    public class Bleeding : IEffect
    {
        public string EffectName { get; } = "Bleeding";

        public int Duration { get; set; } = 1;

        public int PermanentDamage { get; } = 35;

        public bool SkipTurn { get; } = false;

        public bool SelfEffect { get; } = true;

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
