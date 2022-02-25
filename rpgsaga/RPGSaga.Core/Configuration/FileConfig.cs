namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.HeroEntities;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class FileConfig : IGameConfig
    {
        private HeroGenerator heroGenerator;
        private FileService fileService;

        public FileConfig()
        {
            heroGenerator = new HeroGenerator();
            fileService = new FileService();
        }

        public List<Hero> GetHeroes()
        {
            return fileService.GetFile();
        }
    }
}
