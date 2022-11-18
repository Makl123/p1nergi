using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /// <summary>
    /// Code inspired by Unity Learn Lesson 2.3 - Random Animal Stampede and Unity Learn Lesson 2.4 - Collision Decisions and modified to fit this project.
    /// </summary>
    
    public GameObject[] ObjectPrefabs;

    private float spawnRangeX = 5F;

    private float startDelay = 2F;

    private float spawnInterval = 1.5F;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObject",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnRandomObject()
    {
        int objectIndex = Random.Range(0, ObjectPrefabs.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 6);

        Instantiate(ObjectPrefabs[objectIndex], spawnPos, ObjectPrefabs[objectIndex].transform.rotation);
    }
}
