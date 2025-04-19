using UnityEngine;

namespace _Main.Scripts
{
    public class GameManager : SingletonMonobehaviour<GameManager>
    {
        public Transform spawnPoint;
        
        public void GameOver()
        {
            Debug.Log("Game Over");
            UiManager.Instance.score = 0;
            UiManager.Instance.UpdateUi();
            UiManager.Instance.heartCount = 3;
            UiManager.Instance.UpdateUi();
        }
        
        public void GameSuccsess()
        {
            Debug.Log("Game Success");
            UiManager.Instance.score = 0;
            UiManager.Instance.UpdateUi();
            UiManager.Instance.heartCount = 3;
            UiManager.Instance.UpdateUi();
        }
        
        public void SpawnAtSpawnPoint(Transform player)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.position = spawnPoint.position;
        }
    }
}