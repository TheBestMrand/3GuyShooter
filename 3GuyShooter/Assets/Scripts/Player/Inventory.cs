using Bullets;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerLoop
{
    public class Inventory : MonoBehaviour
    {
        public int RicochetBulletCount
        {
            get => _ricochetBulletCount;
            set
            {
                if (value < -1)
                {
                    throw new System.Exception("Value cannot be less than -1");
                }
                else
                {
                    _ricochetBulletCount = value;
                }
            }
        }
        
        public int ExplosiveBulletCount
        {
            get => _explosiveBulletCount;
            set
            {
                if (value < -1)
                {
                    throw new System.Exception("Value cannot be less than -1");
                }
                else
                {
                    _explosiveBulletCount = value;
                }
            }
        }
        
        [SerializeField] private InventoryUI inventoryUI;
        
        [SerializeField] private GameObject normalBullet;
        [SerializeField] private GameObject ricochetBullet;
        [SerializeField] private GameObject explosiveBullet;
        
        private int _ricochetBulletCount = 1;
        private int _explosiveBulletCount = 1;
        
        public GameObject BulletCurrent { get; private set; }
        
        private void Start()
        {
            BulletCurrent = normalBullet;
        }
        
        public void SetBullet(int bulletId)
        {
            switch (bulletId)
            {
                case 0:
                    BulletCurrent = normalBullet;
                    inventoryUI.SelectNormalBullet();
                    break;
                case 1:
                    if (RicochetBulletCount > 0)
                    {
                        inventoryUI.SelectRicochetBullet();
                        BulletCurrent = ricochetBullet;
                    }

                    break;
                case 2:
                    if (ExplosiveBulletCount > 0)
                    {
                        inventoryUI.SelectExplosiveBullet();
                        BulletCurrent = explosiveBullet;
                    }

                    break;
            }
        }

        public bool CanShoot()
        {
            if (BulletCurrent == ricochetBullet && RicochetBulletCount > 0)
            {
                RicochetBulletCount--;
                inventoryUI.UpdateRicochetBulletCount(RicochetBulletCount);
                return true;
            }

            if (BulletCurrent == explosiveBullet && ExplosiveBulletCount > 0)
            {
                ExplosiveBulletCount--;
                inventoryUI.UpdateExplosiveBulletCount(ExplosiveBulletCount);
                return true;
            }

            return BulletCurrent == normalBullet;
        }
    }
}