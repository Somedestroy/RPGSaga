namespace RpgSaga.Interfaces
{
    using System.Collections.Generic;
    using RPGSaga.Core;

    public interface IHeroSource
    {
        List<Hero> GetHeroes();
    }
}
