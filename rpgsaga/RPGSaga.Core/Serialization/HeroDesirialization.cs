namespace RpgSaga.Serialization
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;

    public class HeroDesirialization
    {

        private List<Hero> heroDTOs;
        private HeroGenerator heroGenerator;

        public HeroDesirialization()
        {
            heroDTOs = new List<Hero>();
            heroGenerator = new HeroGenerator();
        }

        public List<Hero> Desirialization(string heroesJson)
        {
            var heroesDTO = JsonConvert.DeserializeObject<List<HeroDTO>>(heroesJson);
            return heroGenerator.GenerateHeroes(heroesDTO);
        }
    }
}
