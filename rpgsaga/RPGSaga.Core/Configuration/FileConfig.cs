namespace RpgSaga.Configuration
{
    using System.Collections.Generic;
    using RPGSaga.Core;
    using RpgSaga.Interfaces;
    using RpgSaga.Serialization;

    public class FileConfig : IInputConfig
    {
        private readonly FileService fileService;

        public FileConfig(string fileNameToSave = null, string fileNameToGet = null)
        {
            fileService = new FileService(fileNameToSave, fileNameToGet);
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
