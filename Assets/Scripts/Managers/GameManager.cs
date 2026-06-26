using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private float timer;

    private bool _isGameOver;

    private void Update()
    {
        if (_isGameOver) return;

        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F1");

        if (timer >= 0) return;

        GameOver();
    }

    private void GameOver()
    {
        _isGameOver = true;

        playerController.enabled = false;
        gameOverText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);

        Time.timeScale = 0.1f;
    }
}
