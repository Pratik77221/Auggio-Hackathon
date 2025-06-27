using UnityEngine;

public class Bombing : MonoBehaviour
{
    [Header("Plane Spawning")]
    public GameObject planePrefab;
    public Transform[] spawnPoints; // Assign 5 spawn points in the Inspector
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 3.0f;
    public float planeSpeed = 5.0f;

    private void Start()
    {
        Invoke("SpawnPlane", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnPlane()
    {
        // Choose a random spawn point
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        // Instantiate the plane
        GameObject plane = Instantiate(planePrefab, spawnPoint.position, spawnPoint.rotation);

        // Add movement script to the plane
        var mover = plane.AddComponent<PlaneMover>();
        mover.speed = planeSpeed;

        // Destroy the plane after a random time between 5 and 10 seconds
        Destroy(plane, Random.Range(5f, 10f));

        // Schedule next spawn
        Invoke("SpawnPlane", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}

// Helper script to move the plane in local -x direction
public class PlaneMover : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        // Move along the local -x axis
        transform.position += -transform.right * speed * Time.deltaTime;
    }
}