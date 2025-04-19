using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts
{
    public class UiManager : MonoBehaviour
    {
        #region Singleton

        public static UiManager Instance { get; set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        #endregion

        public int score = 0;
        [SerializeField] private TextMeshProUGUI scoreText;
        public int heartCount;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject gameSuccessPanel;
        public List<HeartBg> hearts;
        
        private void Start()
        {
            UpdateUi();
        }

        public void UpdateUi()
        {
            scoreText.text = score.ToString();
        }

        public void RemoveHeart()
        {
            hearts[heartCount - 1].SetHeart();
            heartCount--;
        }

        private void Update()
        {
            SetHeartUi();
        }

        public void SetHeartUi()
        {
            if (heartCount <= 0)
            {
                ShowGameOver();
            }
        }
        
        IEnumerator EndDelay()
        {
            yield return new WaitForSeconds(3f);
            GameManager.Instance.GameOver();
        }
        
        public void ShowGameOver()
        {
            gameOverPanel.SetActive(true);
            StartCoroutine(ReloadScene());
        }
        
        public void ShowGameSuccess()
        {
            gameSuccessPanel.gameObject.SetActive(true);
            StartCoroutine(ReloadScene());
        }
        
        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(2f);
            gameOverPanel.gameObject.SetActive(false);
            gameSuccessPanel.gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}