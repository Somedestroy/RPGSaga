namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;

    public static class Game
    {
        private static Round round;

        static Game()
        {
            Rand = new Random();
            round = new Round();
            RoundCounter = 1;
        }

        public static Random Rand { get; }

        public static int RoundCounter { get; set; }

        public static List<Hero> HeroesList { get; set; }

        public static void Run((IInputConfig inputConfig, bool save) configTurple)
        {
            try
            {
                HeroesList = configTurple.inputConfig.GetHeroes();
                if (configTurple.save)
                {
                    configTurple.inputConfig.SaveHeroes(HeroesList);
                }

                round.StartRound(HeroesList);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}
