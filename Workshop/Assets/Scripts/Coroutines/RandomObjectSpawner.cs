using System.Collections;
using UnityEngine;

public class SteadyObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array to store objects to spawn
    public Transform spawnArea; // The area where objects will spawn (e.g., a defined range of positions)
    public float spawnInterval = 2f; // Time between each spawn (steady and predictable)

    private void Start()
    {
        // Start the steady spawning coroutine
        StartCoroutine(SpawnObjectSteadily());
    }

    private IEnumerator SpawnObjectSteadily()
    {
        while (true) // Infinite loop to keep spawning objects
        {
            // Wait for the fixed interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);

            // Randomly pick an object from the array
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Generate a random position within the spawn area
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
                spawnArea.position.y,
                Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
            );

            // Instantiate the selected object at the random position
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }
}

