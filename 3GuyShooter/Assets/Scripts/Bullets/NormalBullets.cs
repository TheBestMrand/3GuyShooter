namespace Bullets
{
    public class NormalBullets : Bullet
    {
        public override void Hit(Enemy.Enemy enemy)
        {
            enemy.TakeDamage();
            Destroy(gameObject);
        }
    }
}