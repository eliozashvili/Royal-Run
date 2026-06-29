using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float timerSecondsOnCheckpoint;
    [SerializeField] private float decreaseObstacleSpawnInterval;

    private GameManager _gameManager;
    private ObstacleSpawn _obstacleSpawn;

    private const string PlayerTag = "Player";

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _obstacleSpawn = FindAnyObjectByType<ObstacleSpawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(PlayerTag)) return;

        _obstacleSpawn.HandleObstacleSpawnInterval(decreaseObstacleSpawnInterval);
        _gameManager.IncreaseTimer(timerSecondsOnCheckpoint);
    }
}
