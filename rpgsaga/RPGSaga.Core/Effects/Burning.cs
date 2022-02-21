namespace RpgSaga.Effects
{
    public class Burning : BaseEffect
    {
        public Burning(string effectName, int duration, int permanentDamage, bool skipTurn, bool selfEffect)
             : base(effectName, duration, permanentDamage, skipTurn, selfEffect)
        {
        }
    }
}
