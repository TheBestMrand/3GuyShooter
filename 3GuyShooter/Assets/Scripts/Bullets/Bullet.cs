using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;

        [SerializeField] protected Rigidbody rigidbody;

        public void Fire(Vector3 direction)
        {
            rigidbody.velocity = direction * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Enemy.Enemy>(out var enemy))
            {
                Hit(enemy);
            }
        }

        public abstract void Hit(Enemy.Enemy enemy);
    }
}
