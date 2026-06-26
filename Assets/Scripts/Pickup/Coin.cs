using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] private int coinValue;

    private ScoreManager _scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        _scoreManager.IncreaseScore(coinValue);
    }
}
