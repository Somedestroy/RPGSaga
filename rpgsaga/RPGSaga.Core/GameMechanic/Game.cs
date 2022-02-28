namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;
    using RpgSaga.Serialization;

    public static class Game
    {
        private static Round round;
        private static FileService fileService;

        static Game()
        {
            fileService = new FileService();
            Rand = new Random();
            round = new Round();
            RoundCounter = 1;
            Save = false;
        }

        public static Random Rand { get; }

        public static int RoundCounter { get; set; }

        public static IGameConfig GameConfig { get; set; }

        public static bool Save { get; set; }

        public static List<Hero> HeroesList { get; set; }

        public static void Run((IGameConfig gameConfig, bool save) config)
        {
            try
            {
                GameConfig = config.gameConfig;
                Save = config.save;
                HeroesList = GameConfig.GetHeroes();
                if (Save)
                {
                    fileService.SaveFile(HeroesList);
                }

                round.CreatePairs(HeroesList);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}
