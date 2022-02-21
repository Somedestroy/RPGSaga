namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;

    public abstract class Hero
    {
        public string Name { get; set; }

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
            Console.WriteLine($"{enemyHero.Name} deals {enemyHero.Damage} to {Name}");
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
            Console.WriteLine($"{enemyHero.Name} applies {ability.AbilityName} and deals {ability.Damage} damage");
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
                        Console.WriteLine($"{Name} skip turn due {effect.EffectName}");
                    }
                    else
                    {
                        HealthPoints -= effect.PermanentDamage;
                        Console.WriteLine($"{Name} takes regular damage {effect.PermanentDamage} due {effect.EffectName}");
                    }
                }
            }
        }

        public void Regeneration(int healthPoints)
        {
            HealthPoints = healthPoints;
            ListOfEffects.Clear();
        }

        private void AddSelfEffect(IEffect selfEffect)
        {
            ListOfEffects.Add(selfEffect);
        }

        private void AddEffect(IAbility ability, Hero enemyHero)
        {
            foreach (IEffect effect in ability.AvailableEffects)
            {
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
