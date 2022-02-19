namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;

    public class Freeze : IEffect
    {
        public string EffectName { get; } = "Freeze";

        public int Duration { get; set; } = 1;

        public int PermanentDamage { get; } = 0;

        public bool SkipTurn { get; } = true;

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
