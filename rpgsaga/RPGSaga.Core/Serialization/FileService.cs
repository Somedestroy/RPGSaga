namespace RpgSaga.Serialization
{
    using System.Collections.Generic;
    using System.IO;
    using RPGSaga.Core;

    public class FileService
    {
        private const string PathToFolder = @"JSON";
        private HeroDesirialization heroDesirialization;
        private HeroSerialization heroSerialization;

        public FileService(string fileNameToSave, string fileNameToGet = null)
        {
            heroDesirialization = new HeroDesirialization();
            heroSerialization = new HeroSerialization();
            FileNameToSave = fileNameToSave;
            FileNameToGet = fileNameToGet;
        }

        public string FileNameToSave { get; set; }

        public string FileNameToGet { get; set; }

        public void SaveFile(List<Hero> heroesList)
        {
            string fullPath = PathToFolder + @"\" + FileNameToSave;
            var file = heroSerialization.Serialize(heroesList);
            File.WriteAllText(fullPath, file);
        }

        public List<Hero> GetFile()
        {
            string fullPath = PathToFolder + @"\" + FileNameToGet;
            return heroDesirialization.Desirialization(File.ReadAllText(fullPath));
        }
    }
}
