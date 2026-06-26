using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private GameManager gameManager;

    private int _score;

    public void IncreaseScore(int score)
    {
        if (gameManager.IsGameOver) return;

        _score += score;

        tmpText.text = _score.ToString();
    }
}
