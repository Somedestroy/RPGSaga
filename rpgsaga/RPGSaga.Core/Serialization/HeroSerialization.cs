﻿namespace RpgSaga.Serialization
{
    using System.Collections.Generic;
    using System.Text.Json;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;

    public class HeroSerialization
    {
        private HeroGenerator heroGenerator;

        public HeroSerialization()
        {
            heroGenerator = new HeroGenerator();
        }

        public string Serialize(List<Hero> heroesList)
        {
            var heroesDTO = heroGenerator.GenerateDTO(heroesList);
            return JsonSerializer.Serialize(heroesDTO);
        }
    }
}