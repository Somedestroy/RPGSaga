using System;

namespace RPGSaga.Core
{
    public class Duel
    {
        public T StartDuel<T>(T hero1, T hero2)
            where T : Hero
        {
            int firstHeroHealth = hero1.HealthPoints;
            int secondHeroHealth = hero2.HealthPoints;
            Console.WriteLine($"Round {Game.RoundCounter}");
            Console.WriteLine($"Battle {hero1.Name} VS {hero2.Name} beggins!");

            while (hero1.HealthPoints > 0 && hero2.HealthPoints > 0)
            {
                hero1.Attack(hero2);
                Console.WriteLine($"{hero1.Name} deals {hero1.Damage} to {hero2.Name}");
                hero2.Attack(hero1);
                Console.WriteLine($"{hero2.Name} deals {hero2.Damage} to {hero1.Name}");
            }

            if (hero1.HealthPoints == 0)
            {
                Console.WriteLine($"{hero2.Name} win duel");
                hero2.Regeneration(secondHeroHealth);
                Game.RoundCounter++;
                return hero2;
            }
            else
            {
                Console.WriteLine($"{hero1.Name} win duel");
                hero1.Regeneration(firstHeroHealth);
                Game.RoundCounter++;
                return hero1;
            }
        }
    }
}
