namespace RpgSaga.Effects
{
    public class Freeze : BaseEffect
    {
        public Freeze(string effectName, int duration, int permanentDamage, bool skipTurn, bool selfEffect)
             : base(effectName, duration, permanentDamage, skipTurn, selfEffect)
        {
        }
    }
}
