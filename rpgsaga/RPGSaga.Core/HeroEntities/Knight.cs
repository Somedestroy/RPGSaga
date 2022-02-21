
namespace RPGSaga.Core
{
    public class Knight : Hero
    {
        public Knight(string name, int healthPoint, int manaPool, int damage)
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
