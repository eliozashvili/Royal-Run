using UnityEngine;
using System.Collections;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnObstaclesTimer;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
            yield return new WaitForSeconds(spawnObstaclesTimer);
        }
    }
}
