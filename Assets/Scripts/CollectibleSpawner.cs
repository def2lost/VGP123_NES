using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public List<GameObject> collectiblePrefabs;
    public List<Transform> spawnLocations;

    void Start()
    {
        SpawnCollectibles();
    }

    void SpawnCollectibles()
    {
        for (int i = 0; i < spawnLocations.Count; i++)
        {
            int randomIndex = Random.Range(0, collectiblePrefabs.Count);
            GameObject collectiblePrefab = collectiblePrefabs[randomIndex];

            Transform spawnLocation = spawnLocations[i];

            GameObject collectible = Instantiate(collectiblePrefab, spawnLocation.position, Quaternion.identity);

            collectible.transform.parent = transform;
        }
    }
}
