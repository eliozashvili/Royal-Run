using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private CameraController cameraController;

    [Header("Settings")]
    [SerializeField] private int chunkAmount;
    [SerializeField] private int chunkLength;
    [SerializeField] private float chunkMoveSpeed;
    [SerializeField] private float minChunkMoveSpeed;
    [SerializeField] private float maxChunkMoveSpeed;
    [SerializeField] private float minGravity;
    [SerializeField] private float maxGravity;

    private Camera _mainCamera;

    private readonly List<GameObject> _chunks = new();

    private void Start()
    {
        _mainCamera = Camera.main;
        // Spawn 10 chunks before first frame by calling SpawnChunks() 10 times
        // inside SpawnInitialChunks()
        SpawnInitialChunks();
    }

    private void Update()
    {
        // MoveChunks() is called every frame and calculations inside happen every frame
        // NOTE: every frame loop goes from 9 to 0 backwards
        // and checks if chunks are behind camera
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        var newChunkMoveSpeed = chunkMoveSpeed + speedAmount;
        newChunkMoveSpeed = Mathf.Clamp(newChunkMoveSpeed, minChunkMoveSpeed, maxChunkMoveSpeed);

        if (Mathf.Approximately(newChunkMoveSpeed, chunkMoveSpeed)) return;

        chunkMoveSpeed = newChunkMoveSpeed;

        var newGravityZ = Physics.gravity.z - speedAmount;
        newGravityZ = Mathf.Clamp(newGravityZ, minGravity, maxGravity);

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);

        cameraController.ChangeCameraFOV(speedAmount);
    }

    private void SpawnInitialChunks()
    {
        for (var i = 0; i < chunkAmount; i++)
        {
            SpawnChunks();
        }
    }

    private void SpawnChunks()
    {
        var chunkSpawnPos = CalcChunkSpawnPos();
        var newChunk = new Vector3(transform.position.x, transform.position.y, chunkSpawnPos);
        // Fourth parameter tells Instantiate to generate
        // chunkPrefabs under chunkParent GameObject
        var instChunk = Instantiate(chunkPrefab, newChunk, Quaternion.identity, chunkParent);

        _chunks.Add(instChunk);
    }

    private float CalcChunkSpawnPos()
    {
        float spawnPositionZ;

        if (_chunks.Count == 0)
            spawnPositionZ = transform.position.z;
        else
            spawnPositionZ = _chunks[^1].transform.position.z + chunkLength;

        return spawnPositionZ;
    }

    private void MoveChunks()
    {
        for (var i = _chunks.Count - 1; i >= 0; i--)
        {
            // Saving current chunk
            var chunk = _chunks[i];
            // Moving every chunk in _chunks List backwards
            chunk.transform.Translate(Vector3.back * (Time.deltaTime * chunkMoveSpeed));
            // Skip if chunk z position is more then camera's
            if (chunk.transform.position.z >= _mainCamera.transform.position.z - chunkLength) continue;

            Destroy(chunk);
            _chunks.Remove(chunk);
            SpawnChunks();
        }
    }
}
