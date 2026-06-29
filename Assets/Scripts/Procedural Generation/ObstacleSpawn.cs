using UnityEngine;
using System.Collections;

public class ObstacleSpawn : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform obstacleParent;

    [Header("Obstacle Settings")]
    [SerializeField] private float spawnObstaclesInterval;
    [SerializeField] private float minSpawnObstaclesInterval;
    [SerializeField] private float obstacleSpawnPositionX;


    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    public void HandleObstacleSpawnInterval(float interval)
    {
        spawnObstaclesInterval -= interval;

        if (spawnObstaclesInterval <= minSpawnObstaclesInterval)
            spawnObstaclesInterval = minSpawnObstaclesInterval;
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            var obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            var randomPosX = Random.Range(-obstacleSpawnPositionX, obstacleSpawnPositionX);
            var obstacleSpawnPosition = new Vector3(randomPosX, transform.position.y, transform.position.z);

            Instantiate(obstaclePrefab, obstacleSpawnPosition, Random.rotation, obstacleParent);

            yield return new WaitForSeconds(spawnObstaclesInterval);
        }
    }
}
