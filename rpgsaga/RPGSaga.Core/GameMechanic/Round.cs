namespace RPGSaga.Core
{
    using System.Collections.Generic;
    using System.Text;
    using RpgSaga.Logger;

    public class Round
    {
        private Duel duel;
        private readonly StringBuilder sb;

        public Round()
        {
            duel = new Duel();
            sb = new StringBuilder();
        }

        public void CreatePairs(List<Hero> heroesList)
        {
            List<Hero> winnersList = new List<Hero>();
            if (heroesList.Count == 1)
            {
                Logger.Info($"Game is over. Winner is {heroesList[0]}");
                return;
            }

            if ((heroesList.Count % 2) != 0)
            {
                int extraHero = Game.Rand.Next(0, heroesList.Count);
                winnersList.Add(heroesList[extraHero]);
                heroesList.RemoveAt(extraHero);
            }

            while (heroesList.Count != 0)
            {
                int firstIndex = Game.Rand.Next(0, heroesList.Count);
                Hero firstHero = heroesList[firstIndex];
                heroesList.RemoveAt(firstIndex);

                int secondIndex = Game.Rand.Next(0, heroesList.Count);
                Hero secondHero = heroesList[secondIndex];
                heroesList.RemoveAt(secondIndex);
                winnersList.Add(duel.StartDuel(firstHero, secondHero));
            }

            CreatePairs(winnersList);
        }
    }
}
