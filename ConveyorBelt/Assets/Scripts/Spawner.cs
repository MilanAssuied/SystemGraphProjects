using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnDelay = 2f; // in seconds
    public GameObject objectToSpawn = null;

    private float _nextSpawnTime;

    void Start()
    {
        _nextSpawnTime = spawnDelay;
    }

    void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnTime += spawnDelay;
            if (objectToSpawn != null)
                Instantiate(objectToSpawn, transform);
        }
    }
}
