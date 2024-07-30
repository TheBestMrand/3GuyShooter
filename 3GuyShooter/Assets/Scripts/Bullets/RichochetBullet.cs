using System.Linq;
using UnityEngine;

namespace Bullets
{
    public class RichochetBullet : Bullet
    {
        [SerializeField] private int richochetCount;
        [SerializeField] private float richochetRadius;
        public override void Hit(Enemy.Enemy enemy)
        {
            var colliders = Physics.OverlapSphere(transform.position, richochetRadius);
            colliders = colliders.OrderBy(item => Random.value).ToArray();
            foreach (var collider in colliders)
            {
                var direction = collider.transform.position - transform.position;
                if (collider.TryGetComponent<Enemy.Enemy>(out var enemyFound) && enemyFound != enemy)
                {
                    enemyFound.TakeDamage();
                    richochetCount--;
                    if (richochetCount <= 0)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        rigidbody.velocity = Vector3.Reflect(rigidbody.velocity, direction);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}