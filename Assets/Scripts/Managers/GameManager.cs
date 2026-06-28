using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text increaseTimerText;
    [SerializeField] private float timer;

    public bool IsGameOver { get; private set; }

    private void Update()
    {
        if (IsGameOver) return;

        DecreaseTimer();

        if (timer >= 0) return;

        GameOver();
    }

    public void IncreaseTimer(float time)
    {
        timer += time;

        StartCoroutine(FadeIncreaseTimerText());
    }

    private IEnumerator FadeIncreaseTimerText()
    {
        increaseTimerText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        increaseTimerText.gameObject.SetActive(false);
    }

    private void DecreaseTimer()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F1");
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
