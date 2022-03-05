namespace RpgSaga.Serialization
{
    using System.Collections.Generic;
    using System.IO;
    using RPGSaga.Core;

    public class FileService
    {
        private const string PathToFolder = @"JSON";
        private readonly HeroDesirialization heroDesirialization;
        private readonly HeroSerialization heroSerialization;
        private readonly string fileName;

        public FileService(string fileName)
        {
            heroDesirialization = new HeroDesirialization();
            heroSerialization = new HeroSerialization();
            this.fileName = fileName;
        }

        public void SaveFile(List<Hero> heroesList)
        {
            string fullPath = PathToFolder + @"\" + fileName;
            var file = heroSerialization.Serialize(heroesList);
            File.WriteAllText(fullPath, file);
        }

        public List<Hero> GetFile()
        {
            string fullPath = PathToFolder + @"\" + fileName;
            return heroDesirialization.Desirialization(File.ReadAllText(fullPath));
        }
    }
}
