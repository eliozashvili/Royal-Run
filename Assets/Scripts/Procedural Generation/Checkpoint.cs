using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float timerSecondsOnCheckpoint;

    private GameManager _gameManager;

    private const string PlayerTag = "Player";

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            _gameManager.IncreaseTimer(timerSecondsOnCheckpoint);
        }
    }
}
