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
            NeedToSave = false;
        }

        public static Random Rand { get; }

        public static int RoundCounter { get; set; }

        public static IGameConfig GameConfig { get; set; }

        public static bool NeedToSave { get; set; }

        public static List<Hero> heroesList { get; set; }

        public static void Run((IGameConfig gameConfig, bool needToSave) config)
        {
            try
            {
                GameConfig = config.gameConfig;
                NeedToSave = config.needToSave;
                heroesList = GameConfig.GetHeroes();
                if (NeedToSave)
                {
                    fileService.PutFile(heroesList);
                }

                round.CreatePairs(heroesList);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        public enum HeroTypes
        {
            Knight = 0,
            Wizard = 1,
            Archer = 2,
            FailedHero = 3,
        }
    }
}
