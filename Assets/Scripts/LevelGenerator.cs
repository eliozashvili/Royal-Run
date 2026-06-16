using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int chunkAmount;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private int chunkLength;

    private void Start()
    {
        for (var i = 0; i < chunkAmount; i++)
        {
            var spawnPositionZ = transform.position.z + chunkLength * i;
            var chunkPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            // Fourth parameter tells Instantiate to generate
            // chunkPrefabs under chunkParent GameObject
            Instantiate(chunkPrefab, chunkPos, Quaternion.identity, chunkParent);
        }
    }
}
