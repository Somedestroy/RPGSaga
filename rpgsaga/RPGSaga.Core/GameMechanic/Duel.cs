namespace RPGSaga.Core
{
    using System.Text;
    using RpgSaga.Exceptions;
    using RpgSaga.Logger;

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
            Logger.Info(sb.ToString());
            sb.Clear();
            sb.Append($"\nBattle {hero1} VS {hero2} beggins!");
            Logger.Info(sb.ToString());
            sb.Clear();
            try
            {
                while (!IsDied(hero1, hero2))
                {
                    hero1.ApplyEffects();
                    if (!Fight(hero1, hero2))
                    {
                        break;
                    }

                    hero2.ApplyEffects();
                    if (!Fight(hero2, hero1))
                    {
                        break;
                    }

                    if (IsDied(hero1, hero2))
                    {
                        break;
                    }
                }

                return Refresh(hero1, hero2, firstHeroHealth, secondHeroHealth);
            }
            catch (FailedHeroException ex)
            {
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
                Logger.Info($"{hero2} win duel");
                hero2.Regeneration(firstHP);
                hero2.RefreshAbilities();
                Game.RoundCounter++;
                return hero2;
            }
            else
            {
                Logger.Info($"{hero1} win duel");
                hero1.Regeneration(secondHP);
                hero1.RefreshAbilities();
                Game.RoundCounter++;
                return hero1;
            }
        }

        private bool Fight(Hero hero, Hero enemyHero)
        {
            if (IsDied(hero, enemyHero))
            {
                return false;
            }
            else
            {
                if (!enemyHero.SkipTurn && !hero.UsedAbility(enemyHero))
                {
                    hero.Attacked(enemyHero);
                }

                return true;
            }
        }

        private bool IsDied(Hero hero1, Hero hero2)
        {
            if (!hero1.IsAlive() || !hero2.IsAlive())
            {
                return true;
            }
            return false;
        }
    }
}
