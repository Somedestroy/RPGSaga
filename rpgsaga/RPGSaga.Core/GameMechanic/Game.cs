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
        }

        public static Random Rand { get; }

        public static int RoundCounter { get; set; }

        public static List<Hero> HeroesList { get; set; }

        public static void Run(IGameConfig gameConfig, bool save)
        {
            try
            {
                HeroesList = gameConfig.GetHeroes();
                if (save)
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
