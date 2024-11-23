using System.Collections;
using UnityEngine;

public class SteadyObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnArea;
    public float spawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    // End of Start

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            Vector3 randomPosition = new Vector3(
                Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
                spawnArea.position.y,
                Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
            );

            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
        // End of while
    }
    // End of SpawnObject
}

