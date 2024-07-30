using PlayerLoop;
using UnityEngine;

namespace Upgrades
{
    public class RichochetAmmoUpgrade : Upgrade
    {
        [SerializeField] private Inventory inventory;
        
        public override void ApplyUpgrade()
        {
            if (player.Score > cost)
            {
                player.Score -= cost;
                inventoryUI.UpdateScore(player.Score);
                inventory.RicochetBulletCount++;
            }
        }
    }
}