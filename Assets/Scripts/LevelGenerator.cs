using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int chunkAmount;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private int chunkLength;
    [SerializeField] private float chunkMoveSpeed;

    private GameObject[] _chunks = new GameObject[12];

    private void Start()
    {
        SpawnChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void SpawnChunks()
    {
        for (var i = 0; i < chunkAmount; i++)
        {
            var spawnPositionZ = transform.position.z + chunkLength * i;
            var chunkPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            // Fourth parameter tells Instantiate to generate
            // chunkPrefabs under chunkParent GameObject
            var newChunk = Instantiate(chunkPrefab, chunkPos, Quaternion.identity, chunkParent);

            _chunks[i] = newChunk;
        }
    }

    private void MoveChunks()
    {
        foreach (var chunk in _chunks)
        {
            // Moving every chunk in _chunks array backwards
            chunk.transform.Translate(Vector3.back * (Time.deltaTime * chunkMoveSpeed));
        }
    }
}
