using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text richochetBulletCount;
        [SerializeField] private TMP_Text explosiveBulletCount;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Image richochetBulletImage;
        [SerializeField] private Image explosiveBulletImage;
        [SerializeField] private Image normalBulletImage;

        private void Start()
        {
            SelectNormalBullet();
        }
        
        public void UpdateScore(int score)
        {
            scoreText.text = $"Score: {score}";
        }
        
        public void UpdateRicochetBulletCount(int count)
        {
            richochetBulletCount.text = count.ToString();
        }
        
        public void UpdateExplosiveBulletCount(int count)
        {
            explosiveBulletCount.text = count.ToString();
        }
        
        public void SelectRicochetBullet()
        {
            richochetBulletImage.color = Color.green;
            explosiveBulletImage.color = Color.white;
            normalBulletImage.color = Color.white;
        }
        
        public void SelectExplosiveBullet()
        {
            richochetBulletImage.color = Color.white;
            explosiveBulletImage.color = Color.green;
            normalBulletImage.color = Color.white;
        }
        
        public void SelectNormalBullet()
        {
            richochetBulletImage.color = Color.white;
            explosiveBulletImage.color = Color.white;
            normalBulletImage.color = Color.green;
        }
    }
}