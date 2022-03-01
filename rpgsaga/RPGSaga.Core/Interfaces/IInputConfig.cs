namespace RpgSaga.Interfaces
{
    using System.Collections.Generic;
    using RPGSaga.Core;

    public interface IInputConfig
    {
        List<Hero> GetHeroes();

        void SaveHeroes(List<Hero> heroes);
    }
}
