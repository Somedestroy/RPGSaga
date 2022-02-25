namespace RpgSaga.Serialization
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;

    public class HeroSerialization
    {
        private List<HeroDTO> heroDTOs;
        private HeroGenerator heroGenerator;

        public HeroSerialization()
        {
            heroDTOs = new List<HeroDTO>();
            heroGenerator = new HeroGenerator();
        }

        public string Serialize(List<Hero> heroesList)
        {
            var heroesDTO = heroGenerator.GenerateDTO(heroesList);
            return JsonConvert.SerializeObject(heroesDTO);
        }
    }
}
