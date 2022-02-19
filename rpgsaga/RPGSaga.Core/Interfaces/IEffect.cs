namespace RpgSaga.Interfaces
{
    public interface IEffect
    {
        string EffectName { get; }

        int Duration { get; set; }

        int PermanentDamage { get; }

        bool SkipTurn { get; }

        bool SelfEffect { get; }

        bool UseEffect();
    }
}
