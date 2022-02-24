namespace RPGSaga.Core
{
    using RpgSaga.Logger;
    using System;
    using System.Text;

    public class Duel
    {
        private readonly StringBuilder sb;

        public Duel()
        {
            sb = new StringBuilder();
        }

        public T StartDuel<T>(T hero1, T hero2)
            where T : Hero
        {
            int firstHeroHealth = hero1.HealthPoints;
            int secondHeroHealth = hero2.HealthPoints;
            sb.Append($"\nRound {Game.RoundCounter}");
            Console.WriteLine(sb.ToString());
            sb.Clear();
            sb.Append($"\nBattle {hero1} VS {hero2} beggins!");
            Console.WriteLine(sb.ToString());
            sb.Clear();
            try
            {
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
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                Game.RoundCounter++;
                if (hero1.HeroType == Game.HeroTypes.FailedHero.ToString())
                {
                    Logger.Error($"{hero1} can't participate in the battle because of he is cheater!");
                    Logger.Info($"{hero2} auto win duel!");
                    hero2.Regeneration(secondHeroHealth);
                    hero2.RefreshAbilities();
                    return hero2;
                }
                else
                {
                    Logger.Error($"{hero2} can't participate in the battle because of he is cheater!");
                    Logger.Info($"{hero1} auto win duel!");
                    hero2.Regeneration(firstHeroHealth);
                    hero1.RefreshAbilities();
                    return hero1;
                }
            }
        }

        private T Refresh<T>(T hero1, T hero2, int firstHP, int secondHP)
            where T : Hero
        {
            if (!hero1.IsAlive())
            {
                Console.WriteLine($"{hero2} win duel");
                hero2.Regeneration(firstHP);
                hero2.RefreshAbilities();
                Game.RoundCounter++;
                return hero2;
            }
            else
            {
                Console.WriteLine($"{hero1} win duel");
                hero1.Regeneration(secondHP);
                hero1.RefreshAbilities();
                Game.RoundCounter++;
                return hero1;
            }
        }
    }
}
