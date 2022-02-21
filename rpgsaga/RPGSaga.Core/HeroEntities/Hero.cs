namespace RPGSaga.Core
{
    public abstract class Hero
    {
        public string Name { get; set; }

        public int HealthPoints { get; set; }

        public int ManaPool { get; set; }

        public string AttackType { get; set; }

        public int Damage { get; set; }

        public Hero(string name, int healthPoint, int manaPool, int damage)
        {
            Name = name;
            HealthPoints = healthPoint;
            ManaPool = manaPool;
            Damage = damage;
        }

        public void Regeneration(int healthPoints)
        {
            HealthPoints = healthPoints;
        }

        public void UseAbility()
        {
            //...
        }

        public void Attack(Hero enemyHero)
        {
            enemyHero.HealthPoints -= this.Damage;
        }
    }
}
