namespace RpgSaga.Interfaces
{
    using System.Collections.Generic;
    using RPGSaga.Core;

    public interface IHeroDestination
    {
        void SaveHeroes(List<Hero> heroes);
    }
}
