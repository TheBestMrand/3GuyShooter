using System.Collections;
using UnityEngine;

namespace PlayerLoop
{
    public class Weapon : MonoBehaviour
    {
        public float fireRate { get; set; } = 0.5f;
        
        [SerializeField] private Inventory inventory;
        [SerializeField] private Transform firePoint;
        
        private bool canFire = true;

        public void Fire()
        {
            if (canFire && inventory.CanShoot())
            {
                StartCoroutine(FireRoutine());
            }
        }

        private IEnumerator FireRoutine()
        {
            canFire = false;
            
            var bullet = inventory.BulletCurrent;
            var bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);
            var bulletComponent = bulletInstance.GetComponent<Bullets.Bullet>();
            bulletComponent.Fire(transform.forward);
            
            yield return new WaitForSeconds(fireRate);
            
            canFire = true;
        }
    }
}