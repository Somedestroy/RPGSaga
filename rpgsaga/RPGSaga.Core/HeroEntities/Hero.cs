namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;

    public abstract class Hero
    {
        public Hero(string name, int healthPoint, int damage)
        {
            Name = name;
            HealthPoints = healthPoint;
            Damage = damage;
        }

        public string Name { get; set; }

        public string HeroType { get; set; }

        public int HealthPoints { get; set; }

        public int Damage { get; set; }

        public bool SkipTurn { get; set; }

        public List<IAbility> ListOfAbilities { get; set; }

        private List<IEffect> ListOfEffects { get; set; } = new List<IEffect>();

        public virtual void Attacked(Hero enemyHero)
        {
            this.SkipTurn = false;
            HealthPoints -= enemyHero.Damage;
            Logger.Info($"{enemyHero} deals {enemyHero.Damage} to {ToString()}");
        }

        public bool IsAlive()
        {
            return HealthPoints > 0;
        }

        public virtual bool UsedAbility(Hero enemyHero)
        {
            if (enemyHero.ListOfAbilities == null)
            {
                return false;
            }

            int index = Game.Rand.Next(0, enemyHero.ListOfAbilities.Count);
            IAbility ability = enemyHero.ListOfAbilities[index];

            var abilityStatus = ability.UseAbility();
            if (!abilityStatus)
            {
                return false;
            }

            AddEffect(ability, enemyHero);
            Logger.Info($"{enemyHero} applies {ability.AbilityName} and deals {ability.Damage} damage");
            HealthPoints -= ability.Damage;
            return true;
        }

        public void ApplyEffects()
        {
            foreach (IEffect effect in ListOfEffects)
            {
                if (effect.UseEffect())
                {
                    if (effect.SkipTurn)
                    {
                        this.SkipTurn = true;
                        HealthPoints -= effect.PermanentDamage;
                        Logger.Info($"{ToString()} skip turn due {effect.EffectName}");
                    }
                    else
                    {
                        HealthPoints -= effect.PermanentDamage;
                        Logger.Info($"{ToString()} takes regular damage {effect.PermanentDamage} due {effect.EffectName}");
                    }
                }
            }
        }

        public void Regeneration(int healthPoints)
        {
            HealthPoints = healthPoints;
            ListOfEffects.Clear();
        }

        public void RefreshAbilities()
        {
            if (ListOfAbilities == null)
            {
                return;
            }

            foreach (var ability in ListOfAbilities)
            {
                ability.NumberOfUse = 1;
            }
        }

        public override string ToString()
        {
            return $"{HeroType}: {NamePattern()}";
        }

        public string NamePattern()
        {
            var nameArray = Name.Split(' ');
            return $"{nameArray[0]} {nameArray[1].ToString().Substring(0, 1)}.";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Hero))
            {
                return false;
            }

            Hero hero = (Hero)obj;
            return Name == hero.Name && HealthPoints == hero.HealthPoints && Damage == hero.Damage && HeroType == hero.HeroType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, HealthPoints, Damage, HeroType);
        }

        private void AddSelfEffect(IEffect selfEffect)
        {
            ListOfEffects.Add(selfEffect);
        }

        private void AddEffect(IAbility ability, Hero enemyHero)
        {
            foreach (IEffect effect in ability.AvailableEffects)
            {
                effect.Duration = 1;
                if (!effect.SelfEffect)
                {
                    if (ListOfEffects.Any(b => b.EffectName.Equals(effect.EffectName)))
                    {
                        ListOfEffects.Remove(effect);
                        ListOfEffects.Add(effect);
                    }
                    else
                    {
                        ListOfEffects.Add(effect);
                    }
                }
                else
                {
                    enemyHero.AddSelfEffect(effect);
                }
            }
        }
    }
}
