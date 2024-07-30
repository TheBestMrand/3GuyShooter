using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerLoop
{
    public class Player : MonoBehaviour
    {
        public int ScorePerKill { get; set; } = 1;
        public int Score { get; set; } = 0;
        
        [SerializeField] private Weapon weapon;
        [SerializeField] private Inventory inventory;
        [SerializeField] private InventoryUI inventoryUI;
        [SerializeField] private GameObject ShopPanel;
        
        private GameInputManager _inputManager;
        private GameInputManager.PlayerActions _playerActions;
        
        private void Awake()
        {
            _inputManager = new GameInputManager();
            _playerActions = _inputManager.Player;
            
            _playerActions.Shoot.performed += _ => weapon.Fire();
            _playerActions.UseSlot1.performed += _ => inventory.SetBullet(0);
            _playerActions.UseSlot2.performed += _ => inventory.SetBullet(1);
            _playerActions.UseSlot3.performed += _ => inventory.SetBullet(2);
            _playerActions.OpenShop.performed += _ => ShopPanel.SetActive(!ShopPanel.activeSelf);
        }
        
        public void ScoreKill()
        {
            Score += ScorePerKill;
            inventoryUI.UpdateScore(Score);
        }
        
        private void OnEnable()
        {
            _inputManager.Enable();
        }
        
        private void OnDisable()
        {
            _inputManager.Disable();
        }
    }
}
