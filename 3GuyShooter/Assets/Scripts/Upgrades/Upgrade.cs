using System.Collections;
using System.Collections.Generic;
using PlayerLoop;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text upgradeText;
    [SerializeField] private Image upgradeImage;
    
    [SerializeField, TextArea] private string upgradeDescription;
    [SerializeField] private Sprite upgradeSprite;
    
    [SerializeField] protected int cost = 1;
    [SerializeField] protected Player player;
    [SerializeField] protected InventoryUI inventoryUI;
    
    private void Start()
    {
        upgradeText.text = upgradeDescription + "\nCost: " + cost;
        upgradeImage.sprite = upgradeSprite;
    }

    protected void UpdateText()
    {
        upgradeText.text = upgradeDescription + "\nCost: " + cost;
    }
    
    public abstract void ApplyUpgrade();
}
