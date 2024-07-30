using System.Collections;
using System.Collections.Generic;
using PlayerLoop;
using UI;
using UnityEngine;

public class ScorePerShot : Upgrade
{
    public override void ApplyUpgrade()
    {
        if (player.Score > cost)
        {
            player.Score -= cost;
            inventoryUI.UpdateScore(player.Score);
            cost *= 2;
            player.ScorePerKill++;
            UpdateText();
        }
        player.ScorePerKill++;
    }
}
