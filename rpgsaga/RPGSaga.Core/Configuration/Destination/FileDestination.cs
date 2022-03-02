namespace RpgSaga.Configuration.Destination
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class FileDestination : IHeroDestination
    {
        private readonly FileService fileService;

        public FileDestination(string fileNameToSave)
        {
            fileService = new FileService(fileNameToSave);
        }

        public void SaveHeroes(List<Hero> heroes)
        {
            fileService.SaveFile(heroes);
        }
    }
}
