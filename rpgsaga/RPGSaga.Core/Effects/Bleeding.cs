namespace RpgSaga.Effects
{
    public class Bleeding : BaseEffect
    {
        public Bleeding(string effectName, int duration, int permanentDamage, bool skipTurn, bool selfEffect)
             : base(effectName, duration, permanentDamage, skipTurn, selfEffect)
        {
        }
    }
}
