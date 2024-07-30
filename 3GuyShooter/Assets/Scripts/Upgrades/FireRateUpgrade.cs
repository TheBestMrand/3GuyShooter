using System.Collections;
using System.Collections.Generic;
using PlayerLoop;
using UI;
using UnityEngine;

public class FireRateUpgrade : Upgrade
{
    [SerializeField] private Weapon weapon;
    public override void ApplyUpgrade()
    {
        if (player.Score > cost)
        {
            player.Score -= cost;
            inventoryUI.UpdateScore(player.Score);
            cost *= 2;
            weapon.fireRate *= 0.9f;
            UpdateText();
        }
    }
}
