using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private TMP_Text tmpText;

    private int _score;

    public void IncreaseScore(int score)
    {
        _score += score;

        tmpText.text = _score.ToString();
    }
}
