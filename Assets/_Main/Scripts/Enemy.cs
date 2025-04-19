using UnityEngine;

namespace _Main.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private PlayerController2D player;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                UiManager.Instance.RemoveHeart();
                GameManager.Instance.SpawnAtSpawnPoint(player.transform);
            }
        }
    }
}