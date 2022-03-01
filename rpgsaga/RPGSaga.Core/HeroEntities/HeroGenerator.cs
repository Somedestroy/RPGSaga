namespace RpgSaga.HeroEntities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RPGSaga.Core;
    using RpgSaga.Logger;
    using RpgSaga.Serialization;

    public class HeroGenerator
    {
        private readonly NamesGenerator namesGenerator;
        private List<Hero> heroesList;
        private Random rand;

        public HeroGenerator()
        {
            heroesList = new List<Hero>();
            namesGenerator = new NamesGenerator();
            rand = new Random();
        }

        public List<Hero> Generate(int heroesNumber)
        {
            var values = Enum.GetValues(typeof(HeroTypes));
            for (int index = 0; index < heroesNumber; index++)
            {
                switch ((HeroTypes)rand.Next(0, values.Length))
                {
                    case HeroTypes.Knight:
                        heroesList.Add(new Knight(namesGenerator.GetHeroName(), rand.Next(150, 180), rand.Next(15, 19)));
                        break;
                    case HeroTypes.Wizard:
                        heroesList.Add(new Wizard(namesGenerator.GetHeroName(), rand.Next(90, 120), rand.Next(10, 15)));
                        break;
                    case HeroTypes.Archer:
                        heroesList.Add(new Archer(namesGenerator.GetHeroName(), rand.Next(120, 140), rand.Next(13, 17)));
                        break;
                    case HeroTypes.FailedHero:
                        heroesList.Add(new FailedHero(namesGenerator.GetHeroName(), rand.Next(115, 140), rand.Next(17, 40)));
                        break;
                    default:
                        throw new ArgumentException($"Unsupported type of hero was found.");
                }
            }

            Logger.Info("Heroes were successfully created");
            return heroesList;
        }

        public List<HeroDTO> GenerateDTO(List<Hero> listOfHeroes)
        {
            return listOfHeroes.Select(x => MapperDTO.ModelToDTO(x)).ToList();
        }

        public List<Hero> GenerateHeroes(List<HeroDTO> heroDTO)
        {
            return heroDTO.Select(x => MapperDTO.DTOToModel(x)).ToList();
        }
    }
}
