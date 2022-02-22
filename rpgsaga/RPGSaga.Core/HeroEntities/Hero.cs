namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;

    public abstract class Hero
    {
        public string Name { get; set; }

        public string HeroType { get; set; }

        public int HealthPoints { get; set; }

        public int Damage { get; set; }

        public bool SkipTurn { get; set; }

        public List<IAbility> ListOfAbilities { get; set; }

        private List<IEffect> ListOfEffects { get; set; } = new List<IEffect>();

        public Hero(string name, int healthPoint, int damage)
        {
            Name = name;
            HealthPoints = healthPoint;
            Damage = damage;
        }

        public void Attacked(Hero enemyHero)
        {
            this.SkipTurn = false;
            HealthPoints -= enemyHero.Damage;
            Console.WriteLine($"{enemyHero} deals {enemyHero.Damage} to {ToString()}");
        }

        public bool IsAlive()
        {
            return HealthPoints > 0 ? true : false;
        }

        public bool UsedAbility(Hero enemyHero)
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
            Console.WriteLine($"{enemyHero} applies {ability.AbilityName} and deals {ability.Damage} damage");
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
                        Console.WriteLine($"{ToString()} skip turn due {effect.EffectName}");
                    }
                    else
                    {
                        HealthPoints -= effect.PermanentDamage;
                        Console.WriteLine($"{ToString()} takes regular damage {effect.PermanentDamage} due {effect.EffectName}");
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
            return Name.Substring(0, Name.IndexOf(" ")) + " " + Name.Substring(Name.IndexOf(" ") + 1, 1) + ".";
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
