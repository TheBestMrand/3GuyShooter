using System.Collections;
using System.Collections.Generic;
using PlayerLoop;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Material material;

        private void Start()
        {
            meshRenderer.material = new Material(material);
        }
        
        public void TakeDamage()
        {
            player.ScoreKill();
            StopAllCoroutines();
            StartCoroutine(FlashRed());
        }
        
        private IEnumerator FlashRed()
        {
            meshRenderer.material.SetColor("_FresnetColor", Color.red);
            yield return new WaitForSeconds(0.1f);
            meshRenderer.material.SetColor("_FresnetColor", Color.green);
        }
    }

}