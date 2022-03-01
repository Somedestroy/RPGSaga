namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class FileConfig : IInputConfig
    {
        private FileService fileService;

        public FileConfig(string fileNameToGet, string fileNameToSave = null)
        {
            fileService = new FileService(fileNameToGet, fileNameToSave);
        }

        public List<Hero> GetHeroes()
        {
            return fileService.GetFile();
        }

        public void SaveHeroes(List<Hero> heroes)
        {
            fileService.SaveFile(heroes);
        }
    }
}
