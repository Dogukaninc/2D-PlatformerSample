using UnityEngine;

public class HeartBg : MonoBehaviour
{
    [SerializeField] private GameObject redHart;

    public void SetHeart()
    {
        redHart.SetActive(false);
    }
    
}
