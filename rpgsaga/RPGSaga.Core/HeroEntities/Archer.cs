namespace RPGSaga.Core
{
    public class Archer : Hero
    {
        public Archer(string name, int healthPoint, int manaPool, int damage)
            : base(name, healthPoint, manaPool, damage)
        {
        }

        public void UseAbility()

        {
            //...
        }

        public void Attack(Hero enemyHero)
        {
            enemyHero.HealthPoints -= this.Damage;
        }

        public void Regenaration(int healtpoints)
        {
            this.HealthPoints = healtpoints;
        }
    }
}
