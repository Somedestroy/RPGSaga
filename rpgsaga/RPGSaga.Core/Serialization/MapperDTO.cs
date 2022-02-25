namespace RpgSaga.Serialization
{
    using RPGSaga.Core;

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
            if (Game.HeroTypes.Archer.ToString() == heroDTO.HeroType)
            {
                return new Archer()
                {
                    Name = heroDTO.Name,
                    HealthPoints = heroDTO.HealthPoints,
                    Damage = heroDTO.Damage,
                };
            }
            else if (Game.HeroTypes.Knight.ToString() == heroDTO.HeroType)
            {
                return new Knight()
                {
                    Name = heroDTO.Name,
                    HealthPoints = heroDTO.HealthPoints,
                    Damage = heroDTO.Damage,
                };
            }
            else if (Game.HeroTypes.Wizard.ToString() == heroDTO.HeroType)
            {
                return new Wizard()
                {
                    Name = heroDTO.Name,
                    HealthPoints = heroDTO.HealthPoints,
                    Damage = heroDTO.Damage,
                };
            }
            else
            {
                return new FailedHero()
                {
                    Name = heroDTO.Name,
                    HealthPoints = heroDTO.HealthPoints,
                    Damage = heroDTO.Damage,
                };
            }
        }
    }
}
