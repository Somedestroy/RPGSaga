namespace RPGSaga.Core
{
    using System;
    using RpgSaga.Configuration;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;

    public static class Game
    {
        public static Random Rand { get; }

        private static Round round;


        static Game()
        {
            Rand = new Random();
            round = new Round();
            RoundCounter = 1;
        }

        public static int RoundCounter { get; set; }

        public static void Run(IGameConfig gameConfig)
        {
            try
            {
               round.CreatePairs(gameConfig.GetHeroes());
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
