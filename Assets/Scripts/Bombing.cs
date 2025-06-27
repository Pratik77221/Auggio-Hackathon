using UnityEngine;

public class Bombing : MonoBehaviour
{
    [Header("Plane Spawning")]
    public GameObject planePrefab;
    public Transform[] spawnPoints; 
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

        GameObject plane = Instantiate(planePrefab, spawnPoint.position, spawnPoint.rotation);

       
        var mover = plane.AddComponent<PlaneMover>();
        mover.speed = planeSpeed;

        
        Destroy(plane, Random.Range(5f, 10f));

        // Schedule next spawn
        Invoke("SpawnPlane", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}

// move the plane in local -x direction
public class PlaneMover : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        // Move along the local -x axis
        transform.position += -transform.right * speed * Time.deltaTime;
    }
}