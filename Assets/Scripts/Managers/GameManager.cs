using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text restartGameText;
    [SerializeField] private TMP_Text increaseTimerText;
    [Header("Settings")]
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
        if (IsGameOver) yield break;

        increaseTimerText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        increaseTimerText.gameObject.SetActive(false);
    }

    private void DecreaseTimer()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F1");
    }

    private IEnumerator WaitForRestart()
    {
        restartGameText.gameObject.SetActive(true);
        // Check every frame if Space key was pressed after Game Over
        while (!Keyboard.current.spaceKey.wasPressedThisFrame)
            yield return null;

        Time.timeScale = 1f;
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    private void GameOver()
    {
        IsGameOver = true;

        playerController.enabled = false;
        gameOverText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);

        Time.timeScale = 0.1f;

        StartCoroutine(WaitForRestart());
    }
}
