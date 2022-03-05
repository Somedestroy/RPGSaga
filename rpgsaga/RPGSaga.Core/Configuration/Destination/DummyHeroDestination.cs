namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;

    public class DummyHeroDestination : IHeroDestination
    {
        public void SaveHeroes(List<Hero> heroes)
        {
        }
    }
}
