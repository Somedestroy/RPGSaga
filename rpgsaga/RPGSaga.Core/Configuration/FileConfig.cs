namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class FileConfig : IGameConfig
    {
        private FileService fileService;

        public FileConfig()
        {
            fileService = new FileService();
        }

        public List<Hero> GetHeroes()
        {
            return fileService.GetFile();
        }
    }
}
