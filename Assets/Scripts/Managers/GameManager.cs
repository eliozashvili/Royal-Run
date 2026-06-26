using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private float timer;

    public bool IsGameOver { get; private set; }

    private void Update()
    {
        if (IsGameOver) return;

        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F1");

        if (timer >= 0) return;

        GameOver();
    }

    private void GameOver()
    {
        IsGameOver = true;

        playerController.enabled = false;
        gameOverText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);

        Time.timeScale = 0.1f;
    }
}
