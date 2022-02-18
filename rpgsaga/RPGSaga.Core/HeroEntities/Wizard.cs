namespace RPGSaga.Core
{
    public class Wizard : Hero
    {
        public Wizard(string name, int healthPoint, int manaPool, int damage)
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
