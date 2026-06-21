using UnityEngine;
using System.Collections.Generic;


public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private float[] lanes;

    private void Start()
    {
        // Executes for each Instantiated chunkPrefab
        SpawnFence();
    }

    private void SpawnFence()
    {
        // 0, 1, 2 represent lanes array index and in-game position
        // left, middle, right
        var availableLanes = new List<int> { 0, 1, 2 };
        var fencesToSpawn = Random.Range(0, lanes.Length);
        // Iteration count decides how many fences will be spawned
        for (var i = 0; i < fencesToSpawn; i++)
        {
            var randomLaneIndex = Random.Range(0, availableLanes.Count);
            var selectedLane = availableLanes[randomLaneIndex];
            // We delete used index so we prevent spawning on same position
            availableLanes.RemoveAt(randomLaneIndex);

            var spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);

            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
