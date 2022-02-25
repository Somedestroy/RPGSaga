namespace RpgSaga.Interfaces
{
    using System.Collections.Generic;
    using RPGSaga.Core;

    public interface IGameConfig
    {
        List<Hero> GetHeroes();
    }
}
