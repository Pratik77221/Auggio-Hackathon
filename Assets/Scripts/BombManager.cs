using UnityEngine;

public class BombManager : MonoBehaviour
{
    [Header("Bomb Spawning")]
    public GameObject bombPrefab;
    public Transform[] bombSpawnPoints; // Assign bomb spawn points in the Inspector
    public float minBombInterval = 1.0f;
    public float maxBombInterval = 2.5f;

    void Start()
    {
        ScheduleNextBomb();
    }

    void ScheduleNextBomb()
    {
        float interval = Random.Range(minBombInterval, maxBombInterval);
        Invoke(nameof(SpawnBomb), interval);
    }

    void SpawnBomb()
    {
        if (bombSpawnPoints == null || bombSpawnPoints.Length == 0 || bombPrefab == null)
        {
            Debug.LogWarning("BombManager: Missing bomb prefab or spawn points.");
            return;
        }

        int index = Random.Range(0, bombSpawnPoints.Length);
        Transform spawnPoint = bombSpawnPoints[index];

        Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);

        ScheduleNextBomb();
    }
}