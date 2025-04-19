using UnityEngine;

namespace _Main.Scripts
{
    public class CollectableDetector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Collectable"))
            {
                Debug.Log("Collectable detected!");
                Destroy(other.gameObject);
                UiManager.Instance.score++;
                UiManager.Instance.UpdateUi();
            }
        }
    }
}