namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
                Console.WriteLine($"Game is over. Winner is {heroesList[0]}");
                return;
            }

            while (heroesList.Count != 0)
            {
                if ((heroesList.Count % 2) != 0)
                {
                    int extraHero = Game.Rand.Next(0, heroesList.Count);
                    winnersList.Add(heroesList[extraHero]);
                    heroesList.RemoveAt(extraHero);
                }

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
