namespace RpgSaga.Serialization
{
    using System.Collections.Generic;
    using RpgSaga.Abilities;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;

    public static class MapperDTO
    {
        public static HeroDTO ModelToDTO(Hero hero)
        {
            return new HeroDTO()
            {
                Name = hero.Name,
                HeroType = hero.HeroType,
                HealthPoints = hero.HealthPoints,
                Damage = hero.Damage,
            };
        }

        public static Hero DTOToModel(HeroDTO heroDTO)
        {
            if (HeroTypes.Archer.ToString() == heroDTO.HeroType)
            {
                return new Archer()
                {
                    Name = heroDTO.Name,
                    HeroType = HeroTypes.Archer.ToString(),
                    HealthPoints = heroDTO.HealthPoints,
                    Damage = heroDTO.Damage,
                    ListOfAbilities = new List<IAbility>() { new BurningArrows("Burning Arrows", 34, 45, 1) },
                };
            }
            else if (HeroTypes.Knight.ToString() == heroDTO.HeroType)
            {
                return new Knight()
                {
                    Name = heroDTO.Name,
                    HeroType = HeroTypes.Knight.ToString(),
                    HealthPoints = heroDTO.HealthPoints,
                    Damage = heroDTO.Damage,
                    ListOfAbilities = new List<IAbility>() { new Rupture("Rupture", 40, 55, 1) },
                };
            }
            else if (HeroTypes.Wizard.ToString() == heroDTO.HeroType)
            {
                return new Wizard()
                {
                    Name = heroDTO.Name,
                    HeroType = HeroTypes.Wizard.ToString(),
                    HealthPoints = heroDTO.HealthPoints,
                    Damage = heroDTO.Damage,
                    ListOfAbilities = new List<IAbility>() { new ColdEmbrace("Cold Embrace", 24, 44, 1) },
                };
            }
            else
            {
                return new FailedHero()
                {
                    Name = heroDTO.Name,
                    HeroType = HeroTypes.FailedHero.ToString(),
                    HealthPoints = heroDTO.HealthPoints,
                    Damage = heroDTO.Damage,
                };
            }
        }
    }
}
