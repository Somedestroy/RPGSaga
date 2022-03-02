namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class FileSource : IHeroSource
    {
        private readonly FileService fileService;

        public FileSource(string fileName)
        {
            fileService = new FileService(fileName);
        }

        public List<Hero> GetHeroes()
        {
            return fileService.GetFile();
        }
    }
}
