using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObjectPrefabs;

    private float spawnRangeX;

    private float startDelay;

    private float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnRandomObject()
    {
        int objectIndex = Random.Range(0, ObjectPrefabs.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 0);

        Instantiate(ObjectPrefabs[objectIndex], spawnPos, ObjectPrefabs[objectIndex].transform.rotation);
    }
}
