using UnityEngine;
using System.Collections.Generic;


public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float[] lanes;
    [SerializeField] private float appleSpawnChance;
    [SerializeField] private float coinSpawnChance;
    [SerializeField] private float coinSeparationDistance;

    // 0, 1, 2 represent lanes array index and in-game position
    // left, middle, right
    private readonly List<int> _availableLanes = new() { 0, 1, 2 };

    private void Start()
    {
        // Executes for each Instantiated chunkPrefab
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }

    private void SpawnFence()
    {
        var fencesToSpawn = Random.Range(0, lanes.Length);
        // Iteration count decides how many fences will be spawned
        for (var i = 0; i < fencesToSpawn; i++)
        {
            if (_availableLanes.Count <= 0) break;

            var selectedLane = SelectedLane();
            var spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);

            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }

    private void SpawnCoin()
    {
        if (_availableLanes.Count <= 0 || Random.value > coinSpawnChance) return;

        const int maxCoinsToSpawn = 6;
        var coinsToSpawn = Random.Range(1, maxCoinsToSpawn);
        var selectedLane = SelectedLane();
        var chunkTopZPos = transform.position.z + (coinSeparationDistance * 2f);

        for (var i = 0; i < coinsToSpawn; i++)
        {
            var spawnPosition = new Vector3(lanes[selectedLane], transform.position.y,
                chunkTopZPos - (i * coinSeparationDistance));

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }

    private void SpawnApple()
    {
        if (_availableLanes.Count <= 0 || Random.value > appleSpawnChance) return;

        var selectedLane = SelectedLane();
        var spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);

        Instantiate(applePrefab, spawnPosition, Quaternion.identity, transform);
    }

    private int SelectedLane()
    {
        var randomLaneIndex = Random.Range(0, _availableLanes.Count);
        var selectedLane = _availableLanes[randomLaneIndex];
        // We delete used index so we prevent spawning on same position
        _availableLanes.RemoveAt(randomLaneIndex);

        return selectedLane;
    }
}
