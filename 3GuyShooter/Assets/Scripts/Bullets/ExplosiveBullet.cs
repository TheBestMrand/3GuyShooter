using UnityEngine;

namespace Bullets
{
    public class ExplosiveBullet : Bullet
    {
        [SerializeField] private float explosionRadius;
        
        public override void Hit(Enemy.Enemy enemy)
        {
            var colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<Enemy.Enemy>(out var enemyFound))
                {
                    enemyFound.TakeDamage();
                }
            }
            Destroy(gameObject);
        }
    }
}