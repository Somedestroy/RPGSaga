namespace RpgSaga.Serialization
{
    using System.Collections.Generic;
    using System.Text.Json;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;

    public class HeroDesirialization
    {
        private HeroGenerator heroGenerator;

        public HeroDesirialization()
        {
            heroGenerator = new HeroGenerator();
        }

        public List<Hero> Desirialization(string heroesJson)
        {
            var heroesDTO = JsonSerializer.Deserialize<List<HeroDTO>>(heroesJson);
            return heroGenerator.GenerateHeroes(heroesDTO);
        }
    }
}
