namespace RPGSaga.Core
{
    using System;

    public class Duel
    {
        public T StartDuel<T>(T hero1, T hero2)
            where T : Hero
        {
            int firstHeroHealth = hero1.HealthPoints;
            int secondHeroHealth = hero2.HealthPoints;
            Console.WriteLine($"Round {Game.RoundCounter}");
            Console.WriteLine($"Battle {hero1.Name} VS {hero2.Name} beggins!");

            while (hero1.IsAlive() && hero2.IsAlive())
            {
                hero1.ApplyEffects();
                if (!hero1.IsAlive() || !hero2.IsAlive())
                {
                    break;
                }

                if (!hero1.SkipTurn && !hero2.UsedAbility(hero1))
                {
                    hero2.Attacked(hero1);
                }

                hero2.ApplyEffects();
                if (!hero1.IsAlive() || !hero2.IsAlive())
                {
                    break;
                }

                if (!hero2.SkipTurn && !hero1.UsedAbility(hero2))
                {
                    hero1.Attacked(hero2);
                }

                if (!hero1.IsAlive() || !hero2.IsAlive())
                {
                    break;
                }
            }

            return Refresh(hero1, hero2, firstHeroHealth, secondHeroHealth);
        }

        private T Refresh<T>(T hero1, T hero2, int firstHP, int secondHP)
            where T : Hero
        {
            if (!hero1.IsAlive())
            {
                Console.WriteLine($"{hero2.Name} win duel");
                hero2.Regeneration(firstHP);
                Game.RoundCounter++;
                return hero2;
            }
            else
            {
                Console.WriteLine($"{hero1.Name} win duel");
                hero1.Regeneration(secondHP);
                Game.RoundCounter++;
                return hero1;
            }
        }
    }
}
