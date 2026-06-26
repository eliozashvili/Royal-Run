using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] private int coinValue;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        _scoreManager.IncreaseScore(coinValue);
    }
}
